using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Requests
{
    /// <summary>
    /// 订单确认/取消结果实体
    /// </summary>
    internal class OrderConfirmResponseBody : IResponseBody
    {
        /// <summary>
        /// 订单确认/取消结果
        /// </summary>
        public ExpressOrderConfirmResult Result { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlDocument"></param>
        public void Fill(XmlDocument xmlDocument)
        {
            var orderResponseNodeList = xmlDocument.GetElementsByTagName("OrderConfirmResponse");

            if (orderResponseNodeList.Count > 0)
            {
                var orderResponse = orderResponseNodeList.Item(0);

                if (orderResponse != null)
                {
                    var dict = orderResponse.GetAttributes();
                    if (dict.ContainsKey("orderid"))
                    {
                        Result = new ExpressOrderConfirmResult()
                        {
                            OrderId = dict["orderid"]
                        };
                        if (dict.ContainsKey("mailno"))
                        {
                            Result.MailNo = dict["mailno"];
                        }
                        if (dict.ContainsKey("res_status"))
                        {
                            Result.ResStatus = dict["res_status"].Equals("2", StringComparison.OrdinalIgnoreCase);
                        }
                    }
                }
            }
        }
    }
}
