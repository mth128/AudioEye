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
  public partial class Form1 : Form
  {

    public Form1()
    {
      InitializeComponent();
    }

    private void PlayButton_Click(object sender, EventArgs e)
    {
      int note = Convert.ToInt32(NoteBox.Text);
      int octave = Convert.ToInt32(OctaveBox.Text);

      int frequency = new Vibe(octave, note).SystemNote;
      int duration = Convert.ToInt32(DurationBox.Text);
      System.Console.Beep(frequency, duration);
    }

    private void Button1_Click(object sender, EventArgs e)
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        if (ofd.ShowDialog() != DialogResult.OK)
          return;

        PictureBox1.Image = Image.FromFile(ofd.FileName);
      }



    }

    private void Button2_Click(object sender, EventArgs e)
    {
      int subsectionsPerTone = Convert.ToInt32(SubsectionsPerToneBox.Text);
      float powerBase = Convert.ToSingle(PowerBaseBox.Text);
      float centerSubstract = Convert.ToSingle(CenterSubstractBox.Text);

      EyeWeb eyeWeb = new EyeWeb(subsectionsPerTone, powerBase, centerSubstract);
           
      int resolution = Convert.ToInt32(ResolutionBox.Text); 

      Bitmap bitmap = new Bitmap(resolution, resolution);
      pictureBox2.Image = bitmap;

      using (Graphics graphics = Graphics.FromImage(bitmap))
      {
        graphics.Clear(Color.White);

        //Draw the connecting lines.
        using (Pen pen = new Pen(Color.Black))
        {
          foreach (EyeWebShape rectangle in eyeWeb.shapes)
          {
            List<PointF> points = new List<PointF>();
            foreach (EyeWebCoordinate coordinate in rectangle.coordinates)
              points.Add(coordinate.PointF(eyeWeb.extent, resolution));
            graphics.DrawLine(pen, points[0], points[1]);
            graphics.DrawLine(pen, points[1], points[2]);
            graphics.DrawLine(pen, points[2], points[3]);
            graphics.DrawLine(pen, points[3], points[0]);

          }
        }
      }
    }

    private void PictureBox1_MouseEnter(object sender, EventArgs e)
    {

    }
  }
}
