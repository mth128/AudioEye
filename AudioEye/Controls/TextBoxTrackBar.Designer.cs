namespace SolarSystem
{
  partial class TextBoxTrackBar
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.TitleLabel = new System.Windows.Forms.Label();
      this.TextBox = new System.Windows.Forms.TextBox();
      this.TrackBar = new System.Windows.Forms.TrackBar();
      ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).BeginInit();
      this.SuspendLayout();
      // 
      // TitleLabel
      // 
      this.TitleLabel.AutoSize = true;
      this.TitleLabel.Location = new System.Drawing.Point(3, 6);
      this.TitleLabel.Name = "TitleLabel";
      this.TitleLabel.Size = new System.Drawing.Size(27, 13);
      this.TitleLabel.TabIndex = 0;
      this.TitleLabel.Text = "Title";
      // 
      // TextBox
      // 
      this.TextBox.Location = new System.Drawing.Point(88, 3);
      this.TextBox.Name = "TextBox";
      this.TextBox.Size = new System.Drawing.Size(100, 20);
      this.TextBox.TabIndex = 1;
      this.TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
      this.TextBox.Leave += new System.EventHandler(this.TextBox_Leave);
      // 
      // TrackBar
      // 
      this.TrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.TrackBar.Location = new System.Drawing.Point(194, 3);
      this.TrackBar.Maximum = 1000;
      this.TrackBar.Name = "TrackBar";
      this.TrackBar.Size = new System.Drawing.Size(316, 45);
      this.TrackBar.TabIndex = 2;
      this.TrackBar.Scroll += new System.EventHandler(this.TrackBar_Scroll);
      // 
      // TextBoxTrackBar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.TrackBar);
      this.Controls.Add(this.TextBox);
      this.Controls.Add(this.TitleLabel);
      this.MaximumSize = new System.Drawing.Size(10000, 25);
      this.MinimumSize = new System.Drawing.Size(0, 25);
      this.Name = "TextBoxTrackBar";
      this.Size = new System.Drawing.Size(513, 25);
      ((System.ComponentModel.ISupportInitialize)(this.TrackBar)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label TitleLabel;
    private System.Windows.Forms.TextBox TextBox;
    private System.Windows.Forms.TrackBar TrackBar;
  }
}
