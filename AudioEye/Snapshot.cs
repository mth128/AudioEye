using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{

  /// <summary>
  /// A snapshot is a set of 3 arrays. Each array holds a single intensityvalue for each shape in an eyeweb.
  /// Based on this both the output images and the sound can be produced. 
  /// </summary>
  public class Snapshot
  {
    public int[] Left { get; private set; }
    public int[] Mono { get; private set; }
    public int[] Right { get; private set; }

    public Snapshot(StereoImage stereoImage, EyeWeb eyeWeb, int centerX, int centerY)
    {
      int resolution = eyeWeb.Resolution; 
      int halfResolution = resolution/2;
      int left = centerX - halfResolution;
      int top = centerY - halfResolution; 
      Parallel.For(0, 3, i =>
        {
          switch(i)
          {
            case 0:              
              Left = eyeWeb.GetSnapshot(stereoImage.Left.GetIntensities(left, top, resolution, resolution), true, false); 
              break;
            case 1:
              Mono = eyeWeb.GetSnapshot(stereoImage.Mono.GetIntensities(left, top, resolution, resolution), false, false);
              break;
            case 2:
              Right = eyeWeb.GetSnapshot(stereoImage.Right.GetIntensities(left, top, resolution, resolution), false, true);
              break;
          }
        });
    }
  }
}
