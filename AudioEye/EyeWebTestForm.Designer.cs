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
      this.label9 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.MonoBox = new System.Windows.Forms.PictureBox();
      this.RightBox = new System.Windows.Forms.PictureBox();
      this.LeftBox = new System.Windows.Forms.PictureBox();
      this.label3 = new System.Windows.Forms.Label();
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
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.LoadImageButton = new System.Windows.Forms.ToolStripButton();
      this.OpenTestFormButton = new System.Windows.Forms.ToolStripButton();
      this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ImageCoordXLabel = new System.Windows.Forms.Label();
      this.ImageCoordYLabel = new System.Windows.Forms.Label();
      this.OriginalBox = new System.Windows.Forms.CheckBox();
      this.label10 = new System.Windows.Forms.Label();
      this.AmplitudeLeftBox = new System.Windows.Forms.TextBox();
      this.label11 = new System.Windows.Forms.Label();
      this.AmplitudeMonoBox = new System.Windows.Forms.TextBox();
      this.label12 = new System.Windows.Forms.Label();
      this.AmplitudeRightBox = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MonoBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RightBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.LeftBox)).BeginInit();
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
      this.tableLayoutPanel1.Controls.Add(this.label9, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.label8, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.MonoBox, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.RightBox, 2, 1);
      this.tableLayoutPanel1.Controls.Add(this.LeftBox, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(3, -1);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(953, 200);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // label9
      // 
      this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(637, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(313, 13);
      this.label9.TabIndex = 6;
      this.label9.Text = "Right";
      this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label8
      // 
      this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(320, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(311, 13);
      this.label8.TabIndex = 5;
      this.label8.Text = "Mono";
      this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // MonoBox
      // 
      this.MonoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.MonoBox.Location = new System.Drawing.Point(320, 23);
      this.MonoBox.Name = "MonoBox";
      this.MonoBox.Size = new System.Drawing.Size(311, 174);
      this.MonoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.MonoBox.TabIndex = 1;
      this.MonoBox.TabStop = false;
      // 
      // RightBox
      // 
      this.RightBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.RightBox.Location = new System.Drawing.Point(637, 23);
      this.RightBox.Name = "RightBox";
      this.RightBox.Size = new System.Drawing.Size(313, 174);
      this.RightBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.RightBox.TabIndex = 3;
      this.RightBox.TabStop = false;
      // 
      // LeftBox
      // 
      this.LeftBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LeftBox.Location = new System.Drawing.Point(3, 23);
      this.LeftBox.Name = "LeftBox";
      this.LeftBox.Size = new System.Drawing.Size(311, 174);
      this.LeftBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.LeftBox.TabIndex = 2;
      this.LeftBox.TabStop = false;
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(3, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(311, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Left";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // SubsectionsPerToneBox
      // 
      this.SubsectionsPerToneBox.Location = new System.Drawing.Point(438, 27);
      this.SubsectionsPerToneBox.Name = "SubsectionsPerToneBox";
      this.SubsectionsPerToneBox.Size = new System.Drawing.Size(100, 20);
      this.SubsectionsPerToneBox.TabIndex = 11;
      this.SubsectionsPerToneBox.Text = "8";
      this.SubsectionsPerToneBox.TextChanged += new System.EventHandler(this.SubsectionsPerToneBox_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(307, 30);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(112, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "Subsections Per Tone";
      // 
      // PowerBaseBox
      // 
      this.PowerBaseBox.Location = new System.Drawing.Point(438, 53);
      this.PowerBaseBox.Name = "PowerBaseBox";
      this.PowerBaseBox.Size = new System.Drawing.Size(100, 20);
      this.PowerBaseBox.TabIndex = 13;
      this.PowerBaseBox.Text = "1.5";
      this.PowerBaseBox.TextChanged += new System.EventHandler(this.PowerBaseBox_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(307, 56);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(64, 13);
      this.label5.TabIndex = 12;
      this.label5.Text = "Power Base";
      // 
      // CenterSubstractBox
      // 
      this.CenterSubstractBox.Location = new System.Drawing.Point(438, 79);
      this.CenterSubstractBox.Name = "CenterSubstractBox";
      this.CenterSubstractBox.Size = new System.Drawing.Size(100, 20);
      this.CenterSubstractBox.TabIndex = 15;
      this.CenterSubstractBox.Text = "0.4";
      this.CenterSubstractBox.TextChanged += new System.EventHandler(this.CenterSubstractBox_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(307, 82);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(86, 13);
      this.label6.TabIndex = 14;
      this.label6.Text = "Center Substract";
      // 
      // ResolutionBox
      // 
      this.ResolutionBox.Location = new System.Drawing.Point(641, 30);
      this.ResolutionBox.Name = "ResolutionBox";
      this.ResolutionBox.Size = new System.Drawing.Size(100, 20);
      this.ResolutionBox.TabIndex = 16;
      this.ResolutionBox.Text = "512";
      this.ResolutionBox.TextChanged += new System.EventHandler(this.ResolutionBox_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(566, 33);
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
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadImageButton,
            this.OpenTestFormButton});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(986, 25);
      this.toolStrip1.TabIndex = 28;
      this.toolStrip1.Text = "toolStrip1";
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
      // OriginalBox
      // 
      this.OriginalBox.AutoSize = true;
      this.OriginalBox.Checked = true;
      this.OriginalBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.OriginalBox.Location = new System.Drawing.Point(229, 29);
      this.OriginalBox.Name = "OriginalBox";
      this.OriginalBox.Size = new System.Drawing.Size(61, 17);
      this.OriginalBox.TabIndex = 33;
      this.OriginalBox.Text = "Original";
      this.OriginalBox.UseVisualStyleBackColor = true;
      this.OriginalBox.CheckedChanged += new System.EventHandler(this.OriginalBox_CheckedChanged);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(776, 34);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(77, 13);
      this.label10.TabIndex = 36;
      this.label10.Text = "Amplitude Left:";
      // 
      // AmplitudeLeftBox
      // 
      this.AmplitudeLeftBox.Location = new System.Drawing.Point(868, 30);
      this.AmplitudeLeftBox.Name = "AmplitudeLeftBox";
      this.AmplitudeLeftBox.Size = new System.Drawing.Size(100, 20);
      this.AmplitudeLeftBox.TabIndex = 35;
      this.AmplitudeLeftBox.Text = "1";
      this.AmplitudeLeftBox.TextChanged += new System.EventHandler(this.AmplitudeLeftBox_TextChanged);
      // 
      // label11
      // 
      this.label11.AutoSize = true;
      this.label11.Location = new System.Drawing.Point(776, 60);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(86, 13);
      this.label11.TabIndex = 38;
      this.label11.Text = "Amplitude Mono:";
      // 
      // AmplitudeMonoBox
      // 
      this.AmplitudeMonoBox.Location = new System.Drawing.Point(868, 56);
      this.AmplitudeMonoBox.Name = "AmplitudeMonoBox";
      this.AmplitudeMonoBox.Size = new System.Drawing.Size(100, 20);
      this.AmplitudeMonoBox.TabIndex = 37;
      this.AmplitudeMonoBox.Text = "1";
      this.AmplitudeMonoBox.TextChanged += new System.EventHandler(this.AmplitudeMonoBox_TextChanged);
      // 
      // label12
      // 
      this.label12.AutoSize = true;
      this.label12.Location = new System.Drawing.Point(776, 86);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(84, 13);
      this.label12.TabIndex = 40;
      this.label12.Text = "Amplitude Right:";
      // 
      // AmplitudeRightBox
      // 
      this.AmplitudeRightBox.Location = new System.Drawing.Point(868, 82);
      this.AmplitudeRightBox.Name = "AmplitudeRightBox";
      this.AmplitudeRightBox.Size = new System.Drawing.Size(100, 20);
      this.AmplitudeRightBox.TabIndex = 39;
      this.AmplitudeRightBox.Text = "1";
      this.AmplitudeRightBox.TextChanged += new System.EventHandler(this.AmplitudeRightBox_TextChanged);
      // 
      // EyeWebTestForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(986, 555);
      this.Controls.Add(this.label12);
      this.Controls.Add(this.AmplitudeRightBox);
      this.Controls.Add(this.label11);
      this.Controls.Add(this.AmplitudeMonoBox);
      this.Controls.Add(this.label10);
      this.Controls.Add(this.AmplitudeLeftBox);
      this.Controls.Add(this.OriginalBox);
      this.Controls.Add(this.ImageCoordYLabel);
      this.Controls.Add(this.ImageCoordXLabel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.toolStrip1);
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
      this.Controls.Add(this.splitContainer1);
      this.Name = "EyeWebTestForm";
      this.Text = "Audio Eye";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.MonoBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RightBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.LeftBox)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.PictureBox ImageBox;
    private System.Windows.Forms.PictureBox MonoBox;
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
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox OriginalBox;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox AmplitudeLeftBox;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox AmplitudeMonoBox;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox AmplitudeRightBox;
  }
}

