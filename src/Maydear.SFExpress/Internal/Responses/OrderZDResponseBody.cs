using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Requests
{
    /// <summary>
    /// 子单号申请结果实体
    /// </summary>
    internal class OrderZDResponseBody : IResponseBody
    {
        /// <summary>
        /// 订单确认/取消结果
        /// </summary>
        public ExpressOrderZDResult Result { get; private set; }

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
                    if (dict.ContainsKey("orderid") && dict.ContainsKey("main_mailno") && dict.ContainsKey("mailno_zd"))
                    {
                        Result = new ExpressOrderZDResult()
                        {
                            OrderId = dict["orderid"],
                            MainMailNo = dict["main_mailno"],
                        };
                        if (dict["mailno_zd"].IndexOf(',') > 0)
                        {
                            Result.MailNoZD = dict["mailno_zd"].Split(',');
                        }
                        else
                        {
                            Result.MailNoZD = new List<string>() { dict["mailno_zd"] };
                        }

                    }
                }
            }
        }
    }
}
