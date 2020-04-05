using System;
using System.Xml;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Responses
{
    /// <summary>
    /// 订单基础返回对象
    /// </summary>
    internal class OrderBaseResponseBody : IResponseBody
    {
        /// <summary>
        /// 订单基础结果
        /// </summary>
        public ExpressOrderBaseResult Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlDocument"></param>
        public void Fill(XmlDocument xmlDocument)
        {
            var orderResponseNodeList = xmlDocument.GetElementsByTagName("OrderResponse");

            if (orderResponseNodeList.Count > 0)
            {
                var orderResponse = orderResponseNodeList.Item(0);

                if (orderResponse != null)
                {
                    var dict = orderResponse.GetAttributes();
                    if (dict.ContainsKey("orderid") && dict.ContainsKey("mailno") && dict.ContainsKey("origincode") && dict.ContainsKey("destcode"))
                    {
                        Result = new ExpressOrderBaseResult()
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
                    }
                }
            }
        }
    }
}
