using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SolarSystem
{
  public partial class TextBoxTrackBar : UserControl
  {
    private bool quadratic = false;
    private bool fourthPower = false; 
    private double minimum = 0;
    private double maximum = 10;
    private double value = 0;

    public event EventHandler ValueChanged; 

    public bool Quadratic {
      get => quadratic;
      set
      {
        quadratic = value;
        if (quadratic)
          fourthPower = false; 
        SetTrackBar(); 
      }
    }
    public bool FourthPower
    {
      get => fourthPower;
      set
      {
        fourthPower = value;
        if (fourthPower)
          quadratic = false;
        SetTrackBar(); 
      }
    }
    public bool ForceInteger { get; set; } = false; 
    public bool AllowOutOfBounds { get; set; } = true; 
    public string Title { get => TitleLabel.Text; set =>TitleLabel.Text = value; }
    public double Minimum {
      get => minimum;
      set
      {
        minimum = value;
        SetTrackBar(); 
      }
    }

    public double Maximum
    {
      get => maximum;
      set
      {
        maximum = value;
        SetTrackBar();
      }
    }

    public double Value
    {
      get => double.IsNaN(value)? value = 0: value;
      set
      {
        if (ForceInteger)
          value = Math.Round(value);

        this.value = value;
        SetTrackBar();
        TextBox.Text = this.value.ToString();
        ValueChanged(this, new EventArgs()); 
      }
    }

    public TextBoxTrackBar()
    {
      ValueChanged += DoNothing;
      InitializeComponent();
    }

    private void DoNothing(object sender, EventArgs e)
    {
    }

    private void SetTrackBar()
    {
      double position = (Value - minimum) / (maximum - minimum);

      if (Quadratic)
        position = Math.Sqrt(position);

      if (FourthPower)
      {
        position = Math.Sqrt(position);
        position = Math.Sqrt(position); 
      }

      position *= 1000; 

      if (position < 0)
        position = 0;
      if (position > 1000)
        position = 1000;
      int trackBarValue = Convert.ToInt32(position);
      TrackBar.Value = trackBarValue; 
    }

    private void TextBox_Leave(object sender, EventArgs e)
    {
      ValueFromTextBox();
    }

    private void ValueFromTextBox()
    {
      try
      {
        double value = Convert.ToDouble(TextBox.Text);
        if (!AllowOutOfBounds)
        {
          if (value < Minimum)
            value = minimum;
          if (value > Maximum)
            value = maximum;
        }
        Value = value; 
      }
      catch
      {
        Value = Value; 
      }
    }

    private void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
        ValueFromTextBox(); 
    }

    private void TrackBar_Scroll(object sender, EventArgs e)
    {
      double Position = TrackBar.Value / 1000.0;
      if (quadratic)
        Position *= Position; 
      if (fourthPower)
      {
        Position *= Position;
        Position *= Position;
      }
      Value = Minimum + (Maximum - Minimum) * Position; 
    }
  }
}
