namespace AudioEye
{
  partial class TestForm
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
      this.OctaveBox = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.PlayButton = new System.Windows.Forms.Button();
      this.DurationBox = new System.Windows.Forms.TextBox();
      this.NoteBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.GenerateWaveButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // OctaveBox
      // 
      this.OctaveBox.Location = new System.Drawing.Point(98, 12);
      this.OctaveBox.Name = "OctaveBox";
      this.OctaveBox.Size = new System.Drawing.Size(100, 20);
      this.OctaveBox.TabIndex = 20;
      this.OctaveBox.Text = "4";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(25, 15);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(42, 13);
      this.label3.TabIndex = 19;
      this.label3.Text = "Octave";
      // 
      // PlayButton
      // 
      this.PlayButton.Location = new System.Drawing.Point(216, 9);
      this.PlayButton.Name = "PlayButton";
      this.PlayButton.Size = new System.Drawing.Size(100, 23);
      this.PlayButton.TabIndex = 18;
      this.PlayButton.Text = "Play Beep";
      this.PlayButton.UseVisualStyleBackColor = true;
      this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
      // 
      // DurationBox
      // 
      this.DurationBox.Location = new System.Drawing.Point(98, 64);
      this.DurationBox.Name = "DurationBox";
      this.DurationBox.Size = new System.Drawing.Size(100, 20);
      this.DurationBox.TabIndex = 17;
      this.DurationBox.Text = "500";
      // 
      // NoteBox
      // 
      this.NoteBox.Location = new System.Drawing.Point(98, 38);
      this.NoteBox.Name = "NoteBox";
      this.NoteBox.Size = new System.Drawing.Size(100, 20);
      this.NoteBox.TabIndex = 16;
      this.NoteBox.Text = "0";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(25, 67);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(47, 13);
      this.label2.TabIndex = 15;
      this.label2.Text = "Duration";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(25, 41);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(30, 13);
      this.label1.TabIndex = 14;
      this.label1.Text = "Note";
      // 
      // GenerateWaveButton
      // 
      this.GenerateWaveButton.Location = new System.Drawing.Point(216, 41);
      this.GenerateWaveButton.Name = "GenerateWaveButton";
      this.GenerateWaveButton.Size = new System.Drawing.Size(100, 23);
      this.GenerateWaveButton.TabIndex = 21;
      this.GenerateWaveButton.Text = "Generate Wave";
      this.GenerateWaveButton.UseVisualStyleBackColor = true;
      this.GenerateWaveButton.Click += new System.EventHandler(this.GenerateWaveButton_Click);
      // 
      // TestForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.GenerateWaveButton);
      this.Controls.Add(this.OctaveBox);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.PlayButton);
      this.Controls.Add(this.DurationBox);
      this.Controls.Add(this.NoteBox);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Name = "TestForm";
      this.Text = "TestForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TextBox OctaveBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button PlayButton;
    private System.Windows.Forms.TextBox DurationBox;
    private System.Windows.Forms.TextBox NoteBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button GenerateWaveButton;
  }
}