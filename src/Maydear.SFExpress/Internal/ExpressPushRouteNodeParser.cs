using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal
{
    internal static class ExpressPushRouteNodeParser
    {
        public static ExpressPushRouteNode Parse(string xmlString)
        {
            XmlDocument xmlDocument = xmlString?.ToXmlDocument();

            if (xmlDocument == null)
                return null;

            var requestNodeList = xmlDocument.GetElementsByTagName("WaybillRoute");
            if (requestNodeList?.Count > 0)
            {
                var dict = requestNodeList[0].GetAttributes();

                if (dict != null && dict.Count > 0)
                {
                    if (dict.ContainsKey("id") &&
                        dict.ContainsKey("mailno") &&
                        dict.ContainsKey("orderid") &&
                        dict.ContainsKey("acceptTime") &&
                        dict.ContainsKey("acceptAddress") &&
                        dict.ContainsKey("remark"))
                    {
                        var expressPushRouteNode = new ExpressPushRouteNode()
                        {
                            MailNo = dict["mailno"],
                            Id =long.Parse(dict["id"]),
                            OrderId = dict["orderid"],
                            AcceptAddress = dict["acceptAddress"],
                            AcceptTime = DateTime.ParseExact(dict["acceptTime"], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                            Remark = dict["remark"],
                        };

                        if (dict.ContainsKey("opCode"))
                        {
                            var opCode = dict["opCode"];

                            if(!opCode.IsNullOrWhiteSpace() && opCode.IsNumber())
                            {
                                expressPushRouteNode.OperateCode = (RouteOperateCode)opCode.AsIntOrDefault();
                            }
                        }

                        return expressPushRouteNode;
                    }
                }
            }

            return null;
        }
    }
}
