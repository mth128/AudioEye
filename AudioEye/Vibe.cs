﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class Vibe
  {
    public int octave = 4;//between 0 and 6. 
    public int note = 0; //between 0 and 11. 

    public int Tone => (octave + 2) * 12 + note;
    public double FrequencyD => 16.35 * Math.Pow(2, Tone / 12.0);
    public int SystemNote => Clamp(  Convert.ToInt32(FrequencyD),37,32000); 
    
    public Vibe(int octave, int note)
    {
      this.octave = octave;
      this.note = note; 
    }

    public int Clamp (int value, int min, int max)
    {
      if (value < min)
        return min;
      if (value > max)
        return max;
      return value; 
    }



  }
}
