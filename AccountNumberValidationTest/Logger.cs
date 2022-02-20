using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNumberValidationTest
{
    public class Logger
    {

        private static string _exePath;
        private static string _timestamp;
        public static string fileName = null;
        public static void InitializeLog()
        {
            _exePath = Path.GetDirectoryName(Environment.CurrentDirectory);
            _timestamp = DateTime.Now.ToString("yyMMdd_hhmmss");

            if (!Directory.Exists((_exePath + "\\..\\Reports\\")))
            {
                Directory.CreateDirectory(_exePath + "\\..\\Reports\\");
            }
            fileName = _exePath + "\\..\\Logs\\" + _timestamp + ".txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            if (!File.Exists(fileName))
            {
                using (StreamWriter sw = File.CreateText(fileName))
                {
                    sw.WriteLine("TestStarted");
                }
            }
        }

        public static void AddLog(String message)
        {
            using (StreamWriter sw = File.AppendText(fileName)) 
            {
                sw.WriteLine(message);
            }

        }
    }
}
