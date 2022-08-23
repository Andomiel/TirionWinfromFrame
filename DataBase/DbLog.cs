using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    internal class DbLog
    {
        /// <summary>
        /// 写入系统记录
        /// </summary>
        /// <param name="content"></param>
        public static void Log(params string[] content)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            foreach (string item in content)
            {
                sb.AppendLine(item);
            }
            sb.AppendLine();
            string path = $"{Application.StartupPath}\\Log";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            File.AppendAllText($"{path}\\{ DateTime.Now:yyyy-MM-dd}_db.log", sb.ToString());
        }
    }
}
