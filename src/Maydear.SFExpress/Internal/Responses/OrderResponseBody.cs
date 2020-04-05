using System;
using System.Collections.Generic;
using System.Xml;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Responses
{
    /// <summary>
    /// 订单对象
    /// </summary>
    internal class OrderResponseBody : IResponseBody
    {
        /// <summary>
        /// 订单基础结果
        /// </summary>
        public ExpressOrderReceiptResult Result { get; set; }

        /// <summary>
        /// 解析报文并填充
        /// </summary>
        /// <param name="xmlDocument"></param>
        public void Fill(XmlDocument xmlDocument)
        {
            var orderResponseNodeList = xmlDocument.GetElementsByTagName("OrderResponse");

            if (orderResponseNodeList != null && orderResponseNodeList.Count > 0)
            {
                var orderResponse = orderResponseNodeList.Item(0);

                if (orderResponse != null)
                {
                    var dict = orderResponse.GetAttributes();
                    if (dict.ContainsKey("orderid") && dict.ContainsKey("mailno") && dict.ContainsKey("origincode") && dict.ContainsKey("destcode"))
                    {
                        Result = new ExpressOrderReceiptResult()
                        {
                            DestCode = dict["destcode"],
                            MailNo = dict["mailno"],
                            OrderId = dict["orderid"],
                            OriginCode = dict["origincode"]
                        };

                        if (dict.ContainsKey("remark"))
                        {
                            Result.Remark = dict["remark"];
                        }
                        if (dict.ContainsKey("filter_result"))
                        {
                            Result.FilterResult = dict["filter_result"].AsIntOrDefault(1);
                        }

                        var rlsInfoNodeList = xmlDocument.GetElementsByTagName("rls_info");

                        if (rlsInfoNodeList != null && rlsInfoNodeList.Count > 0)
                        {
                            var rlsInfoDict = rlsInfoNodeList.Item(0).GetAttributes();

                            if (rlsInfoDict != null && rlsInfoDict.ContainsKey("rls_code") && rlsInfoDict.ContainsKey("invoke_result"))
                            {
                                Result.RlsInfo = new ExpressOrderRlsInfo()
                                {
                                    InvokeResult = rlsInfoDict["invoke_result"],
                                    RlsCode = rlsInfoDict["rls_code"],
                                    ErrorDesc = rlsInfoDict["rls_errormsg"]
                                };
                                if (Result.RlsInfo.RlsCode.Equals("1000", StringComparison.OrdinalIgnoreCase))
                                {
                                    var rlsDetailNodeList = xmlDocument.GetElementsByTagName("rls_detail");

                                    if (rlsDetailNodeList != null && rlsDetailNodeList.Count > 0)
                                    {
                                        Result.RlsInfo.Detail = BuildDetail(rlsDetailNodeList.Item(0).GetAttributes());
                                    }
                                }

                            }

                        }

                    }
                }
            }
        }


        private ExpressOrderRlsDetail BuildDetail(IDictionary<string, string> keyValuesAttribute)
        {
            if (keyValuesAttribute != null && keyValuesAttribute.Count > 0)
            {
                return new ExpressOrderRlsDetail
                {
                    WaybillNo = keyValuesAttribute.ContainsKey("waybillNo") ? keyValuesAttribute["waybillNo"] : "",
                    SourceTransferCode = keyValuesAttribute.ContainsKey("sourceTransferCode") ? keyValuesAttribute["sourceTransferCode"] : "",
                    SourceCityCode = keyValuesAttribute.ContainsKey("sourceCityCode") ? keyValuesAttribute["sourceCityCode"] : "",
                    SourceDeptCode = keyValuesAttribute.ContainsKey("sourceDeptCode") ? keyValuesAttribute["sourceDeptCode"] : "",
                    SourceTeamCode = keyValuesAttribute.ContainsKey("sourceTeamCode") ? keyValuesAttribute["sourceTeamCode"] : "",
                    DestCityCode = keyValuesAttribute.ContainsKey("destCityCode") ? keyValuesAttribute["destCityCode"] : "",
                    DestDeptCode = keyValuesAttribute.ContainsKey("destDeptCode") ? keyValuesAttribute["destDeptCode"] : "",
                    DestDeptCodeMapping = keyValuesAttribute.ContainsKey("destDeptCodeMapping") ? keyValuesAttribute["destDeptCodeMapping"] : "",
                    DestTeamCode = keyValuesAttribute.ContainsKey("destTeamCode") ? keyValuesAttribute["destTeamCode"] : "",
                    DestTeamCodeMapping = keyValuesAttribute.ContainsKey("destTeamCodeMapping") ? keyValuesAttribute["destTeamCodeMapping"] : "",
                    DestTransferCode = keyValuesAttribute.ContainsKey("destTransferCode") ? keyValuesAttribute["destTransferCode"] : "",
                    DestRouteLabel = keyValuesAttribute.ContainsKey("destRouteLabel") ? keyValuesAttribute["destRouteLabel"] : "",
                    ProName = keyValuesAttribute.ContainsKey("proName") ? keyValuesAttribute["proName"] : "",
                    CargoTypeCode = keyValuesAttribute.ContainsKey("cargoTypeCode") ? keyValuesAttribute["cargoTypeCode"] : "",
                    LimitTypeCode = keyValuesAttribute.ContainsKey("limitTypeCode") ? keyValuesAttribute["limitTypeCode"] : "",
                    ExpressTypeCode = keyValuesAttribute.ContainsKey("expressTypeCode") ? keyValuesAttribute["expressTypeCode"] : "",
                    CodingMapping = keyValuesAttribute.ContainsKey("codingMapping") ? keyValuesAttribute["codingMapping"] : "",
                    CodingMappingOut = keyValuesAttribute.ContainsKey("codingMappingOut") ? keyValuesAttribute["codingMappingOut"] : "",
                    XbFlag = keyValuesAttribute.ContainsKey("xbFlag") ? keyValuesAttribute["xbFlag"].AsIntOrNull() : null,
                    PrintFlag = keyValuesAttribute.ContainsKey("printFlag") ? keyValuesAttribute["printFlag"] : "",
                    TwoDimensionCode = keyValuesAttribute.ContainsKey("twoDimensionCode") ? keyValuesAttribute["twoDimensionCode"] : "",
                    ProCode = keyValuesAttribute.ContainsKey("proCode") ? keyValuesAttribute["proCode"] : "",
                    PrintIcon = keyValuesAttribute.ContainsKey("printIcon") ? keyValuesAttribute["printIcon"] : "",
                    AbFlag = keyValuesAttribute.ContainsKey("abFlag") ? keyValuesAttribute["abFlag"] : "",
                    ErrMsg = keyValuesAttribute.ContainsKey("errMsg") ? keyValuesAttribute["errMsg"] : "",
                    DestPortCode = keyValuesAttribute.ContainsKey("destPortCode") ? keyValuesAttribute["destPortCode"] : "",
                    DestCountry = keyValuesAttribute.ContainsKey("destCountry") ? keyValuesAttribute["destCountry"] : "",
                    DestPostCode = keyValuesAttribute.ContainsKey("destPostCode") ? keyValuesAttribute["destPostCode"] : "",
                    GoodsValueTotal = keyValuesAttribute.ContainsKey("goodsValueTotal") ? keyValuesAttribute["goodsValueTotal"] : "",
                    CurrencySymbol = keyValuesAttribute.ContainsKey("currencySymbol") ? keyValuesAttribute["currencySymbol"] : "",
                    GoodsNumber = keyValuesAttribute.ContainsKey("goodsNumber") ? keyValuesAttribute["goodsNumber"] : "",
                    CheckCode = keyValuesAttribute.ContainsKey("checkCode") ? keyValuesAttribute["checkCode"] : ""
                };
            }


            return null;
        }
    }
}
