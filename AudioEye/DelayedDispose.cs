using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEye
{
  /// <summary>
  /// A very lousy way to dispose something in a multithreaded program. 
  /// </summary>
  public class DelayedDispose
  {
    IDisposable disposable;
    BackgroundWorker disposer = new BackgroundWorker();
    int milliseconds; 

    public DelayedDispose(IDisposable disposable, int milliseconds = 1000)
    {
      if (disposable == null)
        return; 
      this.disposable = disposable;
      this.milliseconds = milliseconds; 
      disposer.DoWork += WaitAndDispose;
      disposer.RunWorkerAsync(); 
    }

    private void WaitAndDispose(object sender, DoWorkEventArgs e)
    {
      System.Threading.Thread.Sleep(milliseconds);
      disposable.Dispose(); 
    }
  }

  public static class IDisposableExtension
  {
    public static void DisposeDelayed(this IDisposable disposable, int milliseconds = 2000)
    {
      new DelayedDispose(disposable, milliseconds); 
    }
  }
}
