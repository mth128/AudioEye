using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{

  /// <summary>
  /// A snapshot is a set of 3 arrays. Each array holds a single intensityvalue for each shape in an eyeweb.
  /// Based on this both the output images and the sound can be produced. 
  /// </summary>
  public class Snapshot
  {
    private int size; 
    public int[] Left { get; private set; }
    public int[] Mono { get; private set; }
    public int[] Right { get; private set; }

    public EyeWeb EyeWeb { get; private set; }

    public Snapshot(StereoImage stereoImage, EyeWeb eyeWeb, int centerX, int centerY)
    {
      EyeWeb = eyeWeb; 
      int resolution = eyeWeb.Resolution; 
      int halfResolution = resolution/2;
      int left = centerX - halfResolution;
      int top = centerY - halfResolution; 
      Parallel.For(0, 3, i =>
        {
          switch(i)
          {
            case 0:              
              Left = eyeWeb.GetSnapshot(stereoImage.Left.GetIntensities(left, top, resolution, resolution), true, false); 
              break;
            case 1:
              Mono = eyeWeb.GetSnapshot(stereoImage.Mono.GetIntensities(left, top, resolution, resolution), false, false);
              break;
            case 2:
              Right = eyeWeb.GetSnapshot(stereoImage.Right.GetIntensities(left, top, resolution, resolution), false, true);
              break;
          }
        });
      size = eyeWeb.shapes.Count; 
    }

    public short AmplitudeToShort(float amplitude)
    {
      if (amplitude >= 1)
        return 32760;
      else if (amplitude < -1)
        return  0;
      else
        return Convert.ToInt16(amplitude * 32760);
    }

    /*
    public void Generate10msSoundBlock(AudioBlock audioBlock, int blockIndex, double time, int direction, float amplify = 1.0f, int valuesPerSecond = 48000)
    {
      int sequence = blockIndex /audioBlock.BlockCount;
      blockIndex %= audioBlock.BlockCount;
      int position = audioBlock.BlockSize * blockIndex;

      int count = valuesPerSecond / 100;
      double frame = 1.0 / valuesPerSecond;

      //choose in which array to write. 
      short[] amplitudes = direction == -1 ? audioBlock.Left : direction == +1 ? audioBlock.Right : audioBlock.Mono;

      //keep track of what blocks are filled for debugging purposes. 
      audioBlock.Filled[blockIndex] = sequence;

      for (int i = 0; i<count; i++,position++)
       {
         float amplitude = GetAmplitude(i * frame + time, 0) * amplify;
         if (amplitude >= 1)
           amplitudes[position] = 32760;
         else if (amplitude < -1)
           amplitudes[position] = 0;
         else
           amplitudes[position] = AmplitudeToShort(amplitude);
       }
    }
    */

    /// <summary>
    /// returns an amplitude between -1 and 1. 
    /// </summary>
    /// <param name="time"></param>
    /// <param name="direction">-1 for left, 0 for mono, 1 for right.</param>
    /// <returns></returns>
    public float GetAmplitude(double time, int direction, float amplify = 1.0f)
    {
      int[] activeArray;
      switch (direction)
      {
        case -1:
          activeArray = Left;
          break;
        case 0:
          activeArray = Mono;
          break;
        case 1:
          activeArray = Right;
          break;
        default:
          throw new Exception("Wrong value for direction. Choose -1 for left, 0 for mono and 1 for right.");
      }

      float total = 0;

      for (int i = 0; i < size; i++)
        total += EyeWeb.shapes[i].soundWave.GetAmplitude(time, activeArray[i]);
      
      return total / size / 256 * amplify;
    }

    private short GetShortAmplitude(double time, float amplify, int[] values)
    {
      float total = 0;
      for (int i = 0; i < size; i++)
        total += EyeWeb.shapes[i].soundWave.GetAmplitude(time, values[i]);

      float amplitude = total / size * 255 * amplify;

      if (amplitude > 32760)
        return 32760;
      if (amplitude < -32760)
        return -32760;
      return (short)amplitude;
    }

    public short GetShortLeftAmplitude(double time, float amplify)
    {
      return GetShortAmplitude(time, amplify, Left); 
    }

    public short GetShortMonoAmplitude(double time, float amplify)
    {
      return GetShortAmplitude(time, amplify, Mono);
    }

    public short GetShortRightAmplitude(double time, float amplify)
    {
      return GetShortAmplitude(time, amplify, Right);
    }


    public short GetShortAmplitude (double time, int direction, float amplify = 1.0f)
    {
      return AmplitudeToShort(GetAmplitude(time, direction, amplify)); 
    }
  }
}
