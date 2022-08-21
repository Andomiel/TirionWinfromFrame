using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MES;
using MES.Entity;

namespace WinformGeneralDeveloperFrame
{
    public partial class FrmSSq :FrmBaseForm
    {
        private bool flag = false;
        public FrmSSq()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                flag = true;
                simpleButton1.Text = "停止";
            }
            else
            {
                flag = false;
                simpleButton1.Text = "开始";
            }
        }
        private void GetData()
        {

            Task.Factory.StartNew(() =>
            {
                List<int> red = new List<int>();
                int blue = 0;
                while (true)
                {
                    if (flag)
                    { 
                        
                        //while(true)
                        {
                            int num = new Random().Next(1, 33);
                            if (!red.Contains(num))
                            {
                                red.Add(num);
                            }

                            if (red.Count == 6)
                            {
                                blue = new Random().Next(1, 16);
                                List<int> list=red.OrderBy(p=>p).ToList();
                                using (var db=new MESDB())
                                {
                                    db.lotteryInfo.Add(new lotteryInfo(){blue = blue,red1 = list[0],red2 = list[1],red3 = list[2],red4 = list[3],red5 = list[4],red6 = list[5]});
                                    db.SaveChanges();
                                }
                                var action1 = new Action(() =>
                                {
                                    Show($"红色：{list[0]} {list[1]} {list[2]} {list[3]} {list[4]} {list[5]};蓝色：{blue}");
                                });
                                this.Invoke(action1);
                                red.Clear();
                                blue = 0;
                            }
                        }
                    }
                }
            });
        }
        private void Show(string str)
        {
            richTextBox1.AppendText(str+"\r\n");
        }

        private void FrmSSq_Load(object sender, EventArgs e)
        {
            GetData();
            using (var db = new MESDB())
            {
                gridControl1.DataSource = db.lotteryInfo.ToList();
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using (var db = new MESDB())
            {
                gridControl1.DataSource = db.lotteryInfo.ToList();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;

            richTextBox1.ScrollToCaret(); //Caret意思：脱字符号；插入符号; (^)
        }
    }
}