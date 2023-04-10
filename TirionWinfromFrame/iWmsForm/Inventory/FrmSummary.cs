using Business;
using DevExpress.XtraSplashScreen;
using Entity;
using Entity.Dto;
using Entity.Enums;
using Entity.Facade;
using MES;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public partial class FrmSummary : FrmBaseForm
    {
        private BindingList<CensusMaterialType> Barcodes = new BindingList<CensusMaterialType>();

        public FrmSummary()
        {
            InitializeComponent();

            gcSummary.DataSource = Barcodes;
        }

        private void GetOrders()
        {
            Barcodes.Clear();
            var inventory = InOutStockStorageData.GetMaterialCensus();
            var dict = inventory.OrderBy(p => p.Tower).ThenBy(p => p.SubArea).ThenBy(p => p.MaterialType)
                .GroupBy(p => new { p.Tower, p.SubArea, p.MaterialType }).Select(p => new CensusMaterialType()
                {

                    MaterialType = p.Key.MaterialType,
                    TotalQuantity = p.Sum(c => c.Quantity),
                    SubArea = p.Key.SubArea,
                    Tower = p.Key.Tower
                });
            foreach (var item in dict)
            {
                Barcodes.Add(item);
            }
        }

        private void FrmInStockDatailInfo_Load(object sender, EventArgs e)
        {
            GetOrders();
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            //int row1 = e.RowHandle1;
            //int row2 = e.RowHandle2;

            //DataRow firstRow = gridView1.GetDataRow(row1);
            //DataRow secondRow = gridView1.GetDataRow(row2);
            //e.Handled = firstRow == null || secondRow == null || Convert.ToString(firstRow["TotalQuantity"]) != Convert.ToString(secondRow["TotalQuantity"]);
        }
    }
}

