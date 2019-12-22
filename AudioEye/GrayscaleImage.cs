//Copyright (C) Maarten 't Hart 22 december 2019
//GNU License 3 applies for this software. See readme.txt
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class GrayscaleImageData
  {
    private byte[] data;
    public int Width { get; }
    public int Height { get; }

    public GrayscaleImageData(Image image)
    {
      using (Bitmap grayScaleImage = ImageEdit.MakeGrayscale(image))
        data = ImageEdit.GetIntensityBytesFrom(grayScaleImage);
      Width = image.Width;
      Height = image.Height; 
    }

    public byte GetIntensity(int x, int y)
    {
      if (x < 0 || x >= Width || y < 0 || y >= Height)
        return 0;
      return data[y * Width + x];
    }

    public byte[] GetIntensities(int left, int top, int width, int height)
    {
      int size = width * height;
      byte[] result = new byte[size];
      int i = 0;
      
      for (int y = 0; y < height; y++)
        for (int x = 0; x < width; x++, i++)
          result[i] = GetIntensity(x+left, y+top);
      return result; 
    }

  }
}
