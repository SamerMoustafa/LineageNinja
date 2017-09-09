using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L2Ninja
{
    class L2Encdec
    {

        protected String BinariesPath;

        protected string AttachedFilePath = "";

        protected String[] SupportedFiles = new String[] { "dat", "utx", "ini", "bmp" };

        public L2Encdec()
        {
            BinariesPath = String.Format("{0}/{1}/", Application.StartupPath, Properties.Settings.Default.L2EncdecPath);
        }

        public String GetPath()
        {
            return BinariesPath;
        }

        public void AttachFile(string filePath)
        {
            String extension = Path.GetExtension(filePath);
            if(SupportedFiles.Contains<String>(extension.Substring(1)))
            {
                AttachedFilePath = filePath;
                return;
            }
            
            throw new FormatException("L2Encdec : " + extension + " is unsupported yet");  
        }

        public string Decrypt()
        {
            if(string.IsNullOrEmpty(AttachedFilePath) || !File.Exists(AttachedFilePath))
            { throw new FileNotFoundException("No File Attached"); }

            //Copy File for Temporary Usage
            String fileName = Path.GetFileName(AttachedFilePath);
            File.Copy(AttachedFilePath, BinariesPath + "/temp/" + fileName, true);
            String Command = String.Format("l2encdec -s temp/{0}", fileName);
            CommandLine cmd = new CommandLine(BinariesPath);
            String Output = cmd.Execute(Command);
            //Maybe it's an Old L2 File
            if(Output.Length == 0)
            {
                //Try Old Encrypter
                Command = String.Format("l2encdec_old -s temp/{0}", fileName);
                Output = cmd.Execute(Command);
            }
            string DecryptedName = "dec-" + fileName;
            if(Output.Contains(DecryptedName) && File.Exists(BinariesPath + DecryptedName))
            {
                return BinariesPath + DecryptedName;
            }
            return null;
        }


        public string EncryptDat()
        {
            if (string.IsNullOrEmpty(AttachedFilePath) || !File.Exists(AttachedFilePath))
            { throw new FileNotFoundException("No File Attached"); }

            //Copy File for Temporary Usage
            String fileName = Path.GetFileName(AttachedFilePath);
            File.Copy(AttachedFilePath, BinariesPath + "/" + fileName, true);
            String Command = String.Format("l2encdec_old -h 413 {0}", fileName);
            String Output = Execute(Command);
            if (Output.Length == 0)
            {
                //Try New Encrypter
                Command = String.Format("l2encdec -h 413 /{0}", fileName);
                Output = Execute(Command);
            }
            string DecryptedName = "enc-" + fileName;
            if (Output.Contains(DecryptedName) && File.Exists(BinariesPath + DecryptedName))
            {
                return BinariesPath + DecryptedName;
            }
            return null;
        }

        public string EncryptSplash()
        {
            if (string.IsNullOrEmpty(AttachedFilePath) || !File.Exists(AttachedFilePath))
            { throw new FileNotFoundException("No File Attached"); }

            //Copy File for Temporary Usage
            String fileName = Path.GetFileName(AttachedFilePath);
            File.Copy(AttachedFilePath, BinariesPath + "/" + fileName, true);
            CommandLine cmd = new CommandLine(BinariesPath);
            String Command = String.Format("l2encdec_old -h 121 {0}", fileName);
            String Output = cmd.Execute(Command);
            if (Output.Length == 0)
            {
                //Try New Encrypter
                Command = String.Format("l2encdec -h 413 {0}", fileName);
                Output = cmd.Execute(Command);

            }
            string EncryptedName = "enc-" + fileName;
            if (Output.Contains(EncryptedName) && File.Exists(BinariesPath + EncryptedName))
            {
                return BinariesPath + EncryptedName;
            }
            return null;
        }


        protected string Execute(string command)
        {
            ProcessStartInfo encDecInfo = new ProcessStartInfo();
            encDecInfo.UseShellExecute = false;
            encDecInfo.WorkingDirectory = BinariesPath;
            encDecInfo.FileName = "cmd.exe";
            encDecInfo.Arguments = string.Format("/B /C {0}", command);
            encDecInfo.WindowStyle = ProcessWindowStyle.Hidden;
            encDecInfo.RedirectStandardOutput = true;
            Process encDecProcess = Process.Start(encDecInfo);
            encDecProcess.WaitForExit();
            return encDecProcess.StandardOutput.ReadToEnd();
        }




    }
}
