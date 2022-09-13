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
        public static CheckResultResponse CheckFromMaterialInfo(string qrcode)
        {
            CheckResultResponse checkResult = new CheckResultResponse();
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

        #region 请求MES校验执行发料
        public static CheckResultResponse CheckFromMesExecuteDispatch(List<ReviewSummary> summaryList, string userCode, string userName)
        {
            CheckResultResponse checkResult = new CheckResultResponse();
            if (summaryList.Count == 0)
            {
                return checkResult;
            }
            MesExecuteDispatchRequest request = new MesExecuteDispatchRequest
            {
                pickOrderId = summaryList[0].OrderNo,
                workName = userName,
                workNmber = userCode,
                upnInfoList = summaryList.Select(p => new MesExecuteDispatchUpnInfo
                {
                    invLotId = p.UPN,
                    matId = p.PartNumber,
                    qty = p.RealQty
                }).ToList(),
            };

            checkResult.Result = CallMesWmsApiBll.CallMesExecuteDispatch(request);
            if (!checkResult.Result)
            {
                checkResult.ErrMessage = "请求MES校验执行发料接口调用失败";
            }
            FileLog.Log($"请求MES校验执行发料【{JsonConvert.SerializeObject(checkResult)}】");
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
