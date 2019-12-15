using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{

  

  public class WaveFile : IDisposable
  {
    public MemoryStream stream = new MemoryStream();
    public BinaryWriter wr; 
    public WaveFile(byte[] sound)
    {
      uint numsamples = 44100;
      ushort numchannels = 1;
      ushort samplelength = 1; // in bytes
      uint samplerate = 32768;

      wr =  new BinaryWriter(stream);
      {

        wr.Write("RIFF");
        wr.Write(36 + numsamples * numchannels * samplelength);
        wr.Write("WAVEfmt ");
        wr.Write(16);
        wr.Write((ushort)1);
        wr.Write(numchannels);
        wr.Write(samplerate);
        wr.Write(samplerate * samplelength * numchannels);
        wr.Write(samplelength * numchannels);
        wr.Write((ushort)(8 * samplelength));
        wr.Write("data");
        wr.Write(numsamples * samplelength);
        wr.Write(sound);
        wr.Flush();
      }

    }

    public void Dispose()
    {
      wr.Dispose(); 
      stream.Dispose(); 
    }
  }
}
