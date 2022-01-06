using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnvifStream
{
    class EventLogging
    {
        public static void LogEvents(string text)
        {
            string logFilePath = "C:\\Avanceon\\Logging\\PTZ";
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                if (!Directory.Exists(logFilePath))
                {
                    Directory.CreateDirectory(logFilePath);
                    StreamWriter sw = new StreamWriter(logFilePath + DateTime.Now.ToString("dd-MMM-yyyy") + ".txt", true);
                    //Write a line of text
                    sw.WriteLine(DateTime.Now.ToShortTimeString() + ": " + text);
                    //Close the file
                    sw.Close();
                }
            }
            catch
            {
            }
        }
    }
}
