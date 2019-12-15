using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class ImageEdit
  {
    public static StereoValue GetStereoValueOfArea(PointF[] shape, byte[] imageBytes, int width, int height, int leftBound, int rightBound)
    {
      float areaWidth = rightBound - leftBound;
      List<PositionValue> values = GetPositionValues(shape, imageBytes, width, height);

      if (values.Count == 0)
        return new StereoValue(0, 0, 0);

      float left = 0;
      float mono = 0; 
      float right = 0;

      foreach (PositionValue value in values)
      {
        mono += value.value;
        left += (rightBound - value.x) / areaWidth * value.value;
        right += (value.x - leftBound) / areaWidth * value.value;
      }

      return new StereoValue(left / values.Count, mono / values.Count, right / values.Count);
    }

    public static int GetMonoValueOfArea(PointF[] shape, byte[] imageBytes, int width, int height)
    {
      List<PositionValue> values = GetPositionValues(shape, imageBytes,  width,  height);
      int total = 0;
      foreach (PositionValue value in values)
        total += value.value;
      if (total == 0)
        return 0; 
      return total / values.Count; 
    }

    public static List<PositionValue> GetPositionValues(PointF[] shape, byte[] imageBytes, int width, int height)
    {
      if (shape == null)
        return new List<PositionValue>(); 
      int xMin = width;
      int yMin = height;
      int xMax = 0;
      int yMax = 0;
      foreach (PointF point in shape)
      {
        int xCeil = Convert.ToInt32(Math.Ceiling(point.X));
        int yCeil = Convert.ToInt32(Math.Ceiling(point.Y));
        int xFloor = Convert.ToInt32(Math.Floor(point.X));
        int yFloor = Convert.ToInt32(Math.Floor(point.Y));
        if (xFloor<xMin)
          xMin = xFloor;
        if (yFloor < yMin)
          yMin = yFloor;
        if (xCeil > xMax)
          xMax = xCeil;
        if (yCeil > yMax)
          yMax = yCeil; 
      }
      xMax++;
      yMax++;
      if (xMin < 0)
        xMin = 0;
      if (xMax > width)
        xMax = width;
      if (yMin < 0)
        yMin = 0;
      if (yMax > height)
        yMax = height;


      List<PositionValue> values = new List<PositionValue>(); 
      for (int y = yMin; y < yMax; y++)
      {
        int i = y * width + xMin;
        for (int x = xMin; x < xMax; x++, i++)
          if (IsInside(shape, x, y))
            values.Add(new PositionValue(x, imageBytes[i]));
      }

      return values; 
    }

    private static bool IsInside(PointF[] shape, int x, int y)
    {
      bool result = false;
      if (IsRight(x, y, shape[0], shape[1]))
        result = !result;
      if (IsRight(x, y, shape[1], shape[2]))
        result = !result;
      if (IsRight(x, y, shape[2], shape[3]))
        result = !result;
      if (IsRight(x, y, shape[3], shape[0]))
        result = !result;
      return result; 
    }

    private static bool IsRight(float x, float y, PointF source, PointF target)
    {
      //check if point is within the y range. 
      if (y <= source.Y && y < target.Y)
        return false;
      if (y >= source.Y && y > target.Y)
        return false;

      if (source.Y == target.Y)
      {
        //special case. 
        //only count as true, if the point is on the line, and not exactly on the tail. 
        //the tail should be seen as the "exit" of the line.
        //if it is on the tail, it will be on the head of another line.
        //so this check makes sure double counts are avoided. 
        if (x == source.X)
          return false;

        if (x < source.X && x < target.X)
          return false;

        if (x > source.X && x > target.X)
          return false;

        return true;
      }

      if (x < source.X && x < target.X)
        return false; //point is left. 

      if (x > source.X && x > target.X)
        return true; //point is right. 

      return x >= ((target.X - source.X) / (target.Y - source.Y)) * (y - source.Y) + source.X;

    }

    public static Bitmap MakeGrayscale(Image original)
    {
      //create a blank bitmap the same size as original
      Bitmap newBitmap = new Bitmap(original.Width, original.Height);

      //get a graphics object from the new image
      using (Graphics g = Graphics.FromImage(newBitmap))
      {

        //create the grayscale ColorMatrix
        ColorMatrix colorMatrix = new ColorMatrix(
           new float[][]
           {
             new float[] {.3f, .3f, .3f, 0, 0},
             new float[] {.59f, .59f, .59f, 0, 0},
             new float[] {.11f, .11f, .11f, 0, 0},
             new float[] {0, 0, 0, 1, 0},
             new float[] {0, 0, 0, 0, 1}
           });

        //create some image attributes
        using (ImageAttributes attributes = new ImageAttributes())
        {

          //set the color matrix attribute
          attributes.SetColorMatrix(colorMatrix);

          //draw the original image on the new image
          //using the grayscale color matrix
          g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
                      0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
        }
      }
      return newBitmap;
    }

    internal static byte[] GetIntensityBytesFrom(Bitmap greyScaleBitmap)
    {
      int bytesPerPixel; 
      switch (greyScaleBitmap.PixelFormat)
      {
        case PixelFormat.Format8bppIndexed:
          bytesPerPixel = 1;
          break;
        case PixelFormat.Format16bppGrayScale:
          bytesPerPixel = 2;
          break; 
        case PixelFormat.Format24bppRgb:
          bytesPerPixel = 3;
          break;
        case PixelFormat.Format32bppArgb:
        case PixelFormat.Format32bppPArgb:
          bytesPerPixel = 4;
          break;
        default:
          bytesPerPixel = 0;
          break;
      }

      var bitmapData = greyScaleBitmap.LockBits(new Rectangle(0, 0, greyScaleBitmap.Width, greyScaleBitmap.Height), ImageLockMode.ReadOnly, greyScaleBitmap.PixelFormat);

      var ptr = bitmapData.Scan0;
      var imageSize = bitmapData.Width * bitmapData.Height;
      
      var data = new byte[imageSize];
      for (int x = 0; x < imageSize; x++)
      {
        data[x] = Marshal.ReadByte(ptr);
        ptr += bytesPerPixel;
      }

      greyScaleBitmap.UnlockBits(bitmapData);

      //Debug(data, bitmapData.Width); 

      return data; 
    }

    private static void Debug(byte[] data, int width)
    {
      int height = data.Length / width;
      List<string> lines = new List<string>();
      int i = 0; 
      for (int y =0; y<height;y++)
      {
        string value = "";
        for (int x = 0; x < width; x++,i++)
          value += data[i].ToString() + "\t";
        lines.Add(value);
        
      }
      System.IO.File.WriteAllLines("D:\\debugGrey.txt", lines);
    }
  }

  public class StereoValue
  {
    public float left;
    public float mono;
    public float right; 
    public StereoValue(float left, float mono, float right)
    {
      this.left = left;
      this.mono = mono; 
      this.right = right; 
    }
  }

  public class PositionValue
  {
    public int x;
    public int value;
    public PositionValue(int x, int value)
    {
      this.x = x;
      this.value = value; 
    }

  }


}
