using Entity.Facade;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using TirionWinfromFrame.Commons;

namespace Business
{
    public class CallMesWmsApiBll
    {
        #region Mes物料信息接口 验证
        public static MaterialInfoResponse CallMaterialInfoByUPN(string qrcode)
        {
            MaterialInfoResponse response = new MaterialInfoResponse();
            StringBuilder sb = new StringBuilder("请求MaterialInfo");
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/GetMaterial?qrcode={qrcode}";
                sb.AppendLine($"地址:{url}");
                string responseStr = WebClientHelper.Get(url);
                sb.AppendLine($"返回:{responseStr}");
                response = JsonConvert.DeserializeObject<MaterialInfoResponse>(responseStr);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
            }
            FileLog.Log(sb.ToString());
            return response;
        }
        #endregion

        #region MSD物料是否过期 校验
        public static CheckResultResponse CallMSDExpired(string upn)
        {
            StringBuilder sb = new StringBuilder("请求MSDExpired");
            var result = new CheckResultResponse();
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/CheckUpnMsdExpired/{upn}";
                sb.AppendLine($"地址:{url}");
                string responseStr = WebClientHelper.Get(url);
                sb.AppendLine($"返回:{responseStr}");
                result = JsonConvert.DeserializeObject<CheckResultResponse>(responseStr);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
                result.ErrMessage = ex.Message;
            }
            FileLog.Log(sb.ToString());
            return result;
        }
        #endregion

        #region 总装MES物料退料接口 验证
        public static CheckResultResponse CallMesMaterialBack(string upn, int quantity)
        {
            StringBuilder sb = new StringBuilder("请求MesMaterialBack");
            var result = new CheckResultResponse();
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/MESMaterialBack";
                sb.AppendLine($"地址:{url}");
                MesRefundRequest request = new MesRefundRequest
                {
                    upn = upn,
                    rtnNumber = quantity.ToString()
                };
                string requestJson = JsonConvert.SerializeObject(request);
                sb.AppendLine($"请求参数:{requestJson}");
                string strResponse = WebClientHelper.Post(JsonConvert.SerializeObject(request), url, null);
                sb.AppendLine($"返回:{strResponse}");
                result = JsonConvert.DeserializeObject<CheckResultResponse>(strResponse);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
                result.ErrMessage = ex.Message;
            }
            FileLog.Log(sb.ToString());
            return result;
        }
        #endregion

        #region 请求总装mes iqc比对接口  验证
        public static CheckResultResponse CallMesIqcCompare(string barcode, string original)
        {
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return new CheckResultResponse() { Result = true };
            }
            StringBuilder sb = new StringBuilder("请求MesIqcCompare");
            var result = new CheckResultResponse();
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/MESIQCCompare";
                sb.AppendLine($"地址:{url}");
                MesIqcCompareRequest request = new MesIqcCompareRequest
                {
                    vendorSpec = original,
                    labelId = barcode
                };
                string requestJson = JsonConvert.SerializeObject(request);
                sb.AppendLine($"请求参数:{requestJson}");
                string strResponse = WebClientHelper.Post(JsonConvert.SerializeObject(request), url, null);
                sb.AppendLine($"返回:{strResponse}");
                result = JsonConvert.DeserializeObject<CheckResultResponse>(strResponse);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
                result.ErrMessage = ex.Message;
            }
            FileLog.Log(sb.ToString());
            return result;
        }
        #endregion

        #region 请求MES校验UPN接口 验证
        public static CheckResultResponse CallMesCheckUpn(string barcode, string orderNo)
        {
            StringBuilder sb = new StringBuilder("请求MesCheckUpn");
            var result = new CheckResultResponse();
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/CheckUpn/{WebUtility.UrlEncode(barcode)}?pickOrderId={orderNo}";
                sb.AppendLine($"地址:{url}");
                string strResponse = WebClientHelper.Get(url);
                sb.AppendLine($"返回:{strResponse}");
                result = JsonConvert.DeserializeObject<CheckResultResponse>(strResponse);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
                result.ErrMessage = ex.Message;
            }
            FileLog.Log(sb.ToString());
            return result;
        }
        #endregion

        #region 请求MES校验执行发料
        public static bool CallMesExecuteDispatch(MesExecuteDispatchRequest request)
        {
            StringBuilder sb = new StringBuilder("请求MesExcuteDispatch");
            bool result = false;
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/ExecuteDispatchToMES";
                sb.AppendLine($"地址:{url}");
                string requestJson = JsonConvert.SerializeObject(request);
                sb.AppendLine($"请求参数:{requestJson}");
                string strResponse = WebClientHelper.Post(JsonConvert.SerializeObject(request), url, null);
                sb.AppendLine($"返回:{strResponse}");
                result = Convert.ToBoolean(strResponse);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
            }
            FileLog.Log(sb.ToString());
            return result;
        }
        #endregion

        #region 产线退料数量回传
        public static XtaryBackQtyResponse CallXtrayBackQty(XtaryBackQtyRequest request)
        {
            StringBuilder sb = new StringBuilder("请求产线退料数量回传接口");
            XtaryBackQtyResponse response = new XtaryBackQtyResponse();
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/IWms/XtrayBackQty";
                sb.AppendLine($"地址:{url}");
                string requestJson = JsonConvert.SerializeObject(request);
                sb.AppendLine($"请求参数:{requestJson}");
                string strResponse = WebClientHelper.Post(JsonConvert.SerializeObject(request), url, null);
                sb.AppendLine($"返回:{strResponse}");
                response = JsonConvert.DeserializeObject<XtaryBackQtyResponse>(strResponse);
                //result = (response != null && response.Result.Equals("OK")) ? true : false;
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
            }
            FileLog.Log(sb.ToString());
            return response;
        }
        #endregion

        #region 根据upn获取散料校验结果接口
        public static CheckResultResponse CallMatStatusAccordingUpn(string upn)
        {
            StringBuilder sb = new StringBuilder("请求MatStatusAccordingUpn");
            var result = new CheckResultResponse();
            try
            {
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Material/GetMatStatusAccordingUpn/{upn}";
                sb.AppendLine($"地址:{url}");
                string strResponse = WebClientHelper.Get(url);
                sb.AppendLine($"返回:{strResponse}");
                result = JsonConvert.DeserializeObject<CheckResultResponse>(strResponse);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"异常:{ex.Message}");
                result.ErrMessage = ex.Message;
            }
            FileLog.Log(sb.ToString());
            return result;
        }
        #endregion

        public static PagedList<RequestLog> GetLogs(string requestKey, DateTime dt)
        {
            StringBuilder sb = new StringBuilder("获取日志");
            try
            {
                var request = new LogModel()
                {
                    LogKey = requestKey,
                    Level = "Info",
                    StartDate = dt.Date.ToString("yyyy-MM-dd"),
                    EndDate = dt.Date.AddDays(1).ToString("yyyy-MM-dd"),
                    Pagination = new Pagination() { ItemsPerPage = 30, Page = 1 },
                };
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Log/GetPagedList";
                string requestJson = JsonConvert.SerializeObject(request);
                string strResponse = WebClientHelper.Post(requestJson, url, null);
                return JsonConvert.DeserializeObject<PagedList<RequestLog>>(strResponse);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"ex:{ex.GetDeepException()}");
                return null;
            }
            finally
            {
                FileLog.Log(sb.ToString());
            }
        }

        public static FeedbackResponse FeedbackOrder(string deliveryNo, string deliveryType, string lineId)
        {
            StringBuilder sb = new StringBuilder("出库复核反馈");
            try
            {
                var request = new DeliveryOrderFeedback()
                {
                    DeliveryNo = deliveryNo,
                    DeliveryType = deliveryType,
                    LineId = lineId
                };
                string url = $"{ConfigurationManager.AppSettings["iwms_api_url"]}/api/Review/FeedbackOrder";
                sb.AppendLine($"url:{url}");
                string requestJson = JsonConvert.SerializeObject(request);
                sb.AppendLine($"request:{requestJson}");
                string strResponse = WebClientHelper.Post(requestJson, url, null);
                sb.AppendLine($"response:{strResponse}");
                return JsonConvert.DeserializeObject<FeedbackResponse>(strResponse);
            }
            catch (Exception ex)
            {
                sb.AppendLine($"ex:{ex.GetDeepException()}");
                return new FeedbackResponse() { Message = ex.Message };
            }
            finally
            {
                FileLog.Log(sb.ToString());
            }

        }
    }
    /// <summary>
    /// 分页列表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> where T : class, new()
    {
        /// <summary>
        /// 列表
        /// </summary>
        public IEnumerable<T> List { get; set; }

        /// <summary>
        /// 总条数
        /// </summary>
        public long Count { get; set; }

        /// <summary>
        /// 当前分页
        /// </summary>
        public Pagination Current { get; set; }
    }

    public class RequestLog
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public string Level { get; set; } = string.Empty;

        /// <summary>
        /// 日志
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 请求体
        /// </summary>
        public string RequestBody { get; set; }

        /// <summary>
        /// 返回值
        /// </summary>
        public string ResponseBody { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long Timestamp { get; set; } = 0;
    }

    /// <summary>
    /// 日志查询条件
    /// </summary>
    public class LogModel
    {

        /// <summary>
        /// 分页
        /// </summary>
        public Pagination Pagination { get; set; }

        /// <summary>
        /// 日志等级
        /// </summary>
        public string Level { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartDate { get; set; }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string EndDate { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 请求消息
        /// </summary>
        public string RequestBody { get; set; }

        public string LogKey { get; set; }
    }

    /// <summary>
    /// 分页
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// 条数
        /// </summary>
        public int ItemsPerPage { get; set; }
    }

    public class XtaryBackQtyRequest : XtaryBackQtyData
    {
    }

    public class XtaryBackQtyResponse
    {
        public string Result { get; set; }
        public XtaryBackQtyData Data { get; set; }
        public string Message { get; set; }
    }

    public class XtaryBackQtyData
    {
        public string upn { get; set; }
        public int qty { get; set; }
        public string reelSize { get; set; }
        public string status { get; set; }
        public string thickness { get; set; }
        public string minPacking { get; set; }
        public string cycle { get; set; }
        public string batch { get; set; }
        public string storeId { get; set; }
        public string reelType { get; set; }
        public string matType { get; set; }
        public string msd { get; set; }
        public string msdOverdue { get; set; }

        [JsonProperty("lock")]
        public string _lock { get; set; }
    }

    public class MesIqcCompareRequest
    {
        public string vendorSpec { get; set; } = string.Empty;

        public string labelId { get; set; } = string.Empty;
    }

    public class MesRefundRequest
    {
        /// <summary>
        /// 是否upn
        /// </summary>
        public string ifUpn { get; set; } = "Y";

        /// <summary>
        /// 
        /// </summary>
        public string reiectedMatArea { get; set; } = "0";

        /// <summary>
        /// 数量
        /// </summary>
        public string rtnNumber { get; set; }

        /// <summary>
        /// UPN
        /// </summary>
        public string upn { get; set; }
    }

    public class MesExecuteDispatchRequest
    {
        public List<MesExecuteDispatchUpnInfo> upnInfoList { get; set; }
        public string pickOrderId { get; set; }
        /// <summary>
        /// 操作人工号
        /// </summary>
        public string workNmber { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string workName { get; set; }
        /// <summary>
        /// 标识
        /// </summary>
        public string procstep { get; set; } = "2";
    }

    public class MesExecuteDispatchUpnInfo
    {
        public string invLotId { get; set; }
        public string matId { get; set; }
        public int qty { get; set; }
        public string lockFlag { get; set; } = "N";
    }

    /// <summary>
    /// mes物料信息
    /// </summary>
    public class MaterialInfoResponse
    {
        /// <summary>
        /// UPN
        /// </summary>
        public string InvLotId { get; set; } = string.Empty;
        /// <summary>
        /// 数量
        /// </summary>
        public string InvQty { get; set; } = string.Empty;
        /// <summary>
        /// 最小包装数
        /// </summary>
        public string MinPacking { get; set; } = string.Empty;
        /// <summary>
        /// 最大包装数
        /// </summary>
        public string MaxPacking { get; set; } = string.Empty;
        /// <summary>
        /// 物料编码
        /// </summary>
        public string InvMatId { get; set; } = string.Empty;
        /// <summary>
        /// 供应商批次
        /// </summary>
        public string BatchId { get; set; } = string.Empty;
        /// <summary>
        /// 物料类型
        /// </summary>
        public string InvMatType { get; set; } = string.Empty;
        public string MSD { get; set; } = string.Empty;
        /// <summary>
        /// 是否锁定
        /// </summary>
        public string HoldFlag { get; set; } = string.Empty;


        public string VendorId { get; set; } = string.Empty;
        public string InvMatIdDesc { get; set; } = string.Empty;
        public string ProdPeriod { get; set; } = string.Empty;
        public string ProdDate { get; set; } = string.Empty;
        /// <summary>
        /// 站位
        /// </summary>
        public string StoreId { get; set; } = string.Empty;
        public string PInvLotId { get; set; } = string.Empty;
        public string InfCmf1 { get; set; } = string.Empty;
        public string InfCmf2 { get; set; } = string.Empty;
        public string InfCmf3 { get; set; } = string.Empty;
        public string InfCmf4 { get; set; } = string.Empty;
        public string InfCmf5 { get; set; } = string.Empty;
        public string InfCmf6 { get; set; } = string.Empty;
        public string InfCmf7 { get; set; } = string.Empty;
        public string InfCmf8 { get; set; } = string.Empty;
        public string InfCmf9 { get; set; } = string.Empty;
        public string InfCmf10 { get; set; } = string.Empty;
        public string SyncDate { get; set; } = string.Empty;
    }
}
