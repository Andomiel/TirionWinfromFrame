//using DevExpress.XtraEditors;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Migrations;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using DevExpress.Data.Helpers;
//using MES;
//using MES.Entity;
//using WinformGeneralDeveloperFrame.Commons;

//namespace WinformGeneralDeveloperFrame
//{
//    public partial class Test : DevExpress.XtraEditors.XtraForm
//    {
//        private bool flag = false;
//        public Test()
//        {
//            InitializeComponent();
//            GetData();
//        }

//        private void simpleButton1_Click(object sender, EventArgs e)
//        {
//            var data = memoEdit1.Text.Split(")".ToCharArray());
//            List<stockInfo> list = new List<stockInfo>();
//            foreach (var item in data)
//            {
//                var dd = item.Split("(".ToCharArray());
//                if(dd.Length!=2)continue;
//                stockInfo info = new stockInfo() { name = dd[0].Replace("\"",""), code = "sz" + dd[1] };
//                list.Add(info);
//            }
//            using (var db = new MESDB())
//            {
//                db.stockInfo.AddRange(list);
//                db.SaveChanges();
//            }
//        }

//        private void GetData()
//        {
//            DateTime startTime1=DateTime.Parse("09:30:00");
//            DateTime endTime1 = DateTime.Parse("11:30:00");

//            DateTime startTime2 = DateTime.Parse("13:00:00");
//            DateTime endTime2 = DateTime.Parse("15:00:00");

//            Task.Factory.StartNew(() =>
//            {
//                while (true)
//                {
//                    if (flag)
//                        if (DateTime.Now >= startTime1 && DateTime.Now <= endTime1 || DateTime.Now >= startTime2 && DateTime.Now <= endTime2)
//                        {
//                            {
//                                List<Task> listtask = new List<Task>();
//                                int num1 = 0;
//                                int num2 = 400;
//                                string code = "";
//                                Dictionary<string, stockInfo> stockinfos = null;
//                                List<string> codes = new List<string>();
//                                using (var db = new MESDB())
//                                {
//                                    num1 = db.stockInfo.GroupBy(P => P.code).ToList().Count;
//                                    foreach (var item in db.stockInfo.GroupBy(P => P.code))
//                                    {
//                                        codes.Add(item.Key);
//                                    }
//                                }
//                                for (int m = 0; m <= num1 / num2; m++)
//                                {
//                                    int n = m;
//                                    var t = Task.Factory.StartNew(() =>
//                                    {
//                                        try
//                                        {
//                                            string url = "http://hq.sinajs.cn/list={0}";
//                                            var list = codes.Skip(num2 * n).Take(num2);
//                                            //string code = "";
//                                            foreach (var str in list)
//                                            {
//                                                code += str + ",";
//                                            }
//                                            url = string.Format(url, code);
//                                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
//                                            request.Method = "GET";
//                                            request.ContentType = "text/html;charset=UTF-8";
//                                            request.UserAgent = null;
//                                            request.Timeout = 60000;
//                                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
//                                            Stream myResponseStream = response.GetResponseStream();
//                                            StreamReader myStreamReader = new StreamReader(myResponseStream, System.Text.Encoding.Default);
//                                            string retString = myStreamReader.ReadToEnd();
//                                            string[] ResData = retString.Split(';');
//                                            List<stockInfo> list1 = new List<stockInfo>();
//                                            foreach (var item in ResData)
//                                            {
//                                                var data = item.Split('=');
//                                                if (data.Length == 2)
//                                                {
//                                                    var dd = data[1].Split(',');
//                                                    if (dd.Length >= 33)
//                                                    {
//                                                        stockInfo info = new stockInfo()
//                                                        {
//                                                            code = data[0].Split('_')[2],
//                                                            name = dd[0].Replace("\"", ""),
//                                                            startPrice = decimal.Parse(dd[1]),
//                                                            olePrice = decimal.Parse(dd[2]),
//                                                            nowPrice = decimal.Parse(dd[3]),
//                                                            maxPrice = decimal.Parse(dd[4]),
//                                                            minPrice = decimal.Parse(dd[5]),
//                                                            bidderPrice = decimal.Parse(dd[6]),
//                                                            auctionPrice = decimal.Parse(dd[7]),
//                                                            turnover = int.Parse(dd[8]),
//                                                            turnoverPrice = decimal.Parse(dd[9]),
//                                                            buyOneNum = int.Parse(dd[10]),
//                                                            buyOnePrice = decimal.Parse(dd[11]),
//                                                            buyTwoNum = int.Parse(dd[12]),
//                                                            buyTwoPrice = decimal.Parse(dd[13]),
//                                                            buyThreeNum = int.Parse(dd[14]),
//                                                            buyThreePrice = decimal.Parse(dd[15]),
//                                                            buyFourNum = int.Parse(dd[16]),
//                                                            buyFourPrice = decimal.Parse(dd[17]),
//                                                            buyFiveNum = int.Parse(dd[18]),
//                                                            buyFivePrice = decimal.Parse(dd[19]),
//                                                            sellOneNum = int.Parse(dd[20]),
//                                                            sellOnePrice = decimal.Parse(dd[21]),
//                                                            sellTwoNum = int.Parse(dd[22]),
//                                                            sellTwoPrice = decimal.Parse(dd[23]),
//                                                            sellThreeNum = int.Parse(dd[24]),
//                                                            sellThreePrice = decimal.Parse(dd[25]),
//                                                            sellFourNum = int.Parse(dd[26]),
//                                                            sellFourPrice = decimal.Parse(dd[27]),
//                                                            sellFiveNum = int.Parse(dd[28]),
//                                                            sellFivePrice = decimal.Parse(dd[29]),
//                                                            timeStr = DateTime.Parse(dd[30] + " " + dd[31])
//                                                        };
//                                                        list1.Add(info);
//                                                    }
//                                                }
//                                            }
//                                            using (var db = new MESDB())
//                                            {
//                                                db.stockInfo.AddRange(list1);
//                                                db.SaveChanges();
//                                            }
//                                        }
//                                        catch (Exception ex)
//                                        {
//                                            var action1 = new Action(() =>
//                                            {
//                                                Show(DateTime.Now + ex.Message + "\r\n");
//                                            });
//                                            this.Invoke(action1);
//                                        }
//                                    });
//                                    listtask.Add(t);
//                                }
//                                Task.WaitAll(listtask.ToArray());
//                                var action = new Action(() =>
//                                {
//                                    Show(DateTime.Now + ":采集成功" + "\r\n");
//                                });
//                                this.Invoke(action);
//                            }
//                        }
//                        else
//                        {
//                            var action1 = new Action(() =>
//                            {
//                                Show(DateTime.Now + "股票已休市" + "\r\n");
//                            });
//                            this.Invoke(action1);
//                        }
                    
//                    Thread.Sleep(30000);
//                }
//            });
//        }

//        private void Show(string str)
//        {
//            memoEdit1.MaskBox.AppendText(str);
//        }
//        private void simpleButton2_Click(object sender, EventArgs e)
//        {
//            if (!flag)
//            {
//                flag = true;
//                memoEdit1.MaskBox.AppendText(DateTime.Now+":开始采集" + "\r\n");
//                simpleButton2.Text = "停止";
//            }
//            else
//            {
//                flag = false;
//                memoEdit1.MaskBox.AppendText(DateTime.Now + ":停止采集" + "\r\n");
//                simpleButton2.Text = "开始采集";
//            }
//        }
//    }
//}