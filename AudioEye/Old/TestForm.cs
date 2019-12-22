//Copyright (C) Maarten 't Hart 22 december 2019
//GNU License 3 applies for this software. See readme.txt
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
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

    SoundPlayer soundPlayer = new SoundPlayer();
    WaveGenerator waveGenerator = new WaveGenerator();

    private void Button1_Click(object sender, EventArgs e)
    { 
      if (soundPlayer.Stream == null) 
        soundPlayer.Stream = waveGenerator.GenerateSoundStream();
      soundPlayer.PlayLooping(); 
    }

    private void Button2_Click(object sender, EventArgs e)
    {
      soundPlayer.Stop(); 
    }
  }
}
