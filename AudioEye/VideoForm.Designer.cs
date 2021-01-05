
namespace AudioEye
{
  partial class VideoForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.CamImagePictureBox = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.VideoDevicesBox = new System.Windows.Forms.ComboBox();
      this.VideoResolutionBox = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.bindingSourceResolutions = new System.Windows.Forms.BindingSource(this.components);
      this.bindingSourceVideoSources = new System.Windows.Forms.BindingSource(this.components);
      this.button1 = new System.Windows.Forms.Button();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.ConnectButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.CamImagePictureBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSourceResolutions)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVideoSources)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // CamImagePictureBox
      // 
      this.CamImagePictureBox.Location = new System.Drawing.Point(12, 29);
      this.CamImagePictureBox.Name = "CamImagePictureBox";
      this.CamImagePictureBox.Size = new System.Drawing.Size(320, 240);
      this.CamImagePictureBox.TabIndex = 0;
      this.CamImagePictureBox.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(13, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(79, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Video Devices:";
      // 
      // VideoDevicesBox
      // 
      this.VideoDevicesBox.DataSource = this.bindingSourceVideoSources;
      this.VideoDevicesBox.FormattingEnabled = true;
      this.VideoDevicesBox.Location = new System.Drawing.Point(98, 7);
      this.VideoDevicesBox.Name = "VideoDevicesBox";
      this.VideoDevicesBox.Size = new System.Drawing.Size(121, 21);
      this.VideoDevicesBox.TabIndex = 2;
      // 
      // VideoResolutionBox
      // 
      this.VideoResolutionBox.DataSource = this.bindingSourceResolutions;
      this.VideoResolutionBox.FormattingEnabled = true;
      this.VideoResolutionBox.Location = new System.Drawing.Point(291, 7);
      this.VideoResolutionBox.Name = "VideoResolutionBox";
      this.VideoResolutionBox.Size = new System.Drawing.Size(121, 21);
      this.VideoResolutionBox.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(225, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(60, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "Resolution:";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(338, 34);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 5;
      this.button1.Text = "TestForm";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(418, 29);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(320, 240);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 10;
      this.pictureBox1.TabStop = false;
      // 
      // ConnectButton
      // 
      this.ConnectButton.Location = new System.Drawing.Point(337, 63);
      this.ConnectButton.Name = "ConnectButton";
      this.ConnectButton.Size = new System.Drawing.Size(75, 23);
      this.ConnectButton.TabIndex = 11;
      this.ConnectButton.Text = "Connect";
      this.ConnectButton.UseVisualStyleBackColor = true;
      this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
      // 
      // VideoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(752, 281);
      this.Controls.Add(this.ConnectButton);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.VideoResolutionBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.VideoDevicesBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.CamImagePictureBox);
      this.Name = "VideoForm";
      this.Text = "VideoForm";
      ((System.ComponentModel.ISupportInitialize)(this.CamImagePictureBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSourceResolutions)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVideoSources)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox CamImagePictureBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox VideoDevicesBox;
    private System.Windows.Forms.ComboBox VideoResolutionBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.BindingSource bindingSourceResolutions;
    private System.Windows.Forms.BindingSource bindingSourceVideoSources;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button ConnectButton;
  }
}