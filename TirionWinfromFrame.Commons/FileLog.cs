using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TirionWinfromFrame.Commons
{
    public static class FileLog
    {
        public static void Log(string content)
        {
            try
            {
                SaveLog($"{Application.StartupPath}\\logs", content);
            }
            catch { }
        }

        private static void SaveLog(string path, params string[] content)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            foreach (string item in content)
            {
                sb.AppendLine(item);
            }
            sb.AppendLine();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.AppendAllText($"{path}\\{ DateTime.Now:yyyy-MM-dd}.log", sb.ToString());
        }
    }
}
