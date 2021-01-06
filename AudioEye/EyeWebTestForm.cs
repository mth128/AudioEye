//Copyright (C) Maarten 't Hart 22 december 2019
//GNU License 3 applies for this software. See readme.txt
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamCapturer.Core;

namespace AudioEye
{
  public partial class EyeWebTestForm : Form, IWebcamCaptureView
  {
    //private Bitmap loadedImage;
    private int resolution = 512;

    private int subsectionsPerTone = 4;
    private float powerBase = 1.3f;
    private float centerSubstract = 0.7f;

    //private EyeWeb eyeWeb;

    //private Bitmap webBitmap;

    //private byte[] imageIntensityBytes; 

    private Image snapShotImage = new Bitmap(640,480);
    private bool moveWithCursor = false;
    private bool connected = false; 
    public EyeWebTestForm()
    {
      InitializeComponent();
      UpdateEyeWeb();
      //if (!LoadImage())
      //{
        SetImage(new Bitmap(640, 480));
      //}

      //webcam stuff. 
      VideoDevicesBox.SelectedIndexChanged += OnDevicesComboBoxSelectedIndexChanged;
      VideoResolutionBox.SelectedIndexChanged += OnResolutionsComboBoxSelectedIndexChanged;
      bindingSourceResolutions.DataSource = SupportedFrameSizes;
      bindingSourceVideoSources.DataSource = VideoDevices;
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

    private void MoveWithCursorBox_CheckedChanged(object sender, EventArgs e)
    {
      moveWithCursor = MoveWithCursorBox.Checked;
      if (!moveWithCursor)
        CenterPoint();
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
        if (moveWithCursor)
        {
          CoordXLabel.Text = e.X.ToString();
          CoordYLabel.Text = e.Y.ToString();

          Point point = Image1Point();

          ImageCoordXLabel.Text = point.X.ToString();
          ImageCoordYLabel.Text = point.Y.ToString();

          ThreadControlCenter.Main.LeftPoint = point;
          ThreadControlCenter.Main.RightPoint = point;
        }
        else
        {
          CenterPoint(); 
        }
      }
      catch
      {

      }


    }

    private void CenterPoint()
    {
      if (moveWithCursor)
        return; 
      Point point = ScalePoint(new Point(ImageBox.Width / 2, ImageBox.Height / 2));

      ThreadControlCenter.Main.LeftPoint = point;
      ThreadControlCenter.Main.RightPoint = point;
    }

    public Point Image1Point()
    {
      Point p = ImageBox.PointToClient(Cursor.Position);
      return ScalePoint(p); 
    }

    private Point ScalePoint(Point p)
    {
      try
      {
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
      catch
      {
        return new Point(0, 0); 
      }
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

    private void SetImage(Image newImage)
    {

      Image dispose = ThreadControlCenter.Main.OriginalImage;

      GrayscaleImageData grayscaleImageData = new GrayscaleImageData(newImage);
      StereoImage stereoImage = new StereoImage(grayscaleImageData);
      ThreadControlCenter.Main.OriginalImage = newImage;
      ThreadControlCenter.Main.ActiveStereoImage = stereoImage;
      dispose.DisposeDelayed();
      CenterPoint(); 
    }

    private bool LoadImage()
    {
      using (OpenFileDialog ofd = new OpenFileDialog())
      {
        ofd.Filter = "Images|*.jpg;*.png";
        if (ofd.ShowDialog() != DialogResult.OK) 
          return false;
        SetImage(Image.FromFile(ofd.FileName));
        return true; 
      }
    }
    private void LoadImageButton_Click(object sender, EventArgs e)
    {
      LoadImage(); 
    }

    private void UpdateTimer_Tick(object sender, EventArgs e)
    {
      try
      {
        if (connected && CamImagePictureBox.Image!=null)
        {
          Image modifiedImage = PreProcess(CamImagePictureBox.Image);
          SetImage(modifiedImage);
        }

        ImageBox.Image = ThreadControlCenter.Main.EditedOriginal;
        LeftBox.Image = ThreadControlCenter.Main.OutputBitmapLeft;
        RightBox.Image = ThreadControlCenter.Main.OutputBitmapRight;
        MonoBox.Image = ThreadControlCenter.Main.OutputBitmapMono;
      }
      catch
      {

      }
    }

    private Image previousMovementImage = null;
    private Image currentMovementImage = null; 

    private Image DetectMovement(Image image)
    {
      if (image == currentMovementImage)
        return Difference((Bitmap)previousMovementImage, (Bitmap)currentMovementImage);

      if (previousMovementImage !=null)
        previousMovementImage.Dispose();
      
      previousMovementImage = currentMovementImage; 
      currentMovementImage = image;

      return Difference((Bitmap) previousMovementImage, (Bitmap)currentMovementImage);

    }

    Image previousImage = null;
    Image previousResult = null; 
    private Image PreProcess(Image image, bool contrastOnly = false, bool mix = false)
    {
      if (image == previousImage)
        return previousResult;

      previousImage = image; 
      
      Image contrastImage = SetContrast(image);
      if (contrastOnly)
      {
        previousResult = contrastImage;
      }
      else
      {
        Image movementImage = DetectMovement(contrastImage);
        if (mix)
        {
          previousResult = Mix((Bitmap)movementImage, (Bitmap)contrastImage, 1.5f, 0.2f);
          movementImage.Dispose();
        }
        else
          previousResult = movementImage;
      }
      return previousResult; 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="aContribution">aContribution value must be between 0 and 1</param>
    /// <returns></returns>
    private Image Mix(Bitmap a, Bitmap b, float aContribution, float bContribution)
    {
      if (a == null)
        return b;
      if (b == null)
        return a;

      Bitmap newBitmap = (Bitmap)a.Clone();
      BitmapData dataNew = newBitmap.LockBits(
          new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
          ImageLockMode.ReadWrite,
          newBitmap.PixelFormat);
      BitmapData dataA = a.LockBits(
          new Rectangle(0, 0, a.Width, a.Height),
          ImageLockMode.ReadWrite,
          newBitmap.PixelFormat);

      BitmapData dataB = b.LockBits(
        new Rectangle(0, 0, a.Width, a.Height),
        ImageLockMode.ReadWrite,
        newBitmap.PixelFormat);

      int Height = newBitmap.Height;
      int Width = newBitmap.Width;
      int stride = dataNew.Stride;
      int offset = 4;
      if (newBitmap.PixelFormat == PixelFormat.Format24bppRgb)
        offset = 3;
      unsafe
      {
        for (int y = 0; y < Height; ++y)
        {
          byte* rowNew = (byte*)dataNew.Scan0 + (y * stride);
          byte* rowA = (byte*)dataA.Scan0 + (y * stride);
          byte* rowB = (byte*)dataB.Scan0 + (y * stride);
          int columnOffset = 0;
          for (int x = 0; x < Width; ++x)
          {
            byte Ba = rowA[columnOffset];
            byte Ga = rowA[columnOffset + 1];
            byte Ra = rowA[columnOffset + 2];
            byte Bb = rowB[columnOffset];
            byte Gb = rowB[columnOffset + 1];
            byte Rb = rowB[columnOffset + 2];

            float Red = (Ra * aContribution + Rb*bContribution) ;
            float Green = (Ga * aContribution + Gb * bContribution);
            float Blue = (Ba * aContribution + Bb * bContribution);

            int iR = (int)Red;
            iR = iR > 255 ? 255 : iR;
            iR = iR < 0 ? 0 : iR;
            int iG = (int)Green;
            iG = iG > 255 ? 255 : iG;
            iG = iG < 0 ? 0 : iG;
            int iB = (int)Blue;
            iB = iB > 255 ? 255 : iB;
            iB = iB < 0 ? 0 : iB;

            rowNew[columnOffset] = (byte)iB;
            rowNew[columnOffset + 1] = (byte)iG;
            rowNew[columnOffset + 2] = (byte)iR;
             
            columnOffset += offset;
          }
        }
      }
      newBitmap.UnlockBits(dataNew);
      a.UnlockBits(dataA);
      b.UnlockBits(dataB);
      return newBitmap;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="image"></param>
    /// <param name="contrast">value should be between -100 and 100</param>
    /// <returns></returns>
    private Image SetContrast(Image image ,float contrast = 100)
    {
      //https://stackoverflow.com/questions/3115076/adjust-the-contrast-of-an-image-in-c-sharp-efficiently
      contrast = (100.0f + contrast) / 100.0f;
      contrast *= contrast;
      Bitmap newBitmap = (Bitmap)image.Clone();
      BitmapData data = newBitmap.LockBits(
          new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
          ImageLockMode.ReadWrite,
          newBitmap.PixelFormat);
      int Height = newBitmap.Height;
      int Width = newBitmap.Width;
      int stride = data.Stride;
      int offset = 4; 
      if (newBitmap.PixelFormat == PixelFormat.Format24bppRgb)
        offset = 3; 
      unsafe
      {
        for (int y = 0; y < Height; ++y)
        {
          byte* row = (byte*)data.Scan0 + (y * stride);
          int columnOffset = 0;
          for (int x = 0; x < Width; ++x)
          {
            byte B = row[columnOffset];
            byte G = row[columnOffset + 1];
            byte R = row[columnOffset + 2];

            float Red = R / 255.0f;
            float Green = G / 255.0f;
            float Blue = B / 255.0f;
            Red = (((Red - 0.5f) * contrast) + 0.5f) * 255.0f;
            Green = (((Green - 0.5f) * contrast) + 0.5f) * 255.0f;
            Blue = (((Blue - 0.5f) * contrast) + 0.5f) * 255.0f;

            int iR = (int)Red;
            iR = iR > 255 ? 255 : iR;
            iR = iR < 0 ? 0 : iR;
            int iG = (int)Green;
            iG = iG > 255 ? 255 : iG;
            iG = iG < 0 ? 0 : iG;
            int iB = (int)Blue;
            iB = iB > 255 ? 255 : iB;
            iB = iB < 0 ? 0 : iB;

            row[columnOffset] = (byte)iB;
            row[columnOffset + 1] = (byte)iG;
            row[columnOffset + 2] = (byte)iR;

            columnOffset += offset;
          }
        }
      }
      newBitmap.UnlockBits(data);
      return newBitmap;
    }

    private Bitmap Difference(Bitmap a, Bitmap b)
    {
      if (a == null)
        return b;
      if (b == null)
        return a; 

      Bitmap newBitmap = (Bitmap)a.Clone();
      BitmapData dataNew = newBitmap.LockBits(
          new Rectangle(0, 0, newBitmap.Width, newBitmap.Height),
          ImageLockMode.ReadWrite,
          newBitmap.PixelFormat);
      BitmapData dataA = a.LockBits(
          new Rectangle(0, 0, a.Width, a.Height),
          ImageLockMode.ReadWrite,
          newBitmap.PixelFormat);

      BitmapData dataB = b.LockBits(
        new Rectangle(0, 0, a.Width, a.Height),
        ImageLockMode.ReadWrite,
        newBitmap.PixelFormat);

      int Height = newBitmap.Height;
      int Width = newBitmap.Width;
      int stride = dataNew.Stride;
      int offset = 4;
      if (newBitmap.PixelFormat == PixelFormat.Format24bppRgb)
        offset = 3;
      unsafe
      {
        for (int y = 0; y < Height; ++y)
        {
          byte* rowNew = (byte*)dataNew.Scan0 + (y * stride);
          byte* rowA = (byte*)dataA.Scan0 + (y * stride);
          byte* rowB = (byte*)dataB.Scan0 + (y * stride);
          int columnOffset = 0;
          for (int x = 0; x < Width; ++x)
          {
            for (int i =0; i<3;i++)
              if (rowA[columnOffset+i] > rowB[columnOffset + i])
                rowNew[columnOffset + i] = (byte) (rowA[columnOffset + i] - rowB[columnOffset + i]);
              else 
                rowNew[columnOffset + i] = (byte) (rowB[columnOffset + i] - rowA[columnOffset + i]);

            columnOffset += offset;
          }
        }
      }
      newBitmap.UnlockBits(dataNew);
      a.UnlockBits(dataA);
      b.UnlockBits(dataB);
      return newBitmap;
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

    private void EyeWebTestForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (connected)
        Disconnect.Invoke(sender, e);
      Application.Exit();
    }

    //webcam capabilities
    //https://github.com/rgomez90/WebcamCapturer.Controls/blob/master/WebcamCapturer.Controls.WinForms/WebcamCaptureForm.cs
    private BindingList<string> supportedFrameSizes = new BindingList<string>();

    private BindingList<string> videoDevices = new BindingList<string>();
    private bool initialized = false;

    public Image ActualCamImage
    {
      get => CamImagePictureBox.Image;
      set => CamImagePictureBox.Image = value;
    }

    public string SelectedVideoDevice { get; set; }
    public Image SnapShotImage { 
      get =>snapShotImage;
      set
      {
        Image disposable = snapShotImage; 
        snapShotImage = value;
        ThreadControlCenter.Main.OriginalImage = snapShotImage;
        disposable?.Dispose(); 
      }
    
    }
    public BindingList<string> SupportedFrameSizes
    {
      get => supportedFrameSizes;
      set
      {
        supportedFrameSizes = value;
        VideoResolutionBox.Items.Clear();
        foreach (var supportedFrameSize in supportedFrameSizes)
        {
          VideoResolutionBox.Items.Add(supportedFrameSize);
        }
      }
    }


    public BindingList<string> VideoDevices
    {
      get => videoDevices;
      set
      {
        videoDevices = value;
        VideoDevicesBox.Items.Clear();
        foreach (var videoDevice in videoDevices)
        {
          VideoDevicesBox.Items.Add(videoDevice);
        }
      }
    }

    public event EventHandler Connect;

    public event EventHandler<string> DeviceSelected;

    public event EventHandler Disconnect;

    public event EventHandler<string> ResolutionSelected;

    public event EventHandler SaveSnapShot;

    public event EventHandler SnapShot;

    public void EnableConnectionControls(bool enable)
    {
      VideoDevicesBox.Enabled = enable;
      VideoResolutionBox.Enabled = enable;
      connected = enable; 
    }

    string IWebcamCaptureView.GetExportPath()
    {
      throw new NotImplementedException();
    }

    public void Message(string message)
    {
      MessageBox.Show(message);
    }

    private void OnResolutionsComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      if (VideoResolutionBox.SelectedItem == null)
        return;
      ResolutionSelected?.Invoke(this, (string)VideoResolutionBox.SelectedItem);
    }

    private void OnDevicesComboBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      DeviceSelected?.Invoke(this, (string)VideoDevicesBox.SelectedItem);
    }

    private void ConnectButton_Click(object sender, EventArgs e)
    {
      if (!connected)
      {
        try
        {
          if (VideoDevicesBox.SelectedIndex < 0)
            VideoDevicesBox.SelectedIndex = 0;
          if (VideoResolutionBox.Text == null || VideoResolutionBox.Text == "")
          {
            DeviceSelected?.Invoke(this, (string)VideoDevicesBox.SelectedItem);
            VideoResolutionBox.SelectedItem = "640 x 480";
          }
        }
        catch
        {

        }
        Connect.Invoke(sender, e);
        CenterPoint();
        connected = true; 
      }
      else
      {
        Disconnect.Invoke(sender, e);
        connected = false; 
      }
    }



    private void VideoDevicesBox_TextChanged(object sender, EventArgs e)
    {
      if (initialized)
        return;
      initialized = true;
      try
      {
        VideoDevicesBox.SelectedIndex = 0;
        VideoResolutionBox.SelectedIndex = 0;
        Connect.Invoke(sender, e);
      }
      catch
      {

      }
    }

    private void TestSnapShotButton_Click(object sender, EventArgs e)
    {
      //SnapShot?.Invoke(this, EventArgs.Empty);
      //Image newImage = (Image) SnapShotImage.Clone();
      if (CamImagePictureBox.Image == null)
        return; 
      Image newImage = (Image) CamImagePictureBox.Image.Clone(); 
      SetImage(newImage);  
    }




    //end of webcam capabilities


  }
}
