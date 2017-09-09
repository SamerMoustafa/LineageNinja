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
    class UTXParser
    {

        String BinariesPath = Application.StartupPath + "/" + Properties.Settings.Default.L2EncdecPath + "/";

        public string Encrypt(string filename)
        {

            //Copy File
            String UTXFileName = Path.GetFileName(filename);
            File.Copy(filename, Application.StartupPath + "/includes/l2encdec/" + Path.GetFileName(filename), true);
            //Change CMD Path to Avoid Spaces Errors
            CommandLine cmd = new CommandLine(BinariesPath);
            cmd.Execute("l2encdec_old -e 121 " + UTXFileName); 
            if (File.Exists(BinariesPath + "enc-" + UTXFileName))
            {
                return BinariesPath + "enc-" + UTXFileName;
            }
            return null;
        }

        public string Decrypt(string filename)
        {
            //Copy File
            String UTXFileName = Path.GetFileName(filename);
            File.Copy(filename, BinariesPath + Path.GetFileName(filename), true);
            //Change CMD Path to Avoid Spaces Errors
            CommandLine cmd = new CommandLine(BinariesPath);
            string output = cmd.Execute("l2encdec_old -d " + UTXFileName);
            cmd = null;
            if (File.Exists(BinariesPath + "dec-" + UTXFileName))
            {
                return BinariesPath + "dec-" + UTXFileName;
            }
            return null;
        }

    }
}
