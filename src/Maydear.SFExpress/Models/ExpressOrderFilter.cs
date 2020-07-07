using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 检查地址收派范围参数
    /// </summary>
    public class ExpressOrderFilter
    {
        /// <summary>
        /// 筛单类别:
        /// </summary>
        public FilterType FilterType { get; set; }
        
        /// <summary>
        /// 客户订单号FilterType = 2则必须提供。
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 月结卡号
        /// </summary>
        public string CustId { get; set; }

        /// <summary>
        /// 收件完整地址
        /// </summary>
        public string ToFullAddress { get; set; }

        /// <summary>
        /// 寄件方
        /// </summary>
        public ContactAddress From { get; set; }

        /// <summary>
        /// 收件方
        /// </summary>
        public ContactAddress To { get; set; }
    }
}
