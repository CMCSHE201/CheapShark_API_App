// Logging service
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace csApiApp.Services
{
    public class Logger
    {
        private string _logFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "csApiApp.log");

        public Logger()
        {
            // Create the log file if it doesn't exist.
            if (!File.Exists(_logFilePath))
            {
                using (var logFile = File.Create(_logFilePath))
                {
                    logFile.Close();
                }
            }
        }

        // Log to file and console.
        public void Log(string message)
        {
            // Log to file.
            using (var logFile = File.AppendText(_logFilePath))
            {
                logFile.WriteLine(message);
                logFile.Close();
            }

            // Log to console.
            Debug.WriteLine(message);
        }
    }
}