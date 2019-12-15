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
    public float resolution;
    public float sourceCenterX;
    public float sourceCenterY;

    public EyeWeb(int subsectionsPerTone = 1, float powerBase = 1.8f, float centerSubstract = 0.5f)
    {
      
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
    }

    public PointF[] GetPoints(int rectangleIndex, float resolution, float centerX, float centerY)
    {
      return shapes[rectangleIndex].GetPoints(extent, resolution, centerX, centerY);
    }

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
    }

  }

  public class EyeWebShape
  {
    public EyeWebCoordinate[] coordinates;
    public PointF[] targetPoints;
    public PointF[] sourcePoints;
    public int tintLeft = 0; 
    public int tintMono = 0;
    public int tintRight = 0; 
    public double tone;
    public SoundWave soundWave; 


    public EyeWebShape(double tone, double toneWidth = 1, float powerBase = 1.8f, float centerSubstract = 0.5f)
    {
      coordinates = new EyeWebCoordinate[4];
      coordinates[0] = new EyeWebCoordinate(tone, powerBase, centerSubstract);
      coordinates[1] = new EyeWebCoordinate(tone+toneWidth, powerBase, centerSubstract);
      coordinates[2] = new EyeWebCoordinate(tone+12+toneWidth, powerBase, centerSubstract);
      coordinates[3] = new EyeWebCoordinate(tone+12, powerBase, centerSubstract);
      this.tone = tone;
      soundWave = new SoundWave(tone); 
    }

    public override string ToString()
    {
      return coordinates[0].ToString() + " \n" + coordinates[1].ToString() + " \n" +
        coordinates[2].ToString() + " \n" + coordinates[3].ToString();
    }
    public PointF[] GetPoints(float extent, float resolution, float centerX, float centerY)
    {
      PointF[] points = new PointF[4];
      for (int i = 0; i < 4; i++)
        points[i] = coordinates[i].GetPoint(extent, resolution, centerX, centerY);
      return points; 
    }
  }

  public class EyeWebCoordinate
  {
    public static int octaves = 7; 
    public float x;
    public float y; 

    public EyeWebCoordinate(double tone, float powerBase =1.8f, float centerSubstract = 0.5f, bool clockwise = false)
    {
      double inverse = (octaves*12)-tone;
      if (inverse <0)
      {
        x = 0;
        y = 0;
        return; 
      }

      double sigma = (tone) / 6.0 * Math.PI;
      double cos = Math.Cos(sigma);
      double sin = Math.Sin(sigma);
      if (clockwise)
        cos = -cos; 
      double length = Math.Pow(powerBase, inverse / 12.0) - centerSubstract;

      x = Convert.ToSingle(cos * length);
      y = Convert.ToSingle(sin * length); 

    }

    public PointF GetPoint(float extent, float resolution, float centerX, float centerY)
    {
      float px = x / (2 * extent) * resolution + centerX;
      float py = -y / (2 * extent) * resolution + centerY;
      return new PointF(px,py);
    }


    internal PointF PointF(float extent, float resolution)
    {
      float px = (this.x + extent) / (2 * extent);
      float py = 1-((this.y + extent) / (2 * extent));

      return new PointF(px*resolution, py*resolution); 
    }
    public override string ToString()
    {
      string xString = x.ToString();
      if (xString.Length<10 && !xString.Contains("E") &&!xString.Contains("e"))
      {
        if (!xString.Contains("."))
          xString += ".";
        while (xString.Length<10)
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


}
