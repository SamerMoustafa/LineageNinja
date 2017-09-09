using System.Diagnostics;

namespace L2Ninja
{
    class CommandLine
    {

        public string StartupPath = "";

        public CommandLine() { }

        public CommandLine(string startDirectory)
        {
            StartupPath = startDirectory;
        }

        public string Execute(string command)
        {
            ProcessStartInfo encDecInfo = new ProcessStartInfo();
            encDecInfo.UseShellExecute = false;
            encDecInfo.WorkingDirectory = StartupPath;
            encDecInfo.FileName = "cmd.exe";
            encDecInfo.CreateNoWindow = true;
            encDecInfo.Arguments = string.Format("/C start /b \"L2Ninja\" {0}", command);
            encDecInfo.WindowStyle = ProcessWindowStyle.Minimized;
            encDecInfo.RedirectStandardOutput = true;
            Process encDecProcess = Process.Start(encDecInfo);
            encDecProcess.WaitForExit();
            return encDecProcess.StandardOutput.ReadToEnd();
        }
    }
}
