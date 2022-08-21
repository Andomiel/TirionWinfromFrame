using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Update
{
    /// <summary>
    /// 记录操作过程的信息
    /// </summary>
    public class Log
    {
        public static void Write(string msg)
        {
            Write(msg, true);
        }

        public static void Write(string msg, bool isAppend)
        {
            try
            {
                string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "update.txt");
                if (!Directory.Exists(Path.GetDirectoryName(filename)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));
                }
                using (FileStream stream = new FileStream(filename, isAppend ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    StreamWriter writer = new StreamWriter(stream);
                    writer.WriteLine(msg);
                    writer.Close();
                    stream.Close();
                }
            }
            catch
            {
            }
        }

        public static void Write(Exception ex)
        {
            string msg = DateTime.Now + System.Environment.NewLine
                                      + ex.Message + System.Environment.NewLine
                                      + ex.Source + System.Environment.NewLine
                                      + ex.StackTrace + System.Environment.NewLine
                                      + ex.TargetSite.Name;
            Write(msg);
        }
    }
}