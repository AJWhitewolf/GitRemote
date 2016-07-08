using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace GitRemote
{
    public class GitProgram
    {
        public string Command { get; set; }
        public string WorkingDirectory { get; set; }
        public ProcessStartInfo gitInfo { get; set; }
        public string GitExeLocation { get; set; }
        public Process gitProcess { get; set; }

        public GitProgram(string cmd, string dir)
        {
            WorkingDirectory = dir;
            Command = cmd;
            GitExeLocation = @"C:\Program Files\Git\bin\git.exe";
            gitInfo = new ProcessStartInfo();
            gitInfo.CreateNoWindow = true;
            gitInfo.RedirectStandardError = true;
            gitInfo.RedirectStandardOutput = true;
            gitInfo.UseShellExecute = false;
            gitInfo.FileName = GitExeLocation;
            gitInfo.WorkingDirectory = dir;
            gitProcess = new Process();
        }

        public void GitCommit()
        {
            gitInfo.Arguments = "add *";
            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();
            gitProcess.WaitForExit();

            gitInfo.Arguments = "commit -m 'Generated automatically fom WebSocket_Home'";
            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();
            gitProcess.WaitForExit();
        }

        public void GitPush()
        {
            gitInfo.Arguments = "push --all origin";
            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();
            gitProcess.WaitForExit();
        }

        public void GitPull()
        {
            gitInfo.Arguments = "pull";
            gitProcess.StartInfo = gitInfo;
            gitProcess.Start();
            gitProcess.WaitForExit();
        }

        public void DoIt()
        {
            if (Command == "pull")
            {
                GitPull();
            }
            else if (Command == "push")
            {
                GitPush();
            }
            else if (Command == "commit")
            {
                GitCommit();
            }
            gitProcess.Close();
        }
    }
}
