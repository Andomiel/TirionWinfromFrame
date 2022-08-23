using Business;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class OrderReviewCallApi
    {
        #region Mes物料信息接口 验证
        public static ReviewCheckResult CheckFromMaterialInfo(string qrcode)
        {
            ReviewCheckResult checkResult = new ReviewCheckResult();
            MaterialInfoResponse response = CallMesWmsApiBll.CallMaterialInfoByUPN(qrcode);
            if (response.StoreId != null && response.StoreId.Equals("365"))
            {
                checkResult.IsPass = false;
                checkResult.Msg = "站位是365";
            }
            else if (response.HoldFlag != null && response.HoldFlag.ToUpper().Equals("Y"))
            {
                checkResult.IsPass = false;
                checkResult.Msg = "锁定料";
            }
            FileLog.Log($"Mes物料信息接口 验证【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region MSD物料是否过期 校验
        public static ReviewCheckResult CheckFromMSDExpired(string upn)
        {
            ReviewCheckResult checkResult = new ReviewCheckResult();
            checkResult.IsPass = CallMesWmsApiBll.CallMSDExpired(upn);
            if (!checkResult.IsPass)
            {
                checkResult.Msg = "MSD物料是否过期校验失败";
            }
            FileLog.Log($"MSD物料是否过期校验【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region 总装MES物料退料接口 验证
        public static ReviewCheckResult CheckFromMesMaterialBack(string upn, int quantity)
        {
            ReviewCheckResult checkResult = new ReviewCheckResult();
            checkResult.IsPass = CallMesWmsApiBll.CallMesMaterialBack(upn, quantity);
            if (!checkResult.IsPass)
            {
                checkResult.Msg = "总装MES物料退料接口调用失败";
            }
            FileLog.Log($"总装MES物料退料接口 验证【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }

        #endregion

        #region 请求总装mes iqc比对接口  验证
        public static ReviewCheckResult CheckFromMesIqcCompare(string barcode, string original)
        {
            ReviewCheckResult checkResult = new ReviewCheckResult();
            checkResult.IsPass = CallMesWmsApiBll.CallMesIqcCompare(barcode, original);
            if (!checkResult.IsPass)
            {
                checkResult.Msg = "总装MES IQC物料比对接口调用失败";
            }
            FileLog.Log($"总装mes iqc比对接口  验证【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region 请求MES校验UPN接口 验证
        public static ReviewCheckResult CheckFromMesCheckUpn(string barcode, string orderNo)
        {
            ReviewCheckResult checkResult = new ReviewCheckResult();
            checkResult.IsPass = CallMesWmsApiBll.CallMesCheckUpn(barcode, orderNo);
            if (!checkResult.IsPass)
            {
                checkResult.Msg = "MES校验UPN接口调用失败";
            }
            FileLog.Log($"MES校验UPN接口【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region 请求MES校验执行发料
        public static ReviewCheckResult CheckFromMesExecuteDispatch(List<ReviewSummary> summaryList, string userCode, string userName)
        {
            ReviewCheckResult checkResult = new ReviewCheckResult();
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

            checkResult.IsPass = CallMesWmsApiBll.CallMesExecuteDispatch(request);
            if (!checkResult.IsPass)
            {
                checkResult.Msg = "请求MES校验执行发料接口调用失败";
            }
            FileLog.Log($"请求MES校验执行发料【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion

        #region 根据upn获取散料校验结果接口
        public static ReviewCheckResult CheckMatStatusAccordingUpn(string upn)
        {
            ReviewCheckResult checkResult = new ReviewCheckResult();
            checkResult.IsPass = CallMesWmsApiBll.CallMatStatusAccordingUpn(upn);
            if (!checkResult.IsPass)
            {
                checkResult.Msg = "物料未做散料测试";
            }
            FileLog.Log($"根据upn获取散料校验结果接口【{JsonConvert.SerializeObject(checkResult)}】");
            return checkResult;
        }
        #endregion
    }

    public class ReviewCheckResult
    {
        /// <summary>
        /// 是否验证通过
        /// </summary>
        public bool IsPass { get; set; } = true;
        /// <summary>
        /// 验证结果信息，通过为string.empty
        /// </summary>
        public string Msg { get; set; } = string.Empty;
    }
}
