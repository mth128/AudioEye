//Copyright (C) Maarten 't Hart 22 december 2019
//GNU License 3 applies for this software. See readme.txt
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebcamCapturer.Core;

namespace AudioEye
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      EyeWebTestForm startForm = new EyeWebTestForm();
      var presenter = new WebcamCapturePresenter(startForm);
      Application.Run(startForm);
    }
  }
}
