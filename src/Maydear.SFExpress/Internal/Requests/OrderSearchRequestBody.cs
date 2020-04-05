using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Requests
{
    /// <summary>
    /// 查询实体
    /// </summary>
    internal class OrderSearchRequestBody : IRequestBody
    {
        public OrderSearchRequestBody(ExpressOrderSearch expressOrderSearch)
        {
            Data = expressOrderSearch;
        }

        /// <summary>
        /// 订单结果查询实体
        /// </summary>
        public ExpressOrderSearch Data { get; private set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName => "OrderSearchService";

        /// <summary>
        /// 输出Xml
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            return $@"<OrderSearch {string.Join(" ", BuidAttributesMap().Select(a => $"{a.Key}=\"{a.Value}\""))} />";
        }

        /// <summary>
        /// 构造订单结果查询实体键值对
        /// </summary>
        /// <returns>返回属性键值对</returns>
        private IDictionary<string, string> BuidAttributesMap()
        {
            if (Data == null)
            {
                throw new ArgumentNullException("Route object mast not null");
            }
            if (Data.OrderId.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Route.TrackingNumber mast not Empty");
            }
            var dic = new Dictionary<string, string>() {
                { "orderid",Data.OrderId},
                { "search_type",((int)Data.SearchType).ToString()}
            };
            return dic;
        }
    }
}
