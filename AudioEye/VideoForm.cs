using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamCapturer.Controls.WinForms;
using WebcamCapturer.Core;

namespace AudioEye
{
  public partial class VideoForm : Form, IWebcamCaptureView
  {
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
    public Image SnapShotImage { get => pictureBox1.Image; set => pictureBox1.Image = value; }
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

    public VideoForm()
    {
      InitializeComponent();
      VideoDevicesBox.SelectedIndexChanged += OnDevicesComboBoxSelectedIndexChanged;
      VideoResolutionBox.SelectedIndexChanged += OnResolutionsComboBoxSelectedIndexChanged;
      bindingSourceResolutions.DataSource = SupportedFrameSizes;
      bindingSourceVideoSources.DataSource = VideoDevices;
    }

    public event EventHandler Connect;

    public event EventHandler<string> DeviceSelected;

    public event EventHandler Disconnect;
   
    public event EventHandler<string> ResolutionSelected;

    public event EventHandler SaveSnapShot;

    public event EventHandler SnapShot;
    
    
    private void button1_Click(object sender, EventArgs e)
    {
      try
      {
        using (var view = new WebcamCaptureForm())
        {
          var presenter = new WebcamCapturePresenter(view);
          view.ShowDialog();
        }
      }
      catch
      {

      }
    }

    public void EnableConnectionControls(bool enable)
    {
      VideoDevicesBox.Enabled = enable;
      VideoResolutionBox.Enabled = enable;
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
      try
      {
        if (VideoDevicesBox.SelectedIndex <0)
          VideoDevicesBox.SelectedIndex = 0;
        if (VideoResolutionBox.Text == null || VideoResolutionBox.Text == "")
        {
          DeviceSelected?.Invoke(this, (string)VideoDevicesBox.SelectedItem);
          VideoResolutionBox.SelectedItem = "320 x 240";
        }
      }
      catch
      {

      }
      Connect.Invoke(sender,e); 
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
  }
}
