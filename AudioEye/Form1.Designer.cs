namespace AudioEye
{
  partial class Form1
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
      this.label2 = new System.Windows.Forms.Label();
      this.DurationBox = new System.Windows.Forms.TextBox();
      this.PlayButton = new System.Windows.Forms.Button();
      this.NoteBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.OctaveBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
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
      this.label8 = new System.Windows.Forms.Label();
      this.TestXBox = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.TestYBox = new System.Windows.Forms.TextBox();
      this.CoordXLabel = new System.Windows.Forms.Label();
      this.CoordYLabel = new System.Windows.Forms.Label();
      this.HideImageBox = new System.Windows.Forms.CheckBox();
      this.NoRedrawBox = new System.Windows.Forms.CheckBox();
      this.GenerateSoundButton = new System.Windows.Forms.Button();
      this.TestExampleButton = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.LeftBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.RightBox)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.MonoBox)).BeginInit();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(12, 76);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Duration";
      // 
      // DurationBox
      // 
      this.DurationBox.Location = new System.Drawing.Point(85, 73);
      this.DurationBox.Name = "DurationBox";
      this.DurationBox.Size = new System.Drawing.Size(100, 20);
      this.DurationBox.TabIndex = 3;
      this.DurationBox.Text = "500";
      // 
      // PlayButton
      // 
      this.PlayButton.Location = new System.Drawing.Point(203, 18);
      this.PlayButton.Name = "PlayButton";
      this.PlayButton.Size = new System.Drawing.Size(100, 23);
      this.PlayButton.TabIndex = 4;
      this.PlayButton.Text = "Play Sound";
      this.PlayButton.UseVisualStyleBackColor = true;
      this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
      // 
      // NoteBox
      // 
      this.NoteBox.Location = new System.Drawing.Point(85, 47);
      this.NoteBox.Name = "NoteBox";
      this.NoteBox.Size = new System.Drawing.Size(100, 20);
      this.NoteBox.TabIndex = 2;
      this.NoteBox.Text = "0";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 50);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(30, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Note";
      // 
      // OctaveBox
      // 
      this.OctaveBox.Location = new System.Drawing.Point(85, 21);
      this.OctaveBox.Name = "OctaveBox";
      this.OctaveBox.Size = new System.Drawing.Size(100, 20);
      this.OctaveBox.TabIndex = 6;
      this.OctaveBox.Text = "4";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 24);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(42, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Octave";
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(309, 18);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 7;
      this.button1.Text = "Load Image";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.Button1_Click);
      // 
      // splitContainer1
      // 
      this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer1.Location = new System.Drawing.Point(15, 99);
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
      this.splitContainer1.Size = new System.Drawing.Size(960, 404);
      this.splitContainer1.SplitterDistance = 214;
      this.splitContainer1.TabIndex = 8;
      // 
      // ImageBox
      // 
      this.ImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.ImageBox.Location = new System.Drawing.Point(3, 3);
      this.ImageBox.Name = "ImageBox";
      this.ImageBox.Size = new System.Drawing.Size(954, 208);
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
      this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 184);
      this.tableLayoutPanel1.TabIndex = 2;
      // 
      // LeftBox
      // 
      this.LeftBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.LeftBox.Location = new System.Drawing.Point(3, 3);
      this.LeftBox.Name = "LeftBox";
      this.LeftBox.Size = new System.Drawing.Size(312, 178);
      this.LeftBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.LeftBox.TabIndex = 2;
      this.LeftBox.TabStop = false;
      // 
      // RightBox
      // 
      this.RightBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.RightBox.Location = new System.Drawing.Point(639, 3);
      this.RightBox.Name = "RightBox";
      this.RightBox.Size = new System.Drawing.Size(312, 178);
      this.RightBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.RightBox.TabIndex = 3;
      this.RightBox.TabStop = false;
      // 
      // MonoBox
      // 
      this.MonoBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.MonoBox.Location = new System.Drawing.Point(321, 3);
      this.MonoBox.Name = "MonoBox";
      this.MonoBox.Size = new System.Drawing.Size(312, 178);
      this.MonoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.MonoBox.TabIndex = 1;
      this.MonoBox.TabStop = false;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(655, 18);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 9;
      this.button2.Text = "Draw Web";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.Button2_Click);
      // 
      // SubsectionsPerToneBox
      // 
      this.SubsectionsPerToneBox.Location = new System.Drawing.Point(527, 21);
      this.SubsectionsPerToneBox.Name = "SubsectionsPerToneBox";
      this.SubsectionsPerToneBox.Size = new System.Drawing.Size(100, 20);
      this.SubsectionsPerToneBox.TabIndex = 11;
      this.SubsectionsPerToneBox.Text = "8";
      this.SubsectionsPerToneBox.TextChanged += new System.EventHandler(this.SubsectionsPerToneBox_TextChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(396, 24);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(112, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "Subsections Per Tone";
      // 
      // PowerBaseBox
      // 
      this.PowerBaseBox.Location = new System.Drawing.Point(527, 47);
      this.PowerBaseBox.Name = "PowerBaseBox";
      this.PowerBaseBox.Size = new System.Drawing.Size(100, 20);
      this.PowerBaseBox.TabIndex = 13;
      this.PowerBaseBox.Text = "1.5";
      this.PowerBaseBox.TextChanged += new System.EventHandler(this.PowerBaseBox_TextChanged);
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(396, 50);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(64, 13);
      this.label5.TabIndex = 12;
      this.label5.Text = "Power Base";
      // 
      // CenterSubstractBox
      // 
      this.CenterSubstractBox.Location = new System.Drawing.Point(527, 73);
      this.CenterSubstractBox.Name = "CenterSubstractBox";
      this.CenterSubstractBox.Size = new System.Drawing.Size(100, 20);
      this.CenterSubstractBox.TabIndex = 15;
      this.CenterSubstractBox.Text = "0.4";
      this.CenterSubstractBox.TextChanged += new System.EventHandler(this.CenterSubstractBox_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(396, 76);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(86, 13);
      this.label6.TabIndex = 14;
      this.label6.Text = "Center Substract";
      // 
      // ResolutionBox
      // 
      this.ResolutionBox.Location = new System.Drawing.Point(820, 21);
      this.ResolutionBox.Name = "ResolutionBox";
      this.ResolutionBox.Size = new System.Drawing.Size(100, 20);
      this.ResolutionBox.TabIndex = 16;
      this.ResolutionBox.Text = "512";
      this.ResolutionBox.TextChanged += new System.EventHandler(this.ResolutionBox_TextChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(745, 24);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(57, 13);
      this.label7.TabIndex = 17;
      this.label7.Text = "Resolution";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(745, 46);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(35, 13);
      this.label8.TabIndex = 19;
      this.label8.Text = "TestX";
      // 
      // TestXBox
      // 
      this.TestXBox.Location = new System.Drawing.Point(820, 43);
      this.TestXBox.Name = "TestXBox";
      this.TestXBox.Size = new System.Drawing.Size(100, 20);
      this.TestXBox.TabIndex = 18;
      this.TestXBox.Text = "600";
      this.TestXBox.TextChanged += new System.EventHandler(this.TestXBox_TextChanged);
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(745, 69);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(35, 13);
      this.label9.TabIndex = 21;
      this.label9.Text = "TestY";
      // 
      // TestYBox
      // 
      this.TestYBox.Location = new System.Drawing.Point(820, 66);
      this.TestYBox.Name = "TestYBox";
      this.TestYBox.Size = new System.Drawing.Size(100, 20);
      this.TestYBox.TabIndex = 20;
      this.TestYBox.Text = "700";
      this.TestYBox.TextChanged += new System.EventHandler(this.TestYBox_TextChanged);
      // 
      // CoordXLabel
      // 
      this.CoordXLabel.AutoSize = true;
      this.CoordXLabel.Location = new System.Drawing.Point(200, 54);
      this.CoordXLabel.Name = "CoordXLabel";
      this.CoordXLabel.Size = new System.Drawing.Size(13, 13);
      this.CoordXLabel.TabIndex = 22;
      this.CoordXLabel.Text = "0";
      // 
      // CoordYLabel
      // 
      this.CoordYLabel.AutoSize = true;
      this.CoordYLabel.Location = new System.Drawing.Point(200, 73);
      this.CoordYLabel.Name = "CoordYLabel";
      this.CoordYLabel.Size = new System.Drawing.Size(13, 13);
      this.CoordYLabel.TabIndex = 23;
      this.CoordYLabel.Text = "0";
      // 
      // HideImageBox
      // 
      this.HideImageBox.AutoSize = true;
      this.HideImageBox.Location = new System.Drawing.Point(242, 50);
      this.HideImageBox.Name = "HideImageBox";
      this.HideImageBox.Size = new System.Drawing.Size(79, 17);
      this.HideImageBox.TabIndex = 24;
      this.HideImageBox.Text = "Hide image";
      this.HideImageBox.UseVisualStyleBackColor = true;
      // 
      // NoRedrawBox
      // 
      this.NoRedrawBox.AutoSize = true;
      this.NoRedrawBox.Location = new System.Drawing.Point(242, 69);
      this.NoRedrawBox.Name = "NoRedrawBox";
      this.NoRedrawBox.Size = new System.Drawing.Size(80, 17);
      this.NoRedrawBox.TabIndex = 25;
      this.NoRedrawBox.Text = "No Redraw";
      this.NoRedrawBox.UseVisualStyleBackColor = true;
      // 
      // GenerateSoundButton
      // 
      this.GenerateSoundButton.Location = new System.Drawing.Point(655, 50);
      this.GenerateSoundButton.Name = "GenerateSoundButton";
      this.GenerateSoundButton.Size = new System.Drawing.Size(75, 23);
      this.GenerateSoundButton.TabIndex = 26;
      this.GenerateSoundButton.Text = "Sound";
      this.GenerateSoundButton.UseVisualStyleBackColor = true;
      this.GenerateSoundButton.Click += new System.EventHandler(this.GenerateSoundButton_Click);
      // 
      // TestExampleButton
      // 
      this.TestExampleButton.Location = new System.Drawing.Point(655, 79);
      this.TestExampleButton.Name = "TestExampleButton";
      this.TestExampleButton.Size = new System.Drawing.Size(75, 23);
      this.TestExampleButton.TabIndex = 27;
      this.TestExampleButton.Text = "Test Example";
      this.TestExampleButton.UseVisualStyleBackColor = true;
      this.TestExampleButton.Click += new System.EventHandler(this.TestExampleButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(987, 515);
      this.Controls.Add(this.TestExampleButton);
      this.Controls.Add(this.GenerateSoundButton);
      this.Controls.Add(this.NoRedrawBox);
      this.Controls.Add(this.HideImageBox);
      this.Controls.Add(this.CoordYLabel);
      this.Controls.Add(this.CoordXLabel);
      this.Controls.Add(this.label9);
      this.Controls.Add(this.TestYBox);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.TestXBox);
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
      this.Controls.Add(this.button1);
      this.Controls.Add(this.OctaveBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.PlayButton);
      this.Controls.Add(this.DurationBox);
      this.Controls.Add(this.NoteBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.LeftBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.RightBox)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.MonoBox)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox DurationBox;
    private System.Windows.Forms.Button PlayButton;
    private System.Windows.Forms.TextBox NoteBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox OctaveBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button1;
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
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox TestXBox;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox TestYBox;
    private System.Windows.Forms.Label CoordXLabel;
    private System.Windows.Forms.Label CoordYLabel;
    private System.Windows.Forms.CheckBox HideImageBox;
    private System.Windows.Forms.CheckBox NoRedrawBox;
    private System.Windows.Forms.Button GenerateSoundButton;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.PictureBox LeftBox;
    private System.Windows.Forms.PictureBox RightBox;
    private System.Windows.Forms.Button TestExampleButton;
  }
}

