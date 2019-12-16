namespace AudioEye
{
  partial class EyeWebTestForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EyeWebTestForm));
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.ImageBox = new System.Windows.Forms.PictureBox();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.LeftBox = new System.Windows.Forms.PictureBox();
      this.RightBox = new System.Windows.Forms.PictureBox();
      this.MonoBox = new System.Windows.Forms.PictureBox();
      this.button2 = new System.Windows.Forms.Button();
      this.SubsectionsPerToneBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.PowerBaseBox = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.CenterSubstractBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.ResolutionBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.CoordXLabel = new System.Windows.Forms.Label();
      this.CoordYLabel = new System.Windows.Forms.Label();
      this.HideImageBox = new System.Windows.Forms.CheckBox();
      this.NoRedrawBox = new System.Windows.Forms.CheckBox();
      this.GenerateSoundButton = new System.Windows.Forms.Button();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.OpenTestFormButton = new System.Windows.Forms.ToolStripButton();
      this.LoadImageButton = new System.Windows.Forms.ToolStripButton();
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ImageCoordXLabel = new System.Windows.Forms.Label();
      this.ImageCoordYLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LeftBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RightBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MonoBox)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(15, 108);
      this.splitContainer1.Name = "splitContainer1";
      this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.ImageBox);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
      this.splitContainer1.Size = new System.Drawing.Size(959, 435);
      this.splitContainer1.SplitterDistance = 229;
      this.splitContainer1.TabIndex = 8;
      // 
      // ImageBox
      // 
      this.ImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ImageBox.Location = new System.Drawing.Point(3, 3);
      this.ImageBox.Name = "ImageBox";
      this.ImageBox.Size = new System.Drawing.Size(953, 223);
      this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.ImageBox.TabIndex = 0;
      this.ImageBox.TabStop = false;
      this.ImageBox.Click += new System.EventHandler(this.PictureBox1_Click);
      this.ImageBox.MouseEnter += new System.EventHandler(this.PictureBox1_MouseEnter);
      this.ImageBox.MouseHover += new System.EventHandler(this.PictureBox1_MouseHover);
      this.ImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
      this.tableLayoutPanel1.Controls.Add(this.LeftBox, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.RightBox, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.MonoBox, 1, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(3, -1);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 1;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(953, 200);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // LeftBox
      // 
      this.LeftBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LeftBox.Location = new System.Drawing.Point(3, 3);
      this.LeftBox.Name = "LeftBox";
      this.LeftBox.Size = new System.Drawing.Size(311, 194);
      this.LeftBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.LeftBox.TabIndex = 2;
      this.LeftBox.TabStop = false;
      // 
      // RightBox
      // 
      this.RightBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.RightBox.Location = new System.Drawing.Point(637, 3);
      this.RightBox.Name = "RightBox";
      this.RightBox.Size = new System.Drawing.Size(313, 194);
      this.RightBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.RightBox.TabIndex = 3;
      this.RightBox.TabStop = false;
      // 
      // MonoBox
      // 
      this.MonoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.MonoBox.Location = new System.Drawing.Point(320, 3);
      this.MonoBox.Name = "MonoBox";
      this.MonoBox.Size = new System.Drawing.Size(311, 194);
      this.MonoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.MonoBox.TabIndex = 1;
      this.MonoBox.TabStop = false;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(655, 28);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 9;
      this.button2.Text = "Draw Web";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.Button2_Click);
      // 
      // SubsectionsPerToneBox
      // 
      this.SubsectionsPerToneBox.Location = new System.Drawing.Point(527, 31);
      this.SubsectionsPerToneBox.Name = "SubsectionsPerToneBox";
      this.SubsectionsPerToneBox.Size = new System.Drawing.Size(100, 20);
      this.SubsectionsPerToneBox.TabIndex = 11;
      this.SubsectionsPerToneBox.Text = "8";
      this.SubsectionsPerToneBox.TextChanged += new System.EventHandler(this.SubsectionsPerToneBox_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(396, 34);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(112, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "Subsections Per Tone";
      // 
      // PowerBaseBox
      // 
      this.PowerBaseBox.Location = new System.Drawing.Point(527, 57);
      this.PowerBaseBox.Name = "PowerBaseBox";
      this.PowerBaseBox.Size = new System.Drawing.Size(100, 20);
      this.PowerBaseBox.TabIndex = 13;
      this.PowerBaseBox.Text = "1.5";
      this.PowerBaseBox.TextChanged += new System.EventHandler(this.PowerBaseBox_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(396, 60);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(64, 13);
      this.label5.TabIndex = 12;
      this.label5.Text = "Power Base";
      // 
      // CenterSubstractBox
      // 
      this.CenterSubstractBox.Location = new System.Drawing.Point(527, 83);
      this.CenterSubstractBox.Name = "CenterSubstractBox";
      this.CenterSubstractBox.Size = new System.Drawing.Size(100, 20);
      this.CenterSubstractBox.TabIndex = 15;
      this.CenterSubstractBox.Text = "0.4";
      this.CenterSubstractBox.TextChanged += new System.EventHandler(this.CenterSubstractBox_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(396, 86);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(86, 13);
      this.label6.TabIndex = 14;
      this.label6.Text = "Center Substract";
      // 
      // ResolutionBox
      // 
      this.ResolutionBox.Location = new System.Drawing.Point(820, 31);
      this.ResolutionBox.Name = "ResolutionBox";
      this.ResolutionBox.Size = new System.Drawing.Size(100, 20);
      this.ResolutionBox.TabIndex = 16;
      this.ResolutionBox.Text = "512";
      this.ResolutionBox.TextChanged += new System.EventHandler(this.ResolutionBox_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(745, 34);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(57, 13);
      this.label7.TabIndex = 17;
      this.label7.Text = "Resolution";
      // 
      // CoordXLabel
      // 
      this.CoordXLabel.AutoSize = true;
      this.CoordXLabel.Location = new System.Drawing.Point(129, 28);
      this.CoordXLabel.Name = "CoordXLabel";
      this.CoordXLabel.Size = new System.Drawing.Size(13, 13);
      this.CoordXLabel.TabIndex = 22;
      this.CoordXLabel.Text = "0";
      // 
      // CoordYLabel
      // 
      this.CoordYLabel.AutoSize = true;
      this.CoordYLabel.Location = new System.Drawing.Point(186, 27);
      this.CoordYLabel.Name = "CoordYLabel";
      this.CoordYLabel.Size = new System.Drawing.Size(13, 13);
      this.CoordYLabel.TabIndex = 23;
      this.CoordYLabel.Text = "0";
      // 
      // HideImageBox
      // 
      this.HideImageBox.AutoSize = true;
      this.HideImageBox.Location = new System.Drawing.Point(225, 27);
      this.HideImageBox.Name = "HideImageBox";
      this.HideImageBox.Size = new System.Drawing.Size(79, 17);
      this.HideImageBox.TabIndex = 24;
      this.HideImageBox.Text = "Hide image";
      this.HideImageBox.UseVisualStyleBackColor = true;
      // 
      // NoRedrawBox
      // 
      this.NoRedrawBox.AutoSize = true;
      this.NoRedrawBox.Location = new System.Drawing.Point(310, 27);
      this.NoRedrawBox.Name = "NoRedrawBox";
      this.NoRedrawBox.Size = new System.Drawing.Size(80, 17);
      this.NoRedrawBox.TabIndex = 25;
      this.NoRedrawBox.Text = "No Redraw";
      this.NoRedrawBox.UseVisualStyleBackColor = true;
      // 
      // GenerateSoundButton
      // 
      this.GenerateSoundButton.Location = new System.Drawing.Point(655, 60);
      this.GenerateSoundButton.Name = "GenerateSoundButton";
      this.GenerateSoundButton.Size = new System.Drawing.Size(75, 23);
      this.GenerateSoundButton.TabIndex = 26;
      this.GenerateSoundButton.Text = "Sound";
      this.GenerateSoundButton.UseVisualStyleBackColor = true;
      this.GenerateSoundButton.Click += new System.EventHandler(this.GenerateSoundButton_Click);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenTestFormButton,
            this.LoadImageButton});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(986, 25);
      this.toolStrip1.TabIndex = 28;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // OpenTestFormButton
      // 
      this.OpenTestFormButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.OpenTestFormButton.Image = ((System.Drawing.Image)(resources.GetObject("OpenTestFormButton.Image")));
      this.OpenTestFormButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.OpenTestFormButton.Name = "OpenTestFormButton";
      this.OpenTestFormButton.Size = new System.Drawing.Size(23, 22);
      this.OpenTestFormButton.ToolTipText = "Open Test Form";
      this.OpenTestFormButton.Click += new System.EventHandler(this.OpenTestForm_Click);
      // 
      // LoadImageButton
      // 
      this.LoadImageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.LoadImageButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadImageButton.Image")));
      this.LoadImageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.LoadImageButton.Name = "LoadImageButton";
      this.LoadImageButton.Size = new System.Drawing.Size(23, 22);
      this.LoadImageButton.Text = "Load Image";
      this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
      // 
      // UpdateTimer
      // 
      this.UpdateTimer.Enabled = true;
      this.UpdateTimer.Interval = 1;
      this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(0, 27);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(123, 13);
      this.label1.TabIndex = 29;
      this.label1.Text = "Picture Box Coordinates:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(0, 53);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(98, 13);
      this.label2.TabIndex = 30;
      this.label2.Text = "Image Coordinates:";
      // 
      // ImageCoordXLabel
      // 
      this.ImageCoordXLabel.AutoSize = true;
      this.ImageCoordXLabel.Location = new System.Drawing.Point(129, 56);
      this.ImageCoordXLabel.Name = "ImageCoordXLabel";
      this.ImageCoordXLabel.Size = new System.Drawing.Size(13, 13);
      this.ImageCoordXLabel.TabIndex = 31;
      this.ImageCoordXLabel.Text = "0";
      // 
      // ImageCoordYLabel
      // 
      this.ImageCoordYLabel.AutoSize = true;
      this.ImageCoordYLabel.Location = new System.Drawing.Point(186, 56);
      this.ImageCoordYLabel.Name = "ImageCoordYLabel";
      this.ImageCoordYLabel.Size = new System.Drawing.Size(13, 13);
      this.ImageCoordYLabel.TabIndex = 32;
      this.ImageCoordYLabel.Text = "0";
      // 
      // EyeWebTestForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(986, 555);
      this.Controls.Add(this.ImageCoordYLabel);
      this.Controls.Add(this.ImageCoordXLabel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.GenerateSoundButton);
      this.Controls.Add(this.NoRedrawBox);
      this.Controls.Add(this.HideImageBox);
      this.Controls.Add(this.CoordYLabel);
      this.Controls.Add(this.CoordXLabel);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.ResolutionBox);
      this.Controls.Add(this.CenterSubstractBox);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.PowerBaseBox);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.SubsectionsPerToneBox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.splitContainer1);
      this.Name = "EyeWebTestForm";
      this.Text = "Audio Eye";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.LeftBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RightBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MonoBox)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.PictureBox ImageBox;
    private System.Windows.Forms.PictureBox MonoBox;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.TextBox SubsectionsPerToneBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox PowerBaseBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox CenterSubstractBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox ResolutionBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label CoordXLabel;
    private System.Windows.Forms.Label CoordYLabel;
    private System.Windows.Forms.CheckBox HideImageBox;
    private System.Windows.Forms.CheckBox NoRedrawBox;
    private System.Windows.Forms.Button GenerateSoundButton;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PictureBox LeftBox;
    private System.Windows.Forms.PictureBox RightBox;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton OpenTestFormButton;
    private System.Windows.Forms.ToolStripButton LoadImageButton;
    private System.Windows.Forms.Timer UpdateTimer;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label ImageCoordXLabel;
    private System.Windows.Forms.Label ImageCoordYLabel;
  }
}

