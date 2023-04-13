using Business;
using Entity.Facade;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class OrderReviewCallApi
    {
        #region Mes物料信息接口 验证
        public static CheckResultResponse CheckFromMaterialInfo(string qrcode, int originQuantity)
        {
            CheckResultResponse checkResult = new CheckResultResponse() { Result = true };
            MaterialInfoResponse response = CallMesWmsApiBll.CallMaterialInfoByUPN(qrcode);
            if (response == null)
            {
                checkResult.Result = false;
                checkResult.ErrMessage = $"查询物料信息失败:{qrcode}";
            }
            else if (response.StoreId != null && response.StoreId.Equals("365"))
            {
                checkResult.Result = false;
                checkResult.ErrMessage = "站位是365";
            }
            else if (response.HoldFlag != null && response.HoldFlag.ToUpper().Equals("Y"))
            {
                checkResult.Result = false;
                checkResult.ErrMessage = "锁定料";
            }
            else if ((int)TypeParse.StrToDecimal(response.InvQty, 0) != originQuantity)
            {
                checkResult.Result = false;
                checkResult.ErrMessage = "本地数量与MES不一致";
            }
            else
            {
                checkResult.Result = true;
            }
            FileLog.Log($"Mes物料信息接口 验证【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region MSD物料是否过期 校验
        public static CheckResultResponse CheckFromMSDExpired(string upn)
        {
            CheckResultResponse checkResult = CallMesWmsApiBll.CallMSDExpired(upn);
            FileLog.Log($"MSD物料是否过期校验【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region 总装MES物料退料接口 验证
        public static CheckResultResponse CheckFromMesMaterialBack(string upn, int quantity)
        {
            CheckResultResponse checkResult = CallMesWmsApiBll.CallMesMaterialBack(upn, quantity);
            FileLog.Log($"总装MES物料退料接口 验证【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }

        #endregion

        #region 请求总装mes iqc比对接口  验证
        public static CheckResultResponse CheckFromMesIqcCompare(string barcode, string original)
        {
            CheckResultResponse checkResult = CallMesWmsApiBll.CallMesIqcCompare(barcode, original);
            FileLog.Log($"总装mes iqc比对接口  验证【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region 请求MES校验UPN接口 验证
        public static CheckResultResponse CheckFromMesCheckUpn(string barcode, string orderNo)
        {
            CheckResultResponse checkResult = CallMesWmsApiBll.CallMesCheckUpn(barcode, orderNo);

            FileLog.Log($"MES校验UPN接口【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region 根据upn获取散料校验结果接口
        public static CheckResultResponse CheckMatStatusAccordingUpn(string upn)
        {
            CheckResultResponse checkResult = CallMesWmsApiBll.CallMatStatusAccordingUpn(upn);
            FileLog.Log($"根据upn获取散料校验结果接口【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion
    }

}
