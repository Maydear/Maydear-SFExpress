using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Responses
{

    /// <summary>
    /// 路由信息
    /// </summary>
    internal class RouteResponseBody : IResponseBody
    {
        /// <summary>
        /// 路由组
        /// </summary>
        public IEnumerable<ExpressRouteGroup> Result { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlDocument"></param>
        public void Fill(XmlDocument xmlDocument)
        {
           var result = new List<ExpressRouteGroup>();

            var routeResponseNodeList = xmlDocument.GetElementsByTagName("RouteResponse");

            if (routeResponseNodeList != null)
            {
                foreach (XmlNode item in routeResponseNodeList)
                {
                    var attributes = item.Attributes;
                    if (attributes == null)
                    { continue; }
                    XmlAttribute mailno = attributes["mailno"];
                    var routeGroup = new ExpressRouteGroup()
                    {
                        MailNo = mailno?.Value
                    };
                    if (item.HasChildNodes)
                    {
                        var  routeNodes = new List<ExpressRouteNode>();

                        foreach (XmlNode route in item.ChildNodes)
                        {
                            if (route.Name.Equals("Route", StringComparison.OrdinalIgnoreCase))
                            {
                                var dict = route.GetAttributes();

                                if (dict != null && dict.ContainsKey("opcode"))
                                {
                                    ExpressRouteNode routeNode = new ExpressRouteNode()
                                    {
                                        OperateCode = (RouteOperateCode)int.Parse(dict["opcode"])
                                    };
                                    if (dict.ContainsKey("accept_address"))
                                    {
                                        routeNode.AcceptAddress = dict["accept_address"];
                                    }
                                    if (dict.ContainsKey("remark"))
                                    {
                                        routeNode.Remark = dict["remark"];
                                    }
                                    if (dict.ContainsKey("accept_time"))
                                    {
                                        routeNode.AcceptTime = DateTime.ParseExact(dict["accept_time"], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                                    }
                                    routeNodes.Add(routeNode);
                                }
                            }
                        }
                        routeGroup.Nodes = routeNodes;
                    }
                    result.Add(routeGroup);
                }
                Result = result;
            }
        }
    }
}
