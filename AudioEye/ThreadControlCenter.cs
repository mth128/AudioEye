using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  public class ThreadControlCenter
  {
    public bool Stop { get; set; } = false; 

    //main ThreadControlCenter
    private static ThreadControlCenter main = null;
    public static ThreadControlCenter Main => main == null? main = new ThreadControlCenter() : main; 
     
    //Active source images. 
    private object imageLock = new object();
    private StereoImage stereoImage;
    private Image originalImage; 
    public StereoImage ActiveStereoImage
    {
      get { lock (imageLock) return stereoImage; }
      set { lock (imageLock) stereoImage = value; }
    }

    public Image OriginalImage
    {
      get { lock (imageLock) return originalImage; }
      set { lock (imageLock) originalImage = value; }
    }
    
    //Active EyeWeb
    private object eyeWebLock = new object();
    private EyeWeb activeEyeWeb;
    public EyeWeb ActiveEyeWeb
    {
      get { lock (eyeWebLock) return activeEyeWeb; }
      set { lock (eyeWebLock) activeEyeWeb = value; }
    }

    //Active Snapshot
    private object snapshotLock = new object();
    private Snapshot activeSnapshot;
    public Snapshot ActiveSnapshot
    {
      get { lock (snapshotLock) return activeSnapshot; }
      set { lock (snapshotLock) activeSnapshot = value; }
    }

    //Active output bitmaps
    private object outputBitmapsLock = new object();
    private Bitmap outputBitmapLeft;
    private Bitmap outputBitmapMono; 
    private Bitmap outputBitmapRight;
    private Bitmap editedOriginal; 
    public Bitmap OutputBitmapLeft
    {
      get { lock (outputBitmapsLock) return outputBitmapLeft; }
      set { lock (outputBitmapsLock) outputBitmapLeft = value; }
    }
    public Bitmap OutputBitmapRight
    {
      get { lock (outputBitmapsLock) return outputBitmapRight; }
      set { lock (outputBitmapsLock) outputBitmapRight = value; }
    }
    public Bitmap OutputBitmapMono
    {
      get { lock (outputBitmapsLock) return outputBitmapMono; }
      set { lock (outputBitmapsLock) outputBitmapMono = value; }
    }
    public Bitmap EditedOriginal
    {
      get { lock (outputBitmapsLock) return editedOriginal; }
      set { lock (outputBitmapsLock) editedOriginal = value; }
    }

    //Active points
    private object pointLock = new object();
    private Point leftPoint;
    private Point rightPoint;
    public Point LeftPoint
    {
      get { lock (pointLock) return leftPoint; }
      set { lock (pointLock) leftPoint = value; }
    }
    public Point RightPoint
    {
      get { lock (pointLock) return rightPoint; }
      set { lock (pointLock) rightPoint = value; }
    }

    //Threads 
    private BackgroundWorker audioPlayer = new BackgroundWorker();
    private BackgroundWorker audioUpdater = new BackgroundWorker();
    private BackgroundWorker snapshotCapturer = new BackgroundWorker();
    private BackgroundWorker imagePainter = new BackgroundWorker();

    //Constructor
    private ThreadControlCenter()
    {
      audioPlayer.DoWork += AudioPlayerWork;
      audioPlayer.RunWorkerAsync();

      audioUpdater.DoWork += AudioUpdaterWork;
      audioUpdater.RunWorkerAsync();

      snapshotCapturer.DoWork += SnapshotCapturerWork;
      snapshotCapturer.RunWorkerAsync();

      imagePainter.DoWork += ImagePainterWork;
      imagePainter.RunWorkerAsync();
    }

    private void AudioPlayerWork(object sender, DoWorkEventArgs e)
    {
      while (!Stop)
      {
        System.Threading.Thread.Sleep(1); 
      }
    }

    private void AudioUpdaterWork(object sender, DoWorkEventArgs e)
    {
      while (!Stop)
      {
        System.Threading.Thread.Sleep(1);
      }
    }

    private void SnapshotCapturerWork(object sender, DoWorkEventArgs e)
    {
      StereoImage previousStereoImage = null; 
      EyeWeb previousEyeWeb = null;
      Point previousPoint = new Point(0, 0);

      while (!Stop)
      {
        bool changed = false;
        
        //input
        EyeWeb eyeWeb = ThreadControlCenter.Main.ActiveEyeWeb;
        Point point = ThreadControlCenter.Main.LeftPoint;
        StereoImage stereoImage = ThreadControlCenter.Main.ActiveStereoImage;

        //output
        Snapshot snapshot = ThreadControlCenter.Main.ActiveSnapshot;
        
        if (eyeWeb == null || stereoImage == null)
          continue; 

        if (eyeWeb!=previousEyeWeb || point !=previousPoint || stereoImage!=previousStereoImage)
        {
          changed = true;
          snapshot = new Snapshot(stereoImage, eyeWeb, point.X, point.Y);
        }

        previousStereoImage = stereoImage; 
        previousEyeWeb = eyeWeb;
        previousPoint = point;

        if (changed)
          ThreadControlCenter.Main.ActiveSnapshot = snapshot; 
        else
          System.Threading.Thread.Sleep(1);

      }
    }

    private void ImagePainterWork(object sender, DoWorkEventArgs e)
    {
      Snapshot previousSnapshot = null;
      EyeWeb previousEyeWeb = null;
      Image previousImage = null;
      Point previousPoint = new Point(0, 0);
      while (!Stop)
      {
        bool changed = false;

        //input
        Snapshot snapshot = ThreadControlCenter.Main.ActiveSnapshot;
        Image originalImage = ThreadControlCenter.Main.OriginalImage;
        Point point = ThreadControlCenter.Main.LeftPoint;
        EyeWeb eyeWeb = ThreadControlCenter.Main.ActiveEyeWeb;

        //output
        Bitmap editedOriginal = ThreadControlCenter.Main.EditedOriginal;
        Bitmap left = ThreadControlCenter.Main.OutputBitmapLeft;
        Bitmap right = ThreadControlCenter.Main.OutputBitmapRight;
        Bitmap mono = ThreadControlCenter.Main.OutputBitmapMono;

        if (eyeWeb == null)
        {
          System.Threading.Thread.Sleep(1);
          continue; 
        }

        Parallel.For(0, 4, i => {
          switch (i)
          {
            case 0:
              {
                if (point!=previousPoint || eyeWeb!=previousEyeWeb || originalImage != previousImage)
                {
                  changed = true;
                  editedOriginal = eyeWeb.DrawOn(originalImage, point);
                }
              }
              break;
            case 1:
              if (snapshot != previousSnapshot)
              {
                changed = true;
                left = eyeWeb.DrawSnapshot(snapshot.Left);
              }
              break;
            case 2:
              if (snapshot != previousSnapshot)
              {
                changed = true;
                right = eyeWeb.DrawSnapshot(snapshot.Right);
              }
              break;
            case 3:
              if (snapshot != previousSnapshot)
              {
                changed = true;
                mono = eyeWeb.DrawSnapshot(snapshot.Mono);
              }
              break;
          }
        });
        if (changed)
        {
          ThreadControlCenter.Main.OutputBitmapLeft = left;
          ThreadControlCenter.Main.OutputBitmapMono = mono;
          ThreadControlCenter.Main.OutputBitmapRight = right;
          ThreadControlCenter.Main.EditedOriginal = editedOriginal;
          previousSnapshot = snapshot;
          previousImage = originalImage;
          previousEyeWeb = eyeWeb;
          previousPoint = point; 
        }
        else
          System.Threading.Thread.Sleep(1);
      }
    }
  }

  public enum ThreadID: short
  {
    None = 0,
    Root = 1,
    AudioPlayer = 2,
    AudioUpdater = 4,
    SnapshotCapturer = 8,
    ImagePainter = 16,
    ThreadControlCenter = 32
  }
}
