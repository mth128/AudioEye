using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioEye
{
  public partial class TestForm : Form
  {
    public TestForm()
    {
      InitializeComponent();
    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
      int note = Convert.ToInt32(NoteBox.Text);
      int octave = Convert.ToInt32(OctaveBox.Text);

      int frequency = new SingleTone(octave, note).SystemNote;
      int duration = Convert.ToInt32(DurationBox.Text);
      System.Console.Beep(frequency, duration);
    }

    private void GenerateWaveButton_Click(object sender, EventArgs e)
    {
      using (WaveGenerator waveGenerator = new WaveGenerator())
      {
        //waveGenerator.Save("D:\\debugTest.wav");
        waveGenerator.GenerateSoundStream();
        waveGenerator.Play();
      }
    }
  }
}
