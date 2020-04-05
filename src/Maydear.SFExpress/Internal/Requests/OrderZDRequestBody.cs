using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Requests
{
    /// <summary>
    /// 订单筛选实体
    /// </summary>
    internal class OrderZDRequestBody : IRequestBody
    {
        public OrderZDRequestBody(ExpressOrderZD expressOrderZD)
        {
            Data = expressOrderZD;
        }

        /// <summary>
        /// 子单号申请实体
        /// </summary>
        public ExpressOrderZD Data { get; private set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName => "OrderZDService";

        /// <summary>
        /// 输出Xml
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            return $@"<OrderZD  {string.Join(" ", BuidAttributesMap().Select(a => $"{a.Key}=\"{a.Value}\""))} />";
        }

        /// <summary>
        /// 构造订单结果查询实体键值对
        /// </summary>
        /// <returns>返回属性键值对</returns>
        private IDictionary<string, string> BuidAttributesMap()
        {
            if (Data == null)
            {
                throw new ArgumentNullException("Data object mast not null");
            }
            if (Data.OrderId.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("Data.OrderId mast not Empty");
            }

            if (Data.ParcelQuantity <1|| Data.ParcelQuantity>20)
            {
                    throw new ArgumentNullException("仅支持[1-20]其中一个数值");
            }
            var dic = new Dictionary<string, string>() {
                { "orderid",Data.OrderId},
                { "parcel_quantity",Data.ParcelQuantity.ToString()}
            };
            
            return dic;
        }
    }
}
