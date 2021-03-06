﻿//Copyright (C) Maarten 't Hart 22 december 2019
//GNU License 3 applies for this software. See readme.txt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class StereoImage
  {
    public GrayscaleImageData Left { get; }
    public GrayscaleImageData Right { get; }
    public GrayscaleImageData Mono { get; }

    public StereoImage(GrayscaleImageData mono)
    {
      Left = Right = Mono = mono; 
    }

    public StereoImage (GrayscaleImageData left, GrayscaleImageData right)
    {
      Left = Mono = left;
      Right = right; 
    }
  }
}
