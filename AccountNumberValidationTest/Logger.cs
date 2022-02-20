using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AccountNumberValidationTest
{
    public class Logger
    {
        
        private static string _exePath;
        private static string _timestamp;
        public static string fileName = null;
        public static void InitializeLog()
        {
            _exePath = ConfigurationManager.AppSettings["ReportsDirectory"];
            _timestamp = DateTime.Now.ToString("_dd_MM_yyyy_hh_mm_sss");

            if (!Directory.Exists(_exePath))
            {
                Directory.CreateDirectory(_exePath + "\\..\\Reports\\");
            }
            fileName = _exePath +"Report"+ _timestamp + ".txt";
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
