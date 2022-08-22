using Business;
using Entity.Dto;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirionWinfromFrame.Profiles
{
    public static class MapperProfile
    {
        public static void ConfigGlobalMapper()
        {
            //TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            //TypeAdapterConfig<Wms_InstockOrder, InstockOrderDto>
            //    .NewConfig();
            ////.Ignore(dest => dest.Age)
            ////.Map(dest => dest.FullName,
            ////    src => string.Format("{0} {1}", src.FirstName, src.LastName));
            //TypeAdapterConfig<Wms_InstockDetail, InstockDetailDto>
            //    .NewConfig();

            //TypeAdapterConfig<Wms_TransferOrder, TransferOrderDto>
            //    .NewConfig();
            //TypeAdapterConfig<Wms_TransferBarcode, TransferBarcodeDto>
            //    .NewConfig()
            //.Map(dest => dest.TransferId, src => src.TransferOrderId)
            //.Map(dest => dest.Barcode, src => src.Barcode)
            //.Map(dest => dest.MaterialNo, src => src.MaterialNo)
            //.Map(dest => dest.Qty, src => src.TransferQuantity)
            //.Map(dest => dest.BarcodeStatus, src => src.OrderStatus);

            //TypeAdapterConfig<Wms_DeliveryOrder, DeliveryOrderDto>
            //    .NewConfig();
            //TypeAdapterConfig<Wms_DeliveryDetail, DeliveryDetailDto>
            //    .NewConfig();
            //TypeAdapterConfig<Wms_DeliveryBarcode, DeliveryBarcodeDto>
            //    .NewConfig();


            //TypeAdapterConfig<Wms_InventoryOrder, InventoryOrderDto>
            //    .NewConfig();
            //TypeAdapterConfig<Wms_InventoryBarcode, InventoryBarcodeDto>
            //    .NewConfig();

            //TypeAdapterConfig<Wms_DeliveryOrder, OutStockDdlItem>
            //    .NewConfig()
            //.Map(dest => dest.DeliveryId, src => src.BusinessId)
            //.Map(dest => dest.DestinationNo, src => src.LineId)
            //.Map(dest => dest.OrderNo, src => src.DeliveryNo)
            //.Map(dest => dest.Type2, src => src.DeliveryType);

            //TypeAdapterConfig<WmsLog, LogDto>
            //    .NewConfig()
            //.Map(dest => dest.LogTime, src => src.Date);

            TypeAdapterConfig<RequestLog, LogDto>
                .NewConfig()
            .Map(dest => dest.LogTime, src => src.Date)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.LogTitle, src => src.Message)
            .Map(dest => dest.RequestBody, src => src.RequestBody)
            .Map(dest => dest.ResponseBody, src => src.ResponseBody);

        }

    }
}
