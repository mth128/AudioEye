//Copyright (C) Maarten 't Hart 22 december 2019
//GNU License 3 applies for this software. See readme.txt
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{

  /// <summary>
  /// https://blogs.msdn.microsoft.com/dawate/2009/06/24/intro-to-audio-programming-part-3-synthesizing-simple-wave-audio-using-c/
  /// </summary>

  public class WaveHeader
  {
    public string sGroupID; // RIFF
    public uint dwFileLength; // total file length minus 8, which is taken up by RIFF
    public string sRiffType; // always WAVE

    /// <summary>
    /// Initializes a WaveHeader object with the default values.
    /// </summary>
    public WaveHeader()
    {
      dwFileLength = 0;
      sGroupID = "RIFF";
      sRiffType = "WAVE";
    }
  }


  public class WaveFormatChunk
  {
    public string sChunkID;         // Four bytes: "fmt "
    public uint dwChunkSize;        // Length of header in bytes
    public ushort wFormatTag;       // 1 (MS PCM)
    public ushort wChannels;        // Number of channels
    public uint dwSamplesPerSec;    // Frequency of the audio in Hz... 44100
    public uint dwAvgBytesPerSec;   // for estimating RAM allocation
    public ushort wBlockAlign;      // sample frame size, in bytes
    public ushort wBitsPerSample;    // bits per sample

    /// <summary>
    /// Initializes a format chunk with the following properties:
    /// Sample rate: 44100 Hz
    /// Channels: Stereo
    /// Bit depth: 16-bit
    /// </summary>
    public WaveFormatChunk()
    {
      sChunkID = "fmt ";
      dwChunkSize = 16;
      wFormatTag = 1;
      wChannels = 2;
      dwSamplesPerSec = 48000;
      wBitsPerSample = 16;
      wBlockAlign = (ushort)(wChannels * (wBitsPerSample / 8));
      dwAvgBytesPerSec = dwSamplesPerSec * wBlockAlign;
    }
  }

  public class WaveDataChunk
  {
    public string sChunkID;     // "data"
    public uint dwChunkSize;    // Length of header in bytes
    public short[] shortArray;  // 8-bit audio

    /// <summary>
    /// Initializes a new data chunk with default values.
    /// </summary>
    public WaveDataChunk()
    {
      shortArray = new short[0];
      dwChunkSize = 0;
      sChunkID = "data";
    }


  }
  public enum WaveExampleType
  {
    ExampleSineWave = 0
  }

  public class WaveGenerator: IDisposable
  {
    public static int samplesPerSecond = 48000; 
    // Header, Format, Data chunks
    WaveHeader header = new WaveHeader();
    WaveFormatChunk format = new WaveFormatChunk();
    WaveDataChunk data = new WaveDataChunk();

    MemoryStream soundStream;
    BinaryWriter writer;
    SoundPlayer soundPlayer = new SoundPlayer();
    public double sampleDuration = 0; 

    public WaveGenerator(short[] soundData = null)
    {
      if (soundData == null)
      {
        GenerateDefault();
        return;       
      }
      SetSoundData(soundData); 
    }

    public void SetSoundData(short[] soundData)
    {
      data.shortArray = soundData;
      // Calculate data chunk size in bytes
      int length = data.shortArray.Length; 
      data.dwChunkSize = (uint)(length * (format.wBitsPerSample / 8));
      sampleDuration = ((double)length) / samplesPerSecond; 
    }


    /// <summary>
    /// A single sine wave. 
    /// </summary>
    private void GenerateDefault()
    {
      // Number of samples = sample rate * channels * bytes per sample
      uint numSamples = format.dwSamplesPerSec * format.wChannels;

      // Initialize the 16-bit array
      data.shortArray = new short[numSamples];

      int amplitude = 32760;  // Max amplitude for 16-bit audio
      double freq = 440.0f;   // Concert A: 440Hz

      // The "angle" used in the function, adjusted for the number of channels and sample rate.
      // This value is like the period of the wave.
      double t = (Math.PI * 2 * freq) / (format.dwSamplesPerSec * format.wChannels);

      for (uint i = 0; i < numSamples - 1; i++)
      {
        // Fill with a simple sine wave at max amplitude
        for (int channel = 0; channel < format.wChannels; channel++)
        {
          data.shortArray[i + channel] = Convert.ToInt16(amplitude * Math.Sin(t * i));
        }
      }

      // Calculate data chunk size in bytes
      data.dwChunkSize = (uint)(data.shortArray.Length * (format.wBitsPerSample / 8));      
    }

    internal void LooseStream()
    {
      soundStream = null; 
    }

    public void Dispose()
    {
      // Clean up
      if (writer == null)
        return; 

      writer.Close();
      soundStream.Close();
      writer.Dispose();
      soundStream.Dispose();
      soundPlayer.Dispose(); 
    }

    public void Save(string filePath)
    {
      // Create a file (it always overwrites)
      FileStream fileStream = new FileStream(filePath, FileMode.Create);

      // Use BinaryWriter to write the bytes to the file
      BinaryWriter writer = new BinaryWriter(fileStream);

      // Write the header
      writer.Write(header.sGroupID.ToCharArray());
      writer.Write(header.dwFileLength);
      writer.Write(header.sRiffType.ToCharArray());

      // Write the format chunk
      writer.Write(format.sChunkID.ToCharArray());
      writer.Write(format.dwChunkSize);
      writer.Write(format.wFormatTag);
      writer.Write(format.wChannels);
      writer.Write(format.dwSamplesPerSec);
      writer.Write(format.dwAvgBytesPerSec);
      writer.Write(format.wBlockAlign);
      writer.Write(format.wBitsPerSample);

      // Write the data chunk
      writer.Write(data.sChunkID.ToCharArray());
      writer.Write(data.dwChunkSize);
      foreach (short dataPoint in data.shortArray)
      {
        writer.Write(dataPoint);
      }

      writer.Seek(4, SeekOrigin.Begin);
      uint filesize = (uint)writer.BaseStream.Length;
      writer.Write(filesize - 8);

      // Clean up
      writer.Close();
      fileStream.Close();
    }

    public byte[] GetBytes()
    {
      using (MemoryStream stream = GenerateSoundStream())
        return stream.ToArray(); 
    }

    public MemoryStream GenerateSoundStream()
    {
      if (soundStream != null)
        throw new Exception("Dispose the previous soundstream first, before generating a new one."); 
      // Create a new memory stream. 
      soundStream = new MemoryStream();

      // Use BinaryWriter to write the bytes to the file
      writer = new BinaryWriter(soundStream);

      // Write the header
      writer.Write(header.sGroupID.ToCharArray());
      writer.Write(header.dwFileLength);
      writer.Write(header.sRiffType.ToCharArray());

      // Write the format chunk
      writer.Write(format.sChunkID.ToCharArray());
      writer.Write(format.dwChunkSize);
      writer.Write(format.wFormatTag);
      writer.Write(format.wChannels);
      writer.Write(format.dwSamplesPerSec);
      writer.Write(format.dwAvgBytesPerSec);
      writer.Write(format.wBlockAlign);
      writer.Write(format.wBitsPerSample);

      // Write the data chunk
      writer.Write(data.sChunkID.ToCharArray());
      writer.Write(data.dwChunkSize);
      foreach (short dataPoint in data.shortArray)
      {
        writer.Write(dataPoint);
      }

      writer.Seek(4, SeekOrigin.Begin);
      uint filesize = (uint)writer.BaseStream.Length;
      writer.Write(filesize - 8);

      writer.Flush();
      soundStream.Position = 0;
      return soundStream; 
    }

    public byte[] GenerateWaveFileHeader(int soundByteCount)
    {
      // Create a new memory stream. 
      MemoryStream soundStream = new MemoryStream(); 

      // Use BinaryWriter to write the bytes to the file
      writer = new BinaryWriter(soundStream);

      // Write the header
      writer.Write(header.sGroupID.ToCharArray());
      writer.Write(header.dwFileLength);
      writer.Write(header.sRiffType.ToCharArray());

      // Write the format chunk
      writer.Write(format.sChunkID.ToCharArray());
      writer.Write(format.dwChunkSize);
      writer.Write(format.wFormatTag);
      writer.Write(format.wChannels);
      writer.Write(format.dwSamplesPerSec);
      writer.Write(format.dwAvgBytesPerSec);
      writer.Write(format.wBlockAlign);
      writer.Write(format.wBitsPerSample);

      // Write the data chunk
      writer.Write(data.sChunkID.ToCharArray());
      writer.Write(soundByteCount);

      writer.Seek(4, SeekOrigin.Begin);
      uint filesize = (uint)(writer.BaseStream.Length + soundByteCount);
      writer.Write(filesize - 8);

      writer.Flush();
      return soundStream.ToArray();
    }


    public void Play()
    {
      soundPlayer.Stream = soundStream; 
      soundPlayer.Play();
    }


    internal void DisposeSoundStream()
    {
      if (soundStream == null)
        return;
      soundStream.Dispose();
      soundStream = null;
      return; 
    }

    public static StereoWaveBuffer GenerateDefaultStereoWaveBuffer(float seconds)
    {
      int samples = (int)(seconds * samplesPerSecond);
      short[] emptyBuffer = new short[samples * 2];
      WaveGenerator waveGenerator = new WaveGenerator(emptyBuffer);
      MemoryStream stream = waveGenerator.GenerateSoundStream();
      byte[] array = stream.ToArray();
      int bufferLength = samples * 4;
      int startPosition = array.Length - bufferLength;
      return new StereoWaveBuffer(array, samplesPerSecond, startPosition, samples, seconds);
    }
  }

}
