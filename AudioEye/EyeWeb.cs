using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class EyeWeb
  {
    public readonly float extent = 0;
    public readonly List<EyeWebShape> shapes = new List<EyeWebShape>();
    public int Resolution { get; }

    /// <summary>
    /// A square of resolution * resolution that says in which square the pixels are. 
    /// </summary>
    public int[] PointShapeIndex { get; }
    public int[] PointShapeIndexCounter { get; }

    public EyeWeb(int subsectionsPerTone = 1, float powerBase = 1.8f, float centerSubstract = 0.5f, int resolution = 512)
    {
      this.Resolution = resolution;
      double toneWidth = 1.0 / subsectionsPerTone;
      for (int i = 0; i < 84; i++)
      {
        for (int j = 0; j < subsectionsPerTone; j++)
        {
          EyeWebShape shape = new EyeWebShape(i + j * toneWidth, toneWidth, powerBase, centerSubstract);

          shapes.Add(shape);
          foreach (EyeWebCoordinate coordinate in shape.coordinates)
          {
            if (Math.Abs(coordinate.x) > extent)
              extent = Math.Abs(coordinate.x);
            if (Math.Abs(coordinate.y) > extent)
              extent = Math.Abs(coordinate.y);
          }

        }
      }
      foreach (EyeWebShape shape in shapes)
        shape.BuildTargetPoints(extent, Resolution);


      //Generating PointShapeIndex.
      int squareSize = resolution * resolution;
      PointShapeIndex = new int[squareSize];
      for (int i = 0; i < squareSize; i++)
        PointShapeIndex[i] = -1;

      PointShapeIndexCounter = new int[shapes.Count];

      int halfResolution = resolution / 2;

      List<Polygon> polygons = new List<Polygon>();
      for (int i = 0; i < shapes.Count; i++)
        polygons.Add(new Polygon(GetPoints(i, resolution, halfResolution, halfResolution)));

      for (int y = 0; y < resolution; y++)
        for (int x = 0; x < resolution; x++)
        {
          for (int shapeIndex = shapes.Count - 1; shapeIndex >= 0; shapeIndex--)
          {
            if (polygons[shapeIndex].IsInside(x, y))
            {
              int index = y * resolution + x;
              PointShapeIndex[index] = shapeIndex;
              PointShapeIndexCounter[shapeIndex]++;
              break;
            }
          }
        }
    }

    public int[] GetSnapshot(byte[] grayscaleIndex, bool left, bool right)
    {
      int x = 0;
      int size = PointShapeIndex.Length;
      long[] intensitiesLong = new long[shapes.Count];

      for (int i = 0; i < size; i++, x++)
      {
        if (x >= Resolution)
          x = 0;
        int shapeIndex = PointShapeIndex[i];
        if (shapeIndex == -1)
          continue;

        int intensity = grayscaleIndex[i];

        if (left)
          intensitiesLong[shapeIndex] += intensity * (Resolution - x);
        else if (right)
          intensitiesLong[shapeIndex] += intensity * x;
        else intensitiesLong[shapeIndex] += intensity * Resolution;
      }
      int[] intensities = new int[shapes.Count]; 
      for (int s = 0; s < shapes.Count; s++)
      {
        int devisor = Resolution * PointShapeIndexCounter[s];
        if (devisor == 0)
          intensities[s] = 0;
        else
          intensities[s] = (int)(intensitiesLong[s]/devisor);
      }
      return intensities;
    }

    public PointF[] GetPoints(int shapeIndex, float resolution, float centerX, float centerY)
    {
      return shapes[shapeIndex].TransformPoints(extent, resolution, centerX, centerY);
    }

    /*
    /// <summary>
    /// returns an amplitude between -1 and 1. 
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public float GetMonoAmplitude(double time)
    {
      float total = 0;
      foreach (EyeWebShape shape in shapes)
        total += shape.soundWave.GetAmplitude(time, shape.tintMono);
      return total / shapes.Count / 256;
    }*/

  
    public Bitmap DrawOn(Image image, Point center, bool clear = false)
    {
      if (image == null)
        return null;

      List<PointF[]> sourcePoints = new List<PointF[]>(); 

      for (int i = 0; i < shapes.Count; i++)
      {
        PointF[] points = GetPoints(i, Resolution, center.X, center.Y);
        sourcePoints.Add(points);
      }

      Bitmap bitmap;
      if (clear)
        bitmap = new Bitmap(image.Width, image.Height);
      else
        bitmap = new Bitmap(image);
      using (Graphics graphics = Graphics.FromImage(bitmap))
      {
        //Draw the connecting lines.
        using (Pen pen = new Pen(Color.Red))
        {
          for (int i = 0; i < shapes.Count; i++)
            graphics.DrawPolygon(pen, sourcePoints[i]);
        }
      }
      return bitmap;
    }
    

    internal Bitmap DrawSnapshot(int[] intensities)
    {
      Bitmap bitmap = new Bitmap(Resolution, Resolution);
      using (Graphics graphics = Graphics.FromImage(bitmap))
      {
        graphics.Clear(Color.DarkBlue);

        for (int i =0; i<shapes.Count;i++)
        {
          EyeWebShape shape = shapes[i];
          int tint = intensities[i]; 
          if (tint<0)
            tint = 0;
          if (tint > 255)
            tint = 255; 

          using (Brush brush = new SolidBrush(Color.FromArgb(tint, tint, tint)))
            graphics.FillPolygon(brush, shape.targetPoints);
        }
      }
      return bitmap; 
    }
  }

  public class EyeWebShape
  {
    public EyeWebCoordinate[] coordinates;
    public PointF[] targetPoints;
    public double tone;
    public SoundWave soundWave;

    public EyeWebShape(double tone, double toneWidth = 1, float powerBase = 1.8f, float centerSubstract = 0.5f)
    {
      coordinates = new EyeWebCoordinate[4];
      coordinates[0] = new EyeWebCoordinate(tone, powerBase, centerSubstract);
      coordinates[1] = new EyeWebCoordinate(tone + toneWidth, powerBase, centerSubstract);
      coordinates[2] = new EyeWebCoordinate(tone + 12 + toneWidth, powerBase, centerSubstract);
      coordinates[3] = new EyeWebCoordinate(tone + 12, powerBase, centerSubstract);
      this.tone = tone;
      soundWave = new SoundWave(tone);
    }

    internal void BuildTargetPoints(float extent, int resolution)
    {
      targetPoints = new PointF[4];
      for (int i = 0; i < 4; i++)
        targetPoints[i] = coordinates[i].PointF(extent, resolution); 
    }

    public override string ToString()
    {
      return coordinates[0].ToString() + " \n" + coordinates[1].ToString() + " \n" +
        coordinates[2].ToString() + " \n" + coordinates[3].ToString();
    }
    public PointF[] TransformPoints(float extent, float resolution, float centerX, float centerY)
    {
      PointF[] points = new PointF[4];
      for (int i = 0; i < 4; i++)
        points[i] = coordinates[i].TransformPoint(extent, resolution, centerX, centerY);
      return points;
    }
  }

  public class EyeWebCoordinate
  {
    private static int octaves = 7;
    public float x;
    public float y;

    public EyeWebCoordinate(double tone, float powerBase = 1.8f, float centerSubstract = 0.5f, bool flipHorizontal = false, bool flipVertical = true)
    {
      double inverse = (octaves * 12) - tone;
      if (inverse < 0)
      {
        x = 0;
        y = 0;
        return;
      }

      double sigma = (tone) / 6.0 * Math.PI;
      double cos = Math.Cos(sigma);
      double sin = Math.Sin(sigma);
      if (flipHorizontal)
        cos = -cos;
      if (flipVertical)
        sin = -sin; 
      double length = Math.Pow(powerBase, inverse / 12.0) - centerSubstract;

      x = Convert.ToSingle(cos * length);
      y = Convert.ToSingle(sin * length);

    }

    public PointF TransformPoint(float extent, float resolution, float centerX, float centerY)
    {
      float px = x / (2 * extent) * resolution + centerX;
      float py = -y / (2 * extent) * resolution + centerY;
      return new PointF(px, py);
    }

    internal PointF PointF(float extent, float resolution)
    {
      float px = (this.x + extent) / (2 * extent);
      float py = 1 - ((this.y + extent) / (2 * extent));

      return new PointF(px * resolution, py * resolution);
    }

    public override string ToString()
    {
      string xString = x.ToString();
      if (xString.Length < 10 && !xString.Contains("E") && !xString.Contains("e"))
      {
        if (!xString.Contains("."))
          xString += ".";
        while (xString.Length < 10)
        {
          xString += "0";
        }
      }
      string yString = y.ToString();
      if (yString.Length < 10 && !yString.Contains("E") && !yString.Contains("e"))
      {
        if (!yString.Contains("."))
          yString += ".";
        while (yString.Length < 10)
        {
          yString += "0";
        }
      }
      return xString + " " + yString;
    }
  }

  public class Polygon
  {
    int minX;
    int minY;
    int maxX;
    int maxY;
    PointF[] points; 
    public Polygon(PointF[] points)
    {
      minX = Convert.ToInt32(Math.Floor(points[0].X));
      minY = Convert.ToInt32(Math.Floor(points[0].Y));
      maxX = Convert.ToInt32(Math.Ceiling(points[0].X));
      maxY = Convert.ToInt32(Math.Ceiling(points[0].Y));

      foreach (PointF point in points)
      {
        if (minX > point.X)
          minX = Convert.ToInt32(Math.Floor(point.X));
        if (minY > point.Y)
          minY = Convert.ToInt32(Math.Floor(point.Y));
        if (maxX < point.X)
          maxX = Convert.ToInt32(Math.Ceiling(point.X));
        if (maxY < point.Y)
          maxY = Convert.ToInt32(Math.Ceiling(point.Y));
      }

      this.points = points;
    }

    internal bool IsInside(int x, int y)
    {
      if (x < minX || x > maxX|| y<minY || y>maxY)
        return false;

      return ImageEdit.IsInside(points, x, y); 
    }
  }

}
