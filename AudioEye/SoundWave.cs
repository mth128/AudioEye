using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class SoundWave
  {
    private static float[] sinArray = null;
    public float frequency;    

    public SoundWave(double tone)
    {
      frequency = Convert.ToSingle(16.35 * Math.Pow(2, (tone+24) / 12.0));
    }

    public float GetAmplitude(double time, float volume)
    {
      time *= frequency;
      return GetSecSin(time) * volume; 
    }

    /// <summary>
    /// Returns a sin, for when a full cycle is 1. 
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static float GetSecSin(double s)
    {
      s = (s-Math.Truncate(s));

      if (s < 0)
        s += 1;

      int index = Convert.ToInt32(s*65536);
      if (sinArray == null)
      {
        sinArray = new float[65536];
        for (int i =0;i<65536;i++)
          sinArray[i] = Convert.ToSingle(Math.Sin((2 * Math.PI) * i / 65536.0));
      }
      if (index >= 65536)
        index -= 65536; 
      return sinArray[index];
    }

    public override string ToString()
    {
      return base.ToString() + " " + frequency.ToString();
    }


    public static void Play(byte[] bytes)
    {
      // Place the data into a stream
      using (WaveFile waveFile = new WaveFile(bytes))
      {
        // Construct the sound player
        SoundPlayer player = new SoundPlayer(waveFile.stream);
        player.Play();
      }
    }
  }
}
