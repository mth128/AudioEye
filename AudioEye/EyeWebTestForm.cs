using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioEye
{
  public partial class EyeWebTestForm : Form
  {
    private Bitmap loadedImage;
    private int resolution = 512;
    private float centerX = 500;
    private float centerY = 500;

    private int subsectionsPerTone = 4;
    private float powerBase = 1.5f;
    private float centerSubstract = 0.4f;
    private bool blockRedraw = false;

    private EyeWeb eyeWeb;

    //private Bitmap webBitmap;

    private byte[] imageIntensityBytes; 

    public EyeWebTestForm()
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

      eyeWeb.resolution = resolution;
      eyeWeb.sourceCenterX = centerX;
      eyeWeb.sourceCenterY = centerY; 
   
      DrawWebOnSource(eyeWeb);
      if (loadedImage!=null)
        RecalculateWebIntensities(eyeWeb, imageIntensityBytes, loadedImage.Width, loadedImage.Height);

      if (redrawEyeWeb)
      {
        int monoPortion = 1;
        int stereoPortion = 4;
        int portions = monoPortion + stereoPortion; 
        //Drawing the mono shape. 
        Bitmap monoBitmap = new Bitmap(resolution, resolution);
        MonoBox.Image = monoBitmap;
        using (Graphics graphics = Graphics.FromImage(monoBitmap))
        {
          graphics.Clear(Color.DarkBlue);

          foreach (EyeWebShape shape in eyeWeb.shapes)
          {
            PointF[] points = new PointF[4];
            for (int i = 0; i < 4; i++)
              points[i] = shape.coordinates[i].PointF(eyeWeb.extent, resolution);

            shape.targetPoints = points;
            int tint = shape.tintMono;
            using (Brush brush = new SolidBrush(Color.FromArgb(tint, tint, tint)))
              graphics.FillPolygon(brush, points);
          }
        }

        //drawing the right box. 
        Bitmap rightBitmap = new Bitmap(resolution, resolution);
        RightBox.Image = rightBitmap;
        using (Graphics graphics = Graphics.FromImage(rightBitmap))
        {
          graphics.Clear(Color.DarkBlue);

          foreach (EyeWebShape shape in eyeWeb.shapes)
          {
            PointF[] points = new PointF[4];
            for (int i = 0; i < 4; i++)
              points[i] = shape.coordinates[i].PointF(eyeWeb.extent, resolution);

            shape.targetPoints = points;
            int tint = (stereoPortion * shape.tintRight + monoPortion * shape.tintMono) / (portions);
            using (Brush brush = new SolidBrush(Color.FromArgb(tint, tint, tint)))
              graphics.FillPolygon(brush, points);
          }
        }

        //drawing the left box. 
        Bitmap leftBitmap = new Bitmap(resolution, resolution);
        LeftBox.Image = leftBitmap;
        using (Graphics graphics = Graphics.FromImage(leftBitmap))
        {
          graphics.Clear(Color.DarkBlue);

          foreach (EyeWebShape shape in eyeWeb.shapes)
          {
            PointF[] points = new PointF[4];
            for (int i = 0; i < 4; i++)
              points[i] = shape.coordinates[i].PointF(eyeWeb.extent, resolution);

            shape.targetPoints = points;
            int tint = (stereoPortion*shape.tintLeft + monoPortion*shape.tintMono)/(portions);
            using (Brush brush = new SolidBrush(Color.FromArgb(tint, tint, tint)))
              graphics.FillPolygon(brush, points);
          }
        }


        float centerX = Convert.ToSingle(TestXBox.Text);
        float centerY = Convert.ToSingle(TestYBox.Text);
      }
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

        ImageBox.Image = loadedImage = ImageEdit.MakeGrayscale(Image.FromFile(ofd.FileName));

        imageIntensityBytes = ImageEdit.GetIntensityBytesFrom(loadedImage);
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

    private void RecalculateWebIntensities(EyeWeb eyeWeb, byte[] imageBytes, int width, int height)
    {
      int leftBound = Convert.ToInt32(Math.Floor(eyeWeb.sourceCenterX - resolution / 2.0f));
      int rightBound = Convert.ToInt32(Math.Ceiling(eyeWeb.sourceCenterX + resolution / 2.0f)); 

      if (imageBytes == null)
        return; 
      for (int i =0; i<eyeWeb.shapes.Count;i++)
      {
        EyeWebShape shape = eyeWeb.shapes[i];
        StereoValue values = ImageEdit.GetStereoValueOfArea(shape.sourcePoints, imageBytes, width, height, leftBound, rightBound);
        shape.tintLeft = Convert.ToInt32(values.left);
        shape.tintMono = Convert.ToInt32(values.mono);
        shape.tintRight = Convert.ToInt32(values.right);
      }

    }

    private void DrawWebOnSource(EyeWeb eyeWeb )
    {


      if (loadedImage == null)
        return;

      for (int i = 0; i < eyeWeb.shapes.Count; i++)
      {
        PointF[] points = eyeWeb.GetPoints(i, eyeWeb.resolution, eyeWeb.sourceCenterX, eyeWeb.sourceCenterY);
        eyeWeb.shapes[i].sourcePoints = points;
      }
      if (NoRedrawBox.Checked)
        return; 

      Bitmap bitmap = new Bitmap(loadedImage);
      ImageBox.Image = bitmap; 
      using (Graphics graphics = Graphics.FromImage(bitmap))
      {
        if (HideImageBox.Checked)
        {
          graphics.Clear(Color.White);
        }
        //Draw the connecting lines.
        using (Pen pen = new Pen(Color.Red))
        {
          for (int i = 0; i < eyeWeb.shapes.Count; i++)
            graphics.DrawPolygon(pen, eyeWeb.shapes[i].sourcePoints);          
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
        Redraw(false,true);
      }
      catch
      {

      }
    }

    public Point Image1Point()
    {
      Point p = ImageBox.PointToClient(Cursor.Position);
      Point unscaled_p = new Point();

      // image and container dimensions
      int w_i = ImageBox.Image.Width;
      int h_i = ImageBox.Image.Height;
      int w_c = ImageBox.Width;
      int h_c = ImageBox.Height;

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

    private void PictureBox1_Click(object sender, EventArgs e)
    {

    }

    private void GenerateSoundButton_Click(object sender, EventArgs e)
    {
      if (eyeWeb == null)
        return;
      int steps = 48000;
      double duration = 1;
      double frame = duration / steps;

      short[] amplitudes = new short[steps];
      for (int i =0; i<steps;i++)
      {
        float amplitude = eyeWeb.GetMonoAmplitude(i * frame);
        if (amplitude >= 1)
          amplitudes[i] = 32760;
        else if (amplitude < -1)
          amplitudes[i] = 0;
        else
          amplitudes[i] = Convert.ToInt16(amplitude * 16380+16380);
      }
      SoundWave.Play(amplitudes);
    }

    private void TestExampleButton_Click(object sender, EventArgs e)
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
