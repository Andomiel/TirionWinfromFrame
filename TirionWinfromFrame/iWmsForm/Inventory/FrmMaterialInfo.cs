using Business;
using Entity;
using Entity.Dto;
using Entity.Enums;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TirionWinfromFrame;
using TirionWinfromFrame.Commons;

namespace iWms.Form
{
    public partial class FrmMaterialInfo : FrmBaseForm
    {
        public int pageSize = 100;      //每页记录数
        public int recordCount = 0;    //总记录数
        public int pageCount = 0;      //总页数
        public int currentPage = 0;    //当前页
        private BindingList<InventoryEntity> Barcodes = new BindingList<InventoryEntity>();

        public FrmMaterialInfo()
        {
            InitializeComponent();
            var towerMaps = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(TowerEnum));
            towerMaps.Add(new EnumItem() { Value = 5, Description = "烘烤区" });
            cmbArea.DataSource = towerMaps;
            cmbArea.DisplayMember = "Description";
            cmbArea.ValueMember = "Value";

            cbMateType.DataSource = BuildComboxHelper.BuildComboxWithEmptyFromEnum(typeof(ReelTypeEnum));
            cbMateType.DisplayMember = "Description";
            cbMateType.ValueMember = "Name";

            //dtpCycleStart.Format = DateTimePickerFormat.Custom;
            //dtpCycleStart.CustomFormat = " ";
            //dtpCycleEnd.Format = DateTimePickerFormat.Custom;
            //dtpCycleEnd.CustomFormat = " ";
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = " ";
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = " ";

            dataGridViewX1.ScrollBars = ScrollBars.Both;
            dataGridViewX1.Dock = DockStyle.Fill;
            dataGridViewX1.AutoGenerateColumns = false;
            dataGridViewX1.DataSource = Barcodes;
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            var thisDateTimePicker = sender as DateTimePicker;
            thisDateTimePicker.Format = DateTimePickerFormat.Long;
            thisDateTimePicker.CustomFormat = null;
        }

        private string orderBy = " SaveTime DESC ";

        private readonly object lockOperateObj = new object();

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockOperateObj)
                {
                    orderBy = " SaveTime DESC ";
                    currentPage = 1;
                    GetOrders();
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        private void GetOrders()
        {
            MaterialQueryCondition condition = new MaterialQueryCondition
            {
                //周期
                //haveCycleQuery = dtpCycleStart.Format != DateTimePickerFormat.Custom
                //                    && dtpCycleEnd.Format != DateTimePickerFormat.Custom,
                //CycleStart = Convert.ToDateTime(dtpCycleStart.Value.ToString("yyyy-MM-dd")),
                //CycleEnd = Convert.ToDateTime(dtpCycleEnd.Value.ToString("yyyy-MM-dd")),
                //料盘类型
                MateType = (this.cbMateType.SelectedItem as EnumItem).Name,
                //MSD
                MSD = this.cbMSD.Text,
                //流水号
                SerialNoStart = this.txtSerialNoStart.Text,
                SerialNoEnd = this.txtSerialNoEnd.Text,
                //超期
                ExceedStart = TypeParse.StrToInt(this.txtExceedStart.Text, 0),
                ExceedEnd = TypeParse.StrToInt(this.txtExceedEnd.Text, 0),
                //入库时间
                haveSaveTimeQuery = dtpStart.Format != DateTimePickerFormat.Custom
                                       && dtpEnd.Format != DateTimePickerFormat.Custom,
                SaveTimeStart = Convert.ToDateTime(dtpStart.Value.ToString("yyyy-MM-dd")),
                SaveTimeEnd = Convert.ToDateTime(dtpEnd.Value.ToString("yyyy-MM-dd")).AddDays(1),

                //库区
                TowerNo = Convert.ToInt32(cmbArea.SelectedValue)
            };

            //巷道、货架
            switch (condition.TowerNo)
            {
                case (int)TowerEnum.SortingArea:
                case (int)TowerEnum.PalletArea:
                default:
                    break;
                case (int)TowerEnum.ASRS:
                    condition.ABSide = this.cbShelfSide.Text;
                    break;
                case (int)TowerEnum.LightShelf:
                    condition.MachineId = string.IsNullOrWhiteSpace(cbShelfSide.Text) ? string.Empty : $"SWHY0{this.cbShelfSide.Text}";
                    break;
                case (int)TowerEnum.ReformShelf:
                    condition.MachineId = this.cbShelfSide.Text;
                    break;
            }
            //状态
            condition.HoldState = this.BoxStatus.Text;
            //供货厂家
            condition.Supplier = this.TextSupply.Text;
            condition.UPN = this.txtReelid.Text.ToString().Trim();
            //料号
            condition.PartNumber = this.txtPn.Text.ToString();

            Barcodes.Clear();
            int startRow = (currentPage - 1) * pageSize;
            var inventory = InOutStockStorageData.GetSmt_zd_MaterialInfo(condition, startRow, startRow + pageSize, orderBy);
            foreach (var item in inventory)
            {
                Barcodes.Add(item);
            }
            recordCount = 0;
            if (inventory != null && inventory.Count > 0)
            {
                recordCount = inventory.First().TotalCount;
            }
            pageCount = (recordCount / pageSize);
            if (recordCount % pageSize > 0)
            {
                pageCount += 1;
            }
            LoadPagedWorkOrder();
        }

        private void LoadPagedWorkOrder()
        {
            if (pageCount == 0)
            {
                tpscurrentPage.Text = "0";//当前页
                tpspageCount.Text = "0";//总页数
                tpsrecordCount.Text = "0";//总记录数
                return;
            }
            if (currentPage < 1) currentPage = 1;
            if (currentPage > pageCount) currentPage = pageCount;

            tpscurrentPage.Text = currentPage.ToString();//当前页
            tpspageCount.Text = pageCount.ToString();//总页数
            tpsrecordCount.Text = recordCount.ToString();//总记录数
        }


        private void BtnFrist_ButtonClick(object sender, EventArgs e)
        {
            currentPage = 1;
            GetOrders();
        }

        private void BtnPre_ButtonClick(object sender, EventArgs e)
        {
            currentPage -= 1;
            GetOrders();
        }

        private void BtnNext_ButtonClick(object sender, EventArgs e)
        {
            currentPage += 1;
            GetOrders();
        }

        private void BtnLast_ButtonClick(object sender, EventArgs e)
        {
            currentPage = pageCount;
            GetOrders();
        }

        private void FrmInStockDatailInfo_Load(object sender, EventArgs e)
        {
            dataGridViewX1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;  //奇数行颜色
            dataGridViewX1.AutoGenerateColumns = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            txtReelid.Text = "";
            txtPn.Text = "";
            txtExceedStart.Text = "";
            txtExceedEnd.Text = "";
            txtSerialNoStart.Text = "";
            txtSerialNoEnd.Text = "";
            TextSupply.Text = "";
            lblShelfSide.Visible = false;
            cbMateType.SelectedIndex = 0;
            cmbArea.SelectedValue = -1;
            cbShelfSide.SelectedIndex = -1;
            cbShelfSide.Visible = false;
            cbMSD.SelectedIndex = -1;
            BoxStatus.SelectedIndex = -1;
            //DateTimePickerReset(dtpCycleStart);
            //DateTimePickerReset(dtpCycleEnd);
            DateTimePickerReset(dtpStart);
            DateTimePickerReset(dtpEnd);
            dataGridViewX1.DataSource = null;
        }

        private void DateTimePickerReset(DateTimePicker dtpicker)
        {
            dtpicker.Format = DateTimePickerFormat.Custom;
            dtpicker.CustomFormat = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGridViewX1);
        }

        public bool ExportToExcel(DataGridView dgvData)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "Export Excel File To";
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return false;
            }

            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string str = "";
            try
            {
                //写标题
                for (int i = 0; i < dgvData.ColumnCount; i++)
                {
                    if (i > 0)
                    {
                        str += "\t";
                    }
                    str += dgvData.Columns[i].HeaderText;
                }
                sw.WriteLine(str);
                //写内容
                for (int j = 0; j < dgvData.Rows.Count; j++)
                {
                    string tempStr = "";
                    for (int k = 0; k < dgvData.Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            tempStr += "\t";
                        }
                        if (dgvData.Rows[j].Cells[k].Value == null)
                        {
                            continue;
                        }
                        string cellValue = dgvData.Rows[j].Cells[k].Value.ToString();
                        //cellValue = cellValue.Replace(" ", ".ShowTips(); 
                        cellValue = cellValue.Replace("\r", "");
                        cellValue = cellValue.Replace("\n", "");
                        cellValue = cellValue.Replace("\r\n", "");
                        tempStr += cellValue;
                        // tempStr += dgvData.Rows[j].Cells[k].Value.ToString();
                    }

                    sw.WriteLine(tempStr);
                }
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }

            return true;


        }

        private void CmbArea_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int towerNo = Convert.ToInt32(cmbArea.SelectedValue);
            switch (towerNo)
            {
                case 1:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "巷道：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.BuildAbSide();
                    break;
                case 2:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.BuildLightShelf();
                    break;
                case 3:
                    lblShelfSide.Visible = false;
                    cbShelfSide.Visible = false;
                    cbShelfSide.SelectedIndex = -1;
                    break;
                case 4:
                    lblShelfSide.Visible = true;
                    lblShelfSide.Text = "货架：";
                    cbShelfSide.Visible = true;
                    cbShelfSide.DataSource = BuildComboxHelper.BuildTransformationShelf();
                    break;
                default:
                    lblShelfSide.Visible = false;
                    cbShelfSide.Visible = false;
                    cbShelfSide.SelectedIndex = -1;
                    break;
            }
        }

        private void txtExceed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private object lockSyncObj = new object();

        private void btnSync_Click(object sender, EventArgs e)
        {
            try
            {
                lock (lockSyncObj)
                {
                    DataTable dtBarcode = InOutStockStorageData.GetAllMaterial();
                    foreach (DataRow row in dtBarcode.Rows)
                    {
                        string barcode = Convert.ToString(row["ReelID"]);
                        string qrCode = Convert.ToString(row["QRCode"]);
                        if (string.IsNullOrWhiteSpace(qrCode))
                        {
                            continue;
                        }
                        int qty = 0;
                        string materialType = "F";
                        int miniPackage = 0;
                        int.TryParse(Convert.ToString(row["MinPacking"]), out miniPackage);
                        var material = CallMaterialInfoByUPN(qrCode);
                        if (material != null && int.TryParse(material.InvQty, out qty) && qty > 0)
                        {
                            if (miniPackage > 0)
                            {
                                decimal offset = miniPackage - qty;
                                if ((Math.Abs(offset) / miniPackage) * 1000 <= 3)
                                {
                                    materialType = "F";
                                }
                                else if ((offset / miniPackage) * 1000 > 3)
                                {
                                    materialType = "S";
                                }
                                else if (offset / miniPackage * 1000 < -3)
                                {
                                    materialType = "T";
                                }
                                else
                                {
                                    //do nothing
                                }
                            }
                            InOutStockStorageData.UpdateQtyFromMes(barcode, qty, materialType);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.GetDeepException().ShowError();
            }
        }

        public static MaterialInfoResponse CallMaterialInfoByUPN(string qrcode)
        {
            MaterialInfoResponse response = new MaterialInfoResponse();
            StringBuilder sb = new StringBuilder("请求MaterialInfo");
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/GetMaterial?qrcode={qrcode}";
                sb.AppendLine($"地址:{url}");
                string responseStr = WebClientHelper.Get(url);
                sb.AppendLine($"返回:[{responseStr}]");
                response = JsonConvert.DeserializeObject<MaterialInfoResponse>(responseStr);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"获取物料明细异常:[{ex.GetDeepException()}]");
            }
            FileLog.Log(sb.ToString());
            return response;
        }

        private void dataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dataGridViewX1.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dataGridViewX1.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dataGridViewX1.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void DataGridViewX1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (e.ColumnIndex == 1)
            {
                sb.Append(" Part_Number ");
            }
            else
            {
                sb.Append(" SaveTime ");
            }
            if (e.Clicks % 2 == 0)
            {
                sb.Append(" ASC ");
            }
            else
            {
                sb.Append(" DESC ");
            }

            orderBy = sb.ToString();
            GetOrders();
        }
    }
}

