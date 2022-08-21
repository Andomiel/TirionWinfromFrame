using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using MES.Entity;
using WinformGeneralDeveloperFrame.Commons;

namespace MES
{
    public partial class MESDB : DbContext
    {
        public MESDB()
        : base("name=DB")
            //: base(EncodeHelper.AES_Decrypt(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
        {
        }
        public virtual DbSet<stockDataInfo> stockDataInfo { get; set; }
        public virtual DbSet<sysMenuInfo> sysMenuInfo { get; set; }
        public virtual DbSet<sysUserInfo> sysUserInfo { get; set; }
        public virtual DbSet<sysDictDataInfo> sysDictDataInfo { get; set; }
        public virtual DbSet<sysDictTypeInfo> sysDictTypeInfo { get; set; }
        public virtual DbSet<stockInfo> stockInfo { get; set; }
        public virtual DbSet<sysDeptInfo> sysDeptInfo { get; set; }
        public virtual DbSet<sysFunctionInfo> sysFunctionInfo { get; set; }
        public virtual DbSet<sysRoleInfo> sysRoleInfo { get; set; }
        public virtual DbSet<lotteryInfo> lotteryInfo { get; set; }
        public virtual DbSet<sysToolButtonInfo> sysToolButtonInfo { get; set; }
        public virtual DbSet<productInfo> productInfo { get; set; }

        public virtual DbSet<materialInfo> materialInfo { get; set; }

        public virtual DbSet<customerInfo> customerInfo { get; set; }


        public virtual DbSet<supplierInfo> supplierInfo { get; set; }

        public virtual DbSet<quotationInfo> quotationInfo { get; set; }


        public virtual DbSet<quotationdetailInfo> quotationdetailInfo { get; set; }

        public virtual DbSet<saleInfo> saleInfo { get; set; }

        public virtual DbSet<saledetailInfo> saledetailInfo { get; set; }

        public virtual DbSet<deliversaleInfo> deliversaleInfo { get; set; }

        public virtual DbSet<deliversaledetailInfo> deliversaledetailInfo { get; set; }

        public virtual DbSet<returnsaleInfo> returnsaleInfo { get; set; }

        public virtual DbSet<returnsaledetailInfo> returnsaledetailInfo { get; set; }

        public virtual DbSet<productBOMInfo> productBOMInfo { get; set; }

        public virtual DbSet<productBOMdetailInfo> productBOMdetailInfo { get; set; }

        public virtual DbSet<requisitionInfo> requisitionInfo { get; set; }

        public virtual DbSet<requisitiondetailInfo> requisitiondetailInfo { get; set; }

        public virtual DbSet<buyerInfo> buyerInfo { get; set; }

        public virtual DbSet<buyerdetailInfo> buyerdetailInfo { get; set; }

        public virtual DbSet<buyerreturnInfo> buyerreturnInfo { get; set; }

        public virtual DbSet<buyerreturndetailInfo> buyerreturndetailInfo { get; set; }

        public virtual DbSet<workorderInfo> workorderInfo { get; set; }

        public virtual DbSet<productionBOMInfo> productionBOMInfo { set; get; }


        public virtual DbSet<productionRequisitionInfo> productionRequisitionInfo { get; set; }

        public virtual DbSet<productionRequisitionDetailInfo> productionRequisitionDetailInfo { set; get; }

        public virtual DbSet<productionMaterialReturnInfo> productionMaterialReturnInfo { get; set; }

        public virtual DbSet<productionMaterialReturnDetailInfo> productionMaterialReturnDetailInfo { set; get; }

        public virtual DbSet<buyerInWarehouseInfo> buyerInWarehouseInfo { get; set; }

        public virtual DbSet<buyerInWarehouseDetailInfo> buyerInWarehouseDetailInfo { set; get; }


        public virtual DbSet<buyerOutWarehouseDetailInfo> buyerOutWarehouseDetailInfo { get; set; }

        public virtual DbSet<buyerOutWarehouseInfo> buyerOutWarehouseInfo { set; get; }

        public virtual DbSet<productMaterialOutWarehouseDetailInfo> productMaterialOutWarehouseDetailInfo { get; set; }

        public virtual DbSet<productMaterialOutWarehouseInfo> productMaterialOutWarehouseInfo { set; get; }

        public virtual DbSet<productMaterialInWarehouseDetailInfo> productMaterialInWarehouseDetailInfo { get; set; }

        public virtual DbSet<productMaterialInWarehouseInfo> productMaterialInWarehouseInfo { set; get; }

        public virtual DbSet<finishProductInInWarehouseInfo> finishProductInInWarehouseInfo { get; set; }

        public virtual DbSet<finishProductInInWarehouseDetailInfo> finishProductInInWarehouseDetailInfo { set; get; }

        public virtual DbSet<completionProductInWarehouseInfo> completionProductInWarehouseInfo { get; set; }

        public virtual DbSet<completionProductInWarehouseDetailInfo> completionProductInWarehouseDetailInfo { set; get; }

        public virtual DbSet<saleOutWarehouseInfo> saleOutWarehouseInfo { get; set; }

        public virtual DbSet<saleOutWarehouseDetailInfo> saleOutWarehouseDetailInfo { set; get; }
        public virtual DbSet<saleInWarehouseInfo> saleInWarehouseInfo { get; set; }

        public virtual DbSet<saleInWarehouseDetailInfo> saleInWarehouseDetailInfo { set; get; }

    }
}