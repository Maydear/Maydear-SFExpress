using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Requests
{
    /// <summary>
    /// 订单筛选结果实体
    /// </summary>
    internal class OrderFilterResponseBody : IResponseBody
    {
        /// <summary>
        /// 订单筛选结果
        /// </summary>
        public ExpressOrderFilterResult Result { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlDocument"></param>
        public void Fill(XmlDocument xmlDocument)
        {
            var orderResponseNodeList = xmlDocument.GetElementsByTagName("OrderFilterResponse");

            if (orderResponseNodeList.Count > 0)
            {
                var orderResponse = orderResponseNodeList.Item(0);

                if (orderResponse != null)
                {
                    var dict = orderResponse.GetAttributes();
                    if (dict.ContainsKey("orderid"))
                    {
                        Result = new ExpressOrderFilterResult()
                        {
                            OrderId = dict["orderid"]
                        };
                        if (dict.ContainsKey("filter_result"))
                        {
                            Result.FilterType = (FilterType)int.Parse(dict["filter_result"]);
                        }
                        if (dict.ContainsKey("origincode"))
                        {
                            Result.OriginCode = dict["origincode"];
                        }
                        if (dict.ContainsKey("destcode"))
                        {
                            Result.DestCode = dict["destcode"];
                        }
                        if (dict.ContainsKey("remark"))
                        {
                            Result.Remark = (NotAllowedReason)int.Parse(dict["remark"]); ;
                        }
                    }
                }
            }
        }
    }
}
