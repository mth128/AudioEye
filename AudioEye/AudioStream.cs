using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class Audio10msBlock
  {
    public static int SamplesPerSecond { get; } = 48000;
    public static int SamplesPerBlock { get; } = 480;
    public static int BufferSize { get; } = 1920;
    public static double FrameDuration { get; } = 1.0 / SamplesPerSecond;
    public static double BlockDuration { get; } = FrameDuration * 10; 

    public byte[] Buffer { get; } = new byte[BufferSize];

    /// <summary>
    /// 
    /// </summary>
    /// <param name="left">480 shorts of audio data for the left ear. (maximum value is 32760)</param>
    /// <param name="right">480 shorts of audio data for the right ear.(maximum value is 32760)</param>
    public Audio10msBlock(short[] left, short[] right)
    {
      uint [] intArray = new uint[SamplesPerBlock];
      for (int i =0;i< SamplesPerBlock; i++)
        intArray[i] = ((uint)left[i] ) | (((uint)right[i]) << 16);
      System.Buffer.BlockCopy(intArray, 0, Buffer, 0, Buffer.Length);  
      /*
      byte[] debugBuffer = new byte[BufferSize];
      int t = 0; 
      for (int i =0; i< SamplesPerBlock; i++)
      {
        byte[] leftBytes = BitConverter.GetBytes(left[i]);
        byte[] rightBytes = BitConverter.GetBytes(right[i]);
        debugBuffer[t++] = leftBytes[0];
        debugBuffer[t++] = leftBytes[1];
        debugBuffer[t++] = rightBytes[0];
        debugBuffer[t++] = rightBytes[1];
      }

      for (int i =0; i< BufferSize; i++)
        if (Buffer[i] != debugBuffer[i])
          throw new Exception("Buffer does not match the debugbuffer");
          */
    }

    public static Audio10msBlock FromSnapshot(Snapshot snapshot, double time, float amplifyLeft, float amplifyRight)
    {
      short[] left = new short[SamplesPerBlock];
      short[] right = new short[SamplesPerBlock];
      if (snapshot == null)
      {
        for (int i = 0; i < SamplesPerBlock; i++)
        {
          left[i] = 16380;
          right[i] = 16380;
        }
      }
      else 
        for (int i =0; i<SamplesPerBlock; i++, time+=FrameDuration)
        {
          left[i] = snapshot.GetShortLeftAmplitude(time, amplifyLeft);
          right[i] = snapshot.GetShortRightAmplitude(time, amplifyRight);
        }

      return new Audio10msBlock(left, right);
    }
  }

  /// <summary>
  /// A stream for audio, using a standard wave format, short stereo, 48000 samples per second. 
  /// </summary>
  public class AudioStream : Stream
  {
    private object locker = new object(); 
    private byte[] waveFileHeader;
    private Audio10msBlock[] blocks;
    private bool startTimeSet = false;
    private int blockSize; 
    private double blockDuration; 

    private double startTime = 10000000;
    private int nextBlockIndex;
    private double maximumSeconds;
    private int position = 0; 

    public double StartTime {
      get => startTime;
      set
      {
        if (startTimeSet)
          return; 
          //throw new Exception("Cannot set start time twice!");
        startTime = value;
        startTimeSet =true;
        nextBlockIndex = 0; 
      }
    }

    public int BlockIndex (double time)
    {
      return (int)((time - startTime) / blockDuration + 0.1); 
    }

    public double GetBlockTime(int index)
    {
      return blockDuration * index + startTime; 
    }

    public int GetNextBlockIndex()
    {
      if (nextBlockIndex >= blocks.Length)
        return -1;
      return nextBlockIndex++; 
    }

    public double EndTime => startTime + maximumSeconds;

    /// <summary>
    /// ReadyForWrite is set true when the header is read. 
    /// </summary>
    public bool ReadyForWrite { get; private set; } = false; 

    public int SampleSize { get; } = 4;
    public int SamplesPerSecond { get; } = 48000;

    public int AudioByteCount { get; }

    public override bool CanRead => true;

    public override bool CanSeek => false;

    public override bool CanWrite => false;

    public override long Length => AudioByteCount + waveFileHeader.Length; 

    public int BlockCount { get; }

    public void SetBlock(int index, Audio10msBlock block)
    {
      if (!startTimeSet)
        return;
      if (index < 0 || index >= blocks.Length)
        return;
      if (blocks[index] != null)
        throw new Exception("Block already set!");
      blocks[index] = block; 
    }


    public override long Position {
      get => position; set => throw new Exception("AudioStream not compatible for setting position.");
    }

    public AudioStream(int maximumSeconds = 60)
    {
      int bytesPerSecond = SampleSize * SamplesPerSecond;
      AudioByteCount = bytesPerSecond * maximumSeconds;
      BlockCount = maximumSeconds * 100;
      blocks = new Audio10msBlock[BlockCount];
      waveFileHeader = new WaveGenerator(new short[0]).GenerateWaveFileHeader(AudioByteCount);
      blockDuration = Audio10msBlock.FrameDuration;
      blockSize = Audio10msBlock.BufferSize; 
      this.maximumSeconds = maximumSeconds; 
    }

    public override void Flush()
    {
      throw new Exception("AudioStream flush not compatible.");
    }

    public override int Read(byte[] buffer, int targetOffset, int count)
    {
      int sourceOffset = position; 

      if (sourceOffset < waveFileHeader.Length)
      {
        //read the header. 
        int end = sourceOffset + count;
        if (end >= waveFileHeader.Length)
        {
          end = waveFileHeader.Length;
          count = end - sourceOffset;
        }

        Array.Copy(waveFileHeader, sourceOffset, buffer, targetOffset, count);

        if (end == waveFileHeader.Length)
          //done reading the header. Ready for writing. 
          ReadyForWrite = true;
        position += count; 

        return count;
      }
      else
      {
        int writtenCount = 0;
        sourceOffset -= waveFileHeader.Length;
        while (position < Length)
        {
          //continue with reading blocks. 

          int end = sourceOffset + count;

          int startBlock = sourceOffset / blockSize;
          int endBlock = end / blockSize;
          if (endBlock * blockSize < end)
            endBlock++;

          int blockOffset = startBlock * blockSize;

          if (endBlock > blocks.Length)
            endBlock = blocks.Length;

          for (int blockIndex = startBlock; blockIndex < endBlock; blockIndex++, blockOffset += blockSize)
          {
            Audio10msBlock block = blocks[blockIndex];
            if (block == null)
            {
              if (writtenCount != 0)
              {
                position += writtenCount;
                return writtenCount;
              }
              else
              {
                while (block == null)
                {
                  System.Threading.Thread.Sleep(1); 
                  block = blocks[blockIndex];
                }
              }
            }
            int inBlockOffset = sourceOffset - blockOffset;
            int readLength = blockSize - inBlockOffset;

            bool deleteBlock = false;
            if (readLength > count)
              readLength = count;
            else
              deleteBlock = true;

            Array.Copy(block.Buffer, inBlockOffset, buffer, targetOffset, readLength);

            //update positions
            targetOffset += readLength;
            count -= readLength;
            sourceOffset += readLength;
            writtenCount += readLength;

            if (deleteBlock)
              //block was completely read, so it is no longer needed. 
              blocks[blockIndex] = null;
            if (readLength == 0)
            {
              position += writtenCount; 
              return writtenCount;
            }
          }
        }
        position += writtenCount; 
        return writtenCount; 
      }
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
      throw new Exception("AudioStream Seek not compatible.");
    }

    public override void SetLength(long value)
    {
      throw new Exception("AudioStream SetLength not compatible.");
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
      throw new Exception("AudioStream write not compatible.");
    }
  }
}
