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
            var xmlDocument = xmlString?.ToXmlDocument();

            if (xmlDocument == null)
            {
                return null;
            }

            var requestNodeList = xmlDocument.GetElementsByTagName("Request");

            if (requestNodeList?.Count > 0)
            {
                var nodes = requestNodeList[0].ChildNodes;

                if (nodes != null && nodes.Count > 0)
                {
                    var dict = new Dictionary<string, string>();
                    foreach (XmlNode item in nodes)
                    {
                        if (!string.IsNullOrWhiteSpace(item.InnerText))
                        {
                            dict.Add(item.Name, item.InnerText);
                        }
                    }
                    if (dict.ContainsKey("carrierCode") && dict.ContainsKey("waybillNo") && dict.ContainsKey("orderStateCode") && dict.ContainsKey("orderStateDesc"))
                    {
                        var expressOrderState = new ExpressOrderState()
                        {
                            MailNo = dict["waybillNo"],
                            OrderStateCode = dict["orderStateCode"],
                            OrderStateDesc = dict["orderStateDesc"],
                            CarrierCode = dict["carrierCode"]
                        };

                        if (dict.ContainsKey("orderNo"))
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
