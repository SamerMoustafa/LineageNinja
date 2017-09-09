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
    class L2ASM
    {
        protected String BinariesPath;

        protected string AttachedFilePath = "";

        protected String[] SupportedFiles = new String[] { "dat", "ini", "dump", "txt" };

        public L2ASM()
        {
            BinariesPath = String.Format("{0}/{1}/", Application.StartupPath, Properties.Settings.Default.L2ASMPath);
        }

        public String GetPath()
        {
            return BinariesPath;
        }

        public void AttachFile(string filePath)
        {
            String extension = Path.GetExtension(filePath);
            if (SupportedFiles.Contains<String>(extension.Substring(1)))
            {
                AttachedFilePath = filePath;
                return;
            }
            throw new FormatException("L2ASM-Disasm : " + extension + " is unsupported yet");
        }


        public string Decrypt(Chronicle chron)
        {
            if (string.IsNullOrEmpty(AttachedFilePath) || !File.Exists(AttachedFilePath))
            { throw new FileNotFoundException("No File Attached"); }

            //Copy File for Temporary Usage
            String fileName = Path.GetFileName(AttachedFilePath);
            File.Copy(AttachedFilePath, BinariesPath + "temp/" + fileName, true);
            //Grab DDF file
            String DDFFileName = Path.GetFileNameWithoutExtension(AttachedFilePath.Replace("dec-", "").Replace("enc-", "")) + ".ddf";
            String DDFFilePath = String.Format("{0}DAT_defs/{1}/{2}", BinariesPath, Chronicles.GetCode(chron), DDFFileName);
            String DecryptionFileName = Path.GetFileNameWithoutExtension(AttachedFilePath) + ".txt";
            File.Copy(DDFFilePath, BinariesPath + "temp/" + DDFFileName, true);
            String Command = String.Format("l2disasm -d temp/{0} temp/{1} temp/{2}",DDFFileName,fileName, DecryptionFileName);
            CommandLine cmd = new CommandLine(BinariesPath);
            String Output = cmd.Execute(Command);
            if(File.Exists(BinariesPath + "temp/" + DecryptionFileName))
            {
                return BinariesPath + "temp/" + DecryptionFileName;
            }
            return null;
        }

        public string Encrypt(Chronicle chron)
        {
            if (string.IsNullOrEmpty(AttachedFilePath) || !File.Exists(AttachedFilePath))
            { throw new FileNotFoundException("No File Attached"); }

            //Copy File for Temporary Usage
            String fileName = Path.GetFileName(AttachedFilePath);
            File.Copy(AttachedFilePath, BinariesPath + "temp/" + fileName, true);
            //Grab DDF file
            String DDFFileName = Path.GetFileNameWithoutExtension(AttachedFilePath.Replace("dec-", "").Replace("enc-", "")) + ".ddf";
            String DDFFilePath = String.Format("{0}DAT_defs/{1}/{2}", BinariesPath, Chronicles.GetCode(chron), DDFFileName);
            String EncryptionFileName = Path.GetFileNameWithoutExtension(AttachedFilePath) + ".dat";
            File.Copy(DDFFilePath, BinariesPath + "temp/" + DDFFileName, true);
            String Command = String.Format("l2asm.exe -d temp/{0} temp/{1} temp/{2}", DDFFileName, fileName, EncryptionFileName);
            CommandLine cmd = new CommandLine(BinariesPath);
            String Output = cmd.Execute(Command);
            if (File.Exists(BinariesPath + "temp/" + EncryptionFileName))
            {
                return BinariesPath + "temp/" + EncryptionFileName;
            }
            return null;
        }

    }
}
