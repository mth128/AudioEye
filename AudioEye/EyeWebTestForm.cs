//Copyright (C) Maarten 't Hart 22 december 2019
//GNU License 3 applies for this software. See readme.txt
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
using WebcamCapturer.Core;

namespace AudioEye
{
  public partial class EyeWebTestForm : Form
  {
    //private Bitmap loadedImage;
    private int resolution = 512;

    private int subsectionsPerTone = 4;
    private float powerBase = 1.5f;
    private float centerSubstract = 0.4f;

    //private EyeWeb eyeWeb;

    //private Bitmap webBitmap;

    //private byte[] imageIntensityBytes; 

    public EyeWebTestForm()
    {
      InitializeComponent();
      UpdateEyeWeb();
      LoadImage(); 
    }


    public void SetResolution(int r)
    {
      resolution = r; 
      UpdateEyeWeb(); 
    }

    public void UpdateEyeWeb()
    {
      ThreadControlCenter.Main.ActiveEyeWeb = new EyeWeb(subsectionsPerTone, powerBase, centerSubstract, resolution);
    }

    public void SetSubsectionsPerTone(int s)
    {
      subsectionsPerTone = s;
      UpdateEyeWeb(); 
    }

    public void SetPowerBase(float p)
    {
      powerBase = p;
      UpdateEyeWeb(); 
    }

    public void SetCenterSubtract(float c)
    {
      centerSubstract = c;
      UpdateEyeWeb(); 
    }



    private void Button2_Click(object sender, EventArgs e)
    {
      subsectionsPerTone = Convert.ToInt32(SubsectionsPerToneBox.Text);
      powerBase = Convert.ToSingle(PowerBaseBox.Text);
      centerSubstract = Convert.ToSingle(CenterSubstractBox.Text);           
      resolution = Convert.ToInt32(ResolutionBox.Text);
      UpdateEyeWeb(); 
    }

    /*
    private void RecalculateWebIntensities(EyeWeb eyeWeb, byte[] imageBytes, int width, int height)
    {
      int leftBound = ThreadControlCenter.Main.LeftPoint.X - resolution / 2;
      int rightBound = ThreadControlCenter.Main.LeftPoint.X + resolution / 2; 

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
    */
    /*
    private void DrawWebOnSource(EyeWeb eyeWeb )
    {

    }*/


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
        CoordXLabel.Text = e.X.ToString();
        CoordYLabel.Text = e.Y.ToString();

        Point point = Image1Point();

        ImageCoordXLabel.Text = point.X.ToString();
        ImageCoordYLabel.Text = point.Y.ToString();

        ThreadControlCenter.Main.LeftPoint = point;
        ThreadControlCenter.Main.RightPoint = point; 

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
      PlaySingleAudioShot(); 
    }

    private void PlaySingleAudioShot()
    {
      Snapshot snapshot = ThreadControlCenter.Main.ActiveSnapshot;
      int bytesPerSecond = 48000;
      double duration = 0.5;
      double frame = duration / bytesPerSecond;
      int steps = Convert.ToInt32(bytesPerSecond * duration);

      short[] amplitudes = new short[steps];
      double start = ThreadControlCenter.Main.SecondsSinceStart;
      Parallel.For(0, steps, i =>
      {
        float amplitude = snapshot.GetAmplitude(i * frame + start, 0);
        if (amplitude >= 1)
          amplitudes[i] = 32760;
        else if (amplitude < -1)
          amplitudes[i] = 0;
        else
          amplitudes[i] = Convert.ToInt16(amplitude * 32760);
      });
      SoundWave.Play(amplitudes);
    }

    private void OpenTestForm_Click(object sender, EventArgs e)
    {
      using (TestForm testForm = new TestForm())
        testForm.ShowDialog(); 
      
    }
    private void LoadImage()
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.Filter = "Images|*.jpg;*.png";
        if (ofd.ShowDialog() != DialogResult.OK)
          return;
        Image dispose = ThreadControlCenter.Main.OriginalImage;
        Image newImage = Image.FromFile(ofd.FileName);
        GrayscaleImageData grayscaleImageData = new GrayscaleImageData(newImage);
        StereoImage stereoImage = new StereoImage(grayscaleImageData);
        ThreadControlCenter.Main.OriginalImage = newImage;
        ThreadControlCenter.Main.ActiveStereoImage = stereoImage; 
        dispose.DisposeDelayed(); 
      }
    }
    private void LoadImageButton_Click(object sender, EventArgs e)
    {
      LoadImage(); 
    }

    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      ImageBox.Image = ThreadControlCenter.Main.EditedOriginal;
      LeftBox.Image = ThreadControlCenter.Main.OutputBitmapLeft;
      RightBox.Image = ThreadControlCenter.Main.OutputBitmapRight;
      MonoBox.Image = ThreadControlCenter.Main.OutputBitmapMono;
    }

    private void OriginalBox_CheckedChanged(object sender, EventArgs e)
    {
      ThreadControlCenter.Main.DrawOriginal = OriginalBox.Checked;
    }


    private void AmplitudeLeftBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        ThreadControlCenter.Main.AmplifyLeft = Convert.ToSingle(AmplitudeLeftBox.Text); 
      }
      catch
      {
        ThreadControlCenter.Main.AmplifyLeft = 1; 
      }
    }

    private void AmplitudeMonoBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        ThreadControlCenter.Main.AmplifyMono = Convert.ToSingle(AmplitudeMonoBox.Text);
      }
      catch
      {
        ThreadControlCenter.Main.AmplifyMono = 1;
      }
    }

    private void AmplitudeRightBox_TextChanged(object sender, EventArgs e)
    {
      try
      {
        ThreadControlCenter.Main.AmplifyRight = Convert.ToSingle(AmplitudeRightBox.Text);
      }
      catch
      {
        ThreadControlCenter.Main.AmplifyRight = 1;
      }
    }

    private void toolStripButton1_Click(object sender, EventArgs e)
    {
      try
      {
        VideoForm videoForm = new VideoForm();
        var presenter = new WebcamCapturePresenter(videoForm);
        videoForm.ShowDialog();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message, "Error");
      }
    }
  }
}
