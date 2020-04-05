using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Requests
{
    /// <summary>
    /// 
    /// </summary>
    internal class RouteRequestBody : IRequestBody
    {
        public RouteRequestBody(ExpressRoute expressRoute)
        {
            Data = expressRoute;
        }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName => "RouteService";

        /// <summary>
        /// 路由
        /// </summary>
        public ExpressRoute Data { get; private set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            return $@"<RouteRequest {string.Join(" ", BuidAttributesMap().Select(a => $"{a.Key}='{a.Value}'"))} />";
        }

        /// <summary>
        /// 构造路由信息的属性键值对
        /// </summary>
        /// <returns>返回属性键值对</returns>
        private IDictionary<string, string> BuidAttributesMap()
        {
            if (Data == null)
            {
                throw new ArgumentNullException("Route object mast not null");
            }
            if (Data.TrackingNumber.IsNotEmpty())
            {
                throw new ArgumentNullException("Route.TrackingNumber mast not Empty");
            }
            var dic = new Dictionary<string, string>() {
                { "tracking_type",((int)Data.TrackingType).ToString()},
                { "method_type",((int)Data.MethodType).ToString()}
            };
            dic.Add("tracking_number", string.Join(",", Data.TrackingNumber));

            if (!Data.ReferenceNumber.IsNullOrWhiteSpace())
            {
                dic.Add("reference_number", Data.ReferenceNumber);
            }

            if (!Data.CheckPhoneNo.IsNotEmpty())
            {
                dic.Add("check_phoneNo", string.Join(",", Data.CheckPhoneNo));
            }
            return dic;
        }
    }
}
