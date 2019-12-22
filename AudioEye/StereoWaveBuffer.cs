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
  public class StereoWaveBuffer
  {
    /// <summary>
    /// The duration in Seconds
    /// </summary>
    public float Duration { get; }
    /// <summary>
    /// The stereo wave file in memory. 
    /// </summary>
    public byte[] Buffer { get; }
    /// <summary>
    /// Usually 48000 samples per second...
    /// </summary>
    public int SamplesPerSecond { get; }
    /// <summary>
    /// the byte index where the actual sound sample starts. 
    /// </summary>
    public int SoundStartPosition { get; }
    /// <summary>
    /// The amount of sound samples in a buffer. 
    /// </summary>
    public int SampleCount { get; }

    public float ByteDuration { get; }

    private SoundPlayer SoundPlayer { get; set; }

    public StereoWaveBuffer(byte[] buffer, int samplesPerSecond, int soundStartPosition, int sampleCount, float duration)
    {
      this.Buffer = buffer;
      this.SamplesPerSecond = samplesPerSecond;
      this.SoundStartPosition = soundStartPosition;
      this.SampleCount = sampleCount;
      this.Duration = duration;
      ByteDuration = 1.0f / samplesPerSecond; 
    }

    public void SetSample(int sampleIndex, short left, short right)
    {
      byte[] leftBytes = BitConverter.GetBytes(left);
      byte[] rightBytes = BitConverter.GetBytes(right);

      int position = sampleIndex * 4 + SoundStartPosition;
      Buffer[position++] = leftBytes[0];
      Buffer[position++] = leftBytes[1];
      Buffer[position++] = rightBytes[0];
      Buffer[position++] = rightBytes[1];
    }

    public StereoWaveBuffer Copy()
    {
      return new StereoWaveBuffer(Buffer.ToArray(), SamplesPerSecond, SoundStartPosition, SampleCount, Duration);
    }

    public void PrepareForPlay()
    {
      SoundPlayer = new SoundPlayer(new MemoryStream(Buffer));
      SoundPlayer.LoadAsync();
    }

    /// <summary>
    /// Call PrepareForPlay first!
    /// </summary>
    public void Play()
    {
      if (SoundPlayer == null)
        return; 
      SoundPlayer.PlaySync();
    }

    internal void Write(Snapshot snapshot, double time, float amplifyLeft, float amplifyRight)
    {
      for (int i = 0; i<SampleCount;i++)
      {
        short left = snapshot.GetShortAmplitude(time + ByteDuration * i, -1, amplifyLeft);
        short right = snapshot.GetShortAmplitude(time + ByteDuration * i, 1, amplifyRight);
        SetSample(i, left, right);
      }
      /*
      Parallel.For(0, SampleCount, i =>
       {
         short left = snapshot.GetShortAmplitude(time + ByteDuration * i, -1, amplifyLeft);
         short right = snapshot.GetShortAmplitude(time + ByteDuration * i, 1, amplifyRight);
         SetSample(i, left, right);
       });*/

      PrepareForPlay(); 
    }
  }
}
