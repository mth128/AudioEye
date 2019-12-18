using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class AudioBlock
  {
    public int[] Filled;
    public short[] Left { get; }
    public short[] Mono { get; }
    public short[] Right { get; }
    public int BlockSize { get; }
    public int BlockCount { get; }
    public int Size { get; } 
    public AudioBlock(int blockSize = 480, int blockCount = 50)
    {
      BlockSize = blockSize;
      BlockCount = blockCount;
      Size = blockCount * blockSize;
      Left = new short[Size];
      Mono = new short[Size];
      Right = new short[Size];
      Filled = new int[blockCount];
    }

    public void Clear()
    {
      for (int i = 0; i < Size; i++)
        Left[i] = Mono[i] = Right[i] = 0; 
    }

    internal short[] MakeStereo()
    {
      int size = Left.Length; 
      short[] stereo = new short[size* 2];
      for (int i = 0; i < size; i++)
      {
        stereo[i * 2] = Left[i];
        stereo[i * 2 + 1] = Right[i]; 
      }
      return stereo; 
    }

  }
}
