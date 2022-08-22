using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
using MES.Form;
using MES;
using TirionWinfromFrame.Commons;

namespace TirionWinfromFrame
{
    public partial class FrmShowForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm mainform;
        public int formId;
        public FrmShowForm()
        {
            InitializeComponent();
        }
        private void FrmShowForm_Load(object sender, EventArgs e)
        {
          
        }

        public void Init()
        {
            flowLayoutPanel1.Controls.Clear();
            using (var db = new MESDB())
            {
                var data = db.sysMenuInfo.Where(p => p.pid == formId&&p.isEnabled).ToList();

                foreach (var item in data)
                {
                    if(!AppInfo.FunctionList.Contains(item.functionCode))continue;
                    SimpleButton btn = new SimpleButton();
                    btn.Name = "btn" + item.id;
                    btn.Size = new System.Drawing.Size(90, 75);
                    btn.Text = item.name;
                    if(!string.IsNullOrEmpty(item.icon)&& File.Exists(Application.StartupPath + "\\" + item.icon))
                        btn.ImageOptions.Image = Image.FromFile(Application.StartupPath+"\\" +item.icon);
                    btn.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter;
                    btn.Click += (o, args) =>
                    {
                        try
                        {
                            string[] itemArray = item.winformType.Split(new char[] {',', ';'});

                            string type = itemArray[0].Trim();
                            string filePath = itemArray[1].Trim(); //必须是相对路径

                            //判断是否配置了显示模式，默认窗体为Show非模式显示
                            string showDialog = (itemArray.Length > 2) ? itemArray[2].ToLower() : "";
                            bool isShowDialog = (showDialog == "1") || (showDialog == "dialog");

                            string dllFullPath = Path.Combine(Application.StartupPath, filePath);
                            Assembly tempAssembly = System.Reflection.Assembly.LoadFrom(dllFullPath);
                            if (tempAssembly != null)
                            {
                                Type objType = tempAssembly.GetType(type);
                                SplashScreenManager.ShowForm(typeof(frmLoading));
                                ChildWinManagement.LoadMdiForm(mainform, objType, item.functionCode);
                                SplashScreenManager.CloseForm();
                            }
                        }
                        catch (Exception ex)
                        {
                            ex.Message.ShowError();
                        }
                    };
                    flowLayoutPanel1.Controls.Add(btn);
                }
            }
        }

    }
}