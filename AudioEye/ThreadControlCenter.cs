//Copyright (C) Maarten 't Hart 22 december 2019
//GNU License 3 applies for this software. See readme.txt
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace AudioEye
{
  public class ThreadControlCenter
  {
    public bool Stop { get; set; } = false;

    //main ThreadControlCenter
    private static ThreadControlCenter main = new ThreadControlCenter();
    public static ThreadControlCenter Main => main;

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

    //Booleans
    public bool DrawOriginal { get; set; } = true;

    //Reference time
    public DateTime StartOfProgram { get; set; } = DateTime.Now;
    public double SecondsSinceStart => (DateTime.Now - StartOfProgram).TotalSeconds;

    //Audio
    private object audioLock = new object();
    private AudioStream audioStream;
    private int audioResetTime = 30; 

    public AudioStream ActiveAudioStream 
    {
      get
      {
        lock (audioLock) return audioStream; 
      }
      set
      {
        lock (audioLock) audioStream = value; 
      }
    }

    public float AmplifyLeft { get; set; } = 1;
    public float AmplifyMono { get; set; } = 1; 
    public float AmplifyRight { get; set; } = 1; 

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

    private void AudioPlayerWorkSoundPlayer()
    {
      SoundPlayer soundPlayer = new SoundPlayer();
      while (!Stop)
      {
        try
        {
          AudioStream audioStream = new AudioStream(1);
          ActiveAudioStream = audioStream;
          soundPlayer.Stream = audioStream;
          soundPlayer.PlaySync();
        }
        catch
        {
          soundPlayer.Stop();
          soundPlayer.Dispose();
        }
      }
      if (soundPlayer != null)
        soundPlayer.Dispose();
    }

    private void AudioPlayerWorkNAudio()
    {
      NAudio.Wave.DirectSoundOut output = new NAudio.Wave.DirectSoundOut();
      
      output.PlaybackStopped += ResetAudio;

      AudioStream audioStream= new AudioStream(audioResetTime, false);
      ActiveAudioStream = audioStream;
      while (!Stop)
      {
        audioStream = ActiveAudioStream;
        AudioWaveStream audioWaveStream = new AudioWaveStream(audioStream);
        output.Init(new NAudio.Wave.WaveChannel32(audioWaveStream) { PadWithZeroes = false });
        try
        {
          output.Play(); 
        }
        catch
        {
          output.Stop();
        }
        while (audioStream == ActiveAudioStream)
        {
          System.Threading.Thread.Sleep(1);
        }
        output.Stop();
      }
    }
    private void ResetAudio(object sender, StoppedEventArgs e)
    {
      ActiveAudioStream = new AudioStream(audioResetTime, false); 
    }

     private void AudioPlayerWork(object sender, DoWorkEventArgs e)
    {
      //AudioPlayerWorkSoundPlayer();
      AudioPlayerWorkNAudio();
    }

    private void AudioUpdaterWork(object sender, DoWorkEventArgs e)
    {
      while (!Stop)
      {
        AudioStream audioStream = ThreadControlCenter.Main.ActiveAudioStream;
        if (ThreadControlCenter.Main.ActiveSnapshot == null || audioStream == null || !audioStream.ReadyForWrite || audioStream.Saturated)
        {
          System.Threading.Thread.Sleep(1);
          continue;
        }
        audioStream.StartTime = ThreadControlCenter.Main.SecondsSinceStart + 1;
        Parallel.For(0, 8, threadIndex =>{
            //doing this in multiple threads to speed it up. 

            int index = audioStream.GetNextBlockIndex();
            while (index >= 0 && !Stop)
            {
              double time = audioStream.GetBlockTime(index);
              while (ThreadControlCenter.Main.SecondsSinceStart < time && !Stop)
                System.Threading.Thread.Sleep(1);

              Snapshot snapshot = ThreadControlCenter.Main.ActiveSnapshot;
              Audio10msBlock block = Audio10msBlock.FromSnapshot(snapshot, time, index, ThreadControlCenter.Main.AmplifyLeft, ThreadControlCenter.Main.AmplifyRight);

              audioStream.SetBlock(index, block);
              index = audioStream.GetNextBlockIndex();

            if (audioStream != ThreadControlCenter.Main.ActiveAudioStream)
              break; 
            }
          });
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
                  if (DrawOriginal)
                    editedOriginal = eyeWeb.DrawOn(originalImage, point);
                  else
                    editedOriginal = eyeWeb.DrawOn(originalImage, point, true);
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
