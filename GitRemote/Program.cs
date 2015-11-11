using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GitRemote
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.FileName = @"C:\Program Files\Git\bin\git.exe";

            Process gitProcess = new Process();
            if (args[0] == "pull")
            {
                gitInfo.Arguments = "pull";
            }
            else if (args[0] == "push")
            {
                gitInfo.Arguments = "push --all origin";
            }
            gitInfo.WorkingDirectory = args[1];

            gitInfo.UseShellExecute = false;

            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();

            string stderr_str = gitProcess.StandardError.ReadToEnd();
            //string stdout_str = gitProcess.StandardOutput.ReadToEnd(); // pick up STDOUT

            gitProcess.WaitForExit();
            gitProcess.Close();
        }
    }
}
