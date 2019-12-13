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
    private Bitmap loadedImage;
    private int resolution = 1024;
    private float centerX = 500;
    private float centerY = 500;

    private int subsectionsPerTone = 4;
    private float powerBase = 1.8f;
    private float centerSubstract = 0.5f;
    private bool blockRedraw = false;

    private EyeWeb eyeWeb;

    private Bitmap webBitmap;
    private Bitmap sourceImage; 

    public Form1()
    {
      InitializeComponent();
    }

    public void SetCenterX(float x)
    {
      centerX = x;
      Redraw();
    }

    public void SetCenterY(float y)
    {
      centerY = y;
      Redraw(); 
    }

    public void SetResolution(int r)
    {
      resolution = r; 
      Redraw(); 
    }

    public void Redraw(bool changeEyeWeb = true, bool redrawEyeWeb = false)
    {
      if (blockRedraw)
        return;

      if (eyeWeb == null)
        changeEyeWeb = true;

      if (changeEyeWeb)
        redrawEyeWeb = true;

      if (changeEyeWeb)
      {
        eyeWeb = new EyeWeb(subsectionsPerTone, powerBase, centerSubstract);
      }

      if (redrawEyeWeb)
      { 
        Bitmap bitmap = new Bitmap(resolution, resolution);
        pictureBox2.Image = bitmap;
        webBitmap = bitmap; 
        int tint = 0; 
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
          graphics.Clear(Color.White);

          //Draw the connecting lines.
          using (Pen pen = new Pen(Color.Black))
          {
            foreach (EyeWebShape rectangle in eyeWeb.shapes)
            {
              PointF[] points = new PointF[4];
              for (int i =0; i<4;i++)
                points[i] = rectangle.coordinates[i].PointF(eyeWeb.extent, resolution);

              rectangle.points1 = points; 

              using (Brush brush = new SolidBrush(Color.FromArgb(tint, tint, tint)))
                graphics.FillPolygon(brush, points);
              //graphics.DrawPolygon(pen, points);
              tint++;
              if (tint >= 256)
                tint = 0; 
            }
          }
        }

        float centerX = Convert.ToSingle(TestXBox.Text);
        float centerY = Convert.ToSingle(TestYBox.Text);
      }
      DrawWeb(eyeWeb, resolution, centerX, centerY);
      eyeWeb.CopyDraw(loadedImage, webBitmap); 
    }

    public void SetSubsectionsPerTone(int s)
    {
      subsectionsPerTone = s;
      Redraw(); 
    }

    public void SetPowerBase(float p)
    {
      powerBase = p;
      Redraw(); 
    }

    public void SetCenterSubtract(float c)
    {
      centerSubstract = c;
      Redraw(); 
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

        PictureBox1.Image = loadedImage = ImageEdit.MakeGrayscale3(Image.FromFile(ofd.FileName));
      }



    }

    private void Button2_Click(object sender, EventArgs e)
    {
      subsectionsPerTone = Convert.ToInt32(SubsectionsPerToneBox.Text);
      powerBase = Convert.ToSingle(PowerBaseBox.Text);
      centerSubstract = Convert.ToSingle(CenterSubstractBox.Text);

           
      resolution = Convert.ToInt32(ResolutionBox.Text);

      Redraw(); 

    }

    private void DrawWeb(EyeWeb eyeWeb, float resolution, float centerX, float centerY)
    {
      if (loadedImage == null)
        return;

      Bitmap bitmap = new Bitmap(loadedImage);
      PictureBox1.Image = bitmap; 
      using (Graphics graphics = Graphics.FromImage(bitmap))
      {        
        //Draw the connecting lines.
        using (Pen pen = new Pen(Color.Black))
        {
          for (int i =0; i<eyeWeb.shapes.Count;i++)
          {
            PointF[] points = eyeWeb.GetPoints(i, resolution, centerX, centerY);
            eyeWeb.shapes[i].points2 = points; 
            graphics.DrawPolygon(pen, points);
          }
        }
      }
    }


    private void PictureBox1_MouseEnter(object sender, EventArgs e)
    {

    }

    private void ResolutionBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        SetResolution(Convert.ToInt32(ResolutionBox.Text));
      }
      catch
      {

      }
    }

    private void TestXBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        SetCenterX(Convert.ToSingle(TestXBox.Text));
      }
      catch
      { }
    }

    private void TestYBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        SetCenterY(Convert.ToSingle(TestYBox.Text));
      }
      catch
      {

      }
    }

    private void SubsectionsPerToneBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        SetSubsectionsPerTone(Convert.ToInt32(SubsectionsPerToneBox.Text));
      }
      catch
      {

      }
    }

    private void PowerBaseBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        SetPowerBase(Convert.ToSingle(PowerBaseBox.Text));
      }
      catch
      { }
    }

    private void CenterSubstractBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        SetCenterSubtract(Convert.ToSingle(CenterSubstractBox.Text));
      }
      catch
      {

      }
    }

    private void PictureBox1_MouseHover(object sender, EventArgs e)
    {

    }

    private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        blockRedraw = true; 
        CoordXLabel.Text = e.X.ToString();
        CoordYLabel.Text = e.Y.ToString();

        Point point = Image1Point();

        TestXBox.Text = point.X.ToString();
        TestYBox.Text = point.Y.ToString();
        
      }
      catch
      {

      }
      blockRedraw = false;
      try
      {
        Redraw(false);
      }
      catch
      {

      }
    }

    public Point Image1Point()
    {
      Point p = PictureBox1.PointToClient(Cursor.Position);
      Point unscaled_p = new Point();

      // image and container dimensions
      int w_i = PictureBox1.Image.Width;
      int h_i = PictureBox1.Image.Height;
      int w_c = PictureBox1.Width;
      int h_c = PictureBox1.Height;

      float imageRatio = w_i / (float)h_i; // image W:H ratio
      float containerRatio = w_c / (float)h_c; // container W:H ratio

      if (imageRatio >= containerRatio)
      {
        // horizontal image
        float scaleFactor = w_c / (float)w_i;
        float scaledHeight = h_i * scaleFactor;
        // calculate gap between top of container and top of image
        float filler = Math.Abs(h_c - scaledHeight) / 2;
        unscaled_p.X = (int)(p.X / scaleFactor);
        unscaled_p.Y = (int)((p.Y - filler) / scaleFactor);
      }
      else
      {
        // vertical image
        float scaleFactor = h_c / (float)h_i;
        float scaledWidth = w_i * scaleFactor;
        float filler = Math.Abs(w_c - scaledWidth) / 2;
        unscaled_p.X = (int)((p.X - filler) / scaleFactor);
        unscaled_p.Y = (int)(p.Y / scaleFactor);
      }

      return unscaled_p;

    }

  }



}
