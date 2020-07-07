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
    internal class OrderFilterRequestBody : IRequestBody
    {
        public OrderFilterRequestBody(ExpressOrderFilter expressOrderFilter)
        {
            Data = expressOrderFilter;
        }

        /// <summary>
        /// 订单筛选实体
        /// </summary>
        public ExpressOrderFilter Data { get; private set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName => "OrderFilterService";

        /// <summary>
        /// 输出Xml
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            return $@"<OrderFilter {string.Join(" ", BuidAttributesMap().Select(a => $"{a.Key}=\"{a.Value}\""))} >{ BulidOptionXmlString()}</OrderFilter>";
        }

        /// <summary>
        /// 构造二级xml报文
        /// </summary>
        /// <returns></returns>
        private string BulidOptionXmlString()
        {
            if (Data == null)
                return "";
            if (Data.To == null || Data.To.Address.IsNullOrWhiteSpace())
            {
                return "";
            }
            var dictOption = BuidOptionAttributesMap();
            if (dictOption == null || dictOption.IsNullOrEmpty())
            {
                return "";
            }

            return $"<OrderFilterOption {string.Join(" ", dictOption.Select(a => $"{a.Key}=\"{a.Value}\""))} />";
        }

        /// <summary>
        /// 构造订单赛选二级选项键值对
        /// </summary>
        /// <returns>返回属性键值对</returns>
        private IDictionary<string, string> BuidOptionAttributesMap()
        {
            if (Data.To == null ||
                Data.To.Province.IsNullOrWhiteSpace() ||
                Data.To.City.IsNullOrWhiteSpace() ||
                Data.To.County.IsNullOrWhiteSpace() ||
                Data.To.Address.IsNullOrWhiteSpace()
                )
            {
                return null;
            }
            var dic = new Dictionary<string, string>() {
                { "d_province",Data.To.Province},
                { "d_city",Data.To.City},
                { "d_county",Data.To.County},
            };
            if (!Data.To.Country.IsNullOrWhiteSpace())
            {
                dic.Add("d_country", Data.To.Country);
            }
            if (!Data.To.Mobile.IsNullOrWhiteSpace() || !Data.To.Tel.IsNullOrWhiteSpace())
            {
                dic.Add("d_tel", Data.To.Mobile ?? Data.To.Tel);
            }
            if (!Data.CustId.IsNullOrWhiteSpace())
            {
                dic.Add("j_custid", Data.CustId);
            }
            if (Data.From != null)
            {
                if (!Data.From.Country.IsNullOrWhiteSpace())
                {
                    dic.Add("country", Data.From.Country);
                }
                if (!Data.From.Province.IsNullOrWhiteSpace())
                {
                    dic.Add("province", Data.From.Province);
                }
                if (!Data.From.City.IsNullOrWhiteSpace())
                {
                    dic.Add("city", Data.From.City);
                }
                if (!Data.From.County.IsNullOrWhiteSpace())
                {
                    dic.Add("county", Data.From.County);
                }
                if (!Data.From.Address.IsNullOrWhiteSpace())
                {
                    dic.Add("j_address", Data.From.Address);
                }
                if (!Data.From.Mobile.IsNullOrWhiteSpace() || !Data.From.Tel.IsNullOrWhiteSpace())
                {
                    dic.Add("j_tel", Data.From.Mobile ?? Data.From.Tel);
                }
            }

            return dic;
        }
        /// <summary>
        /// 构造订单结果查询实体键值对
        /// </summary>
        /// <returns>返回属性键值对</returns>
        private IDictionary<string, string> BuidAttributesMap()
        {
            if (Data == null)
            {
                throw new ArgumentNullException("Order Filter object mast not null");
            }
            var dic = new Dictionary<string, string>() {
                { "filter_type",((int)Data.FilterType).ToString()}
            };
            if (string.IsNullOrWhiteSpace(Data.ToFullAddress) && Data.To == null)
            {
                throw new ArgumentNullException("OrderFilter.To or OrderFilter.ToFullAddress mast not null ");
            }
            else
            {
                if (Data.To == null && !string.IsNullOrWhiteSpace(Data.ToFullAddress))
                {
                    dic.Add("d_address", Data.ToFullAddress);
                }
                else
                {
                    dic.Add("d_address", $"{Data.To.Province}{Data.To.City}{Data.To.County}{Data.To.Address}");
                }
            }
            
            return dic;
        }
    }
}
