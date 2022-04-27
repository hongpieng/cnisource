using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace TCP_IP_Test
{
    class CNILog
    {
        public static void Write(string sLog)
        {
            try
            {
                string sFilePath = Application.StartupPath + @"\Log\Program Log\";
                string sFilName = sFilePath + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";

                if (!Directory.Exists(sFilePath))
                    Directory.CreateDirectory(sFilePath);

                StreamWriter sw = new StreamWriter(sFilName, true, Encoding.Default);

                sw.Write(sLog);
                sw.Close();
            }
            catch (Exception)
            {

            }
        }
    }

}
