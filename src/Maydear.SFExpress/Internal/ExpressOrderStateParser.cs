using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal
{
    internal static class ExpressOrderStateParser
    {
        public static ExpressOrderState Parse(string xmlString)
        {
            XmlDocument xmlDocument = xmlString?.ToXmlDocument();

            if (xmlDocument == null)
                return null;

            var requestNodeList = xmlDocument.GetElementsByTagName("Request");

            if (requestNodeList?.Count > 0)
            {
                var dict = requestNodeList[0].GetAttributes();

                if(dict !=null && dict.Count>0)
                {
                    if (dict.ContainsKey("carrierCode") && dict.ContainsKey("waybillNo") && dict.ContainsKey("orderStateCode") && dict.ContainsKey("orderStateDesc"))
                    {
                        var expressOrderState = new ExpressOrderState()
                        {
                            MailNo = dict["waybillNo"],
                            OrderStateCode = dict["orderStateCode"],
                            OrderStateDesc = dict["orderStateDesc"],
                            CarrierCode = dict["carrierCode"]
                        };

                        if(dict.ContainsKey("orderNo"))
                        {
                            expressOrderState.OrderId = dict["orderNo"];
                        }
                        if (dict.ContainsKey("empPhone"))
                        {
                            expressOrderState.EmpPhone = dict["empPhone"];
                        }
                        if (dict.ContainsKey("empCode"))
                        {
                            expressOrderState.EmpCode = dict["empCode"];
                        }
                        if (dict.ContainsKey("netCode"))
                        {
                            expressOrderState.NetCode = dict["netCode"];
                        }
                        if (dict.ContainsKey("lastTime"))
                        {
                            expressOrderState.LastTime = DateTime.ParseExact(dict["lastTime"], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        }
                        if (dict.ContainsKey("bookTime"))
                        {
                            expressOrderState.BookTime = DateTime.ParseExact(dict["bookTime"], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                        }

                        return expressOrderState;
                    }
                }
            }

            return null;
        }
    }
}
