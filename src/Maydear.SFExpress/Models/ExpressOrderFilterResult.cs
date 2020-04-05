using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 检查地址收派范围参数
    /// </summary>
    public class ExpressOrderFilterResult
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
        /// 到件方详细地址文本, 需要包括省市区, 如:广东省深圳市福田区新洲十一街万基商务大厦。
        /// </summary>
        public string ToAddressText { get; set; }

        /// <summary>
        /// 寄件方
        /// </summary>
        public ContactAddress From { get; set; }

        /// <summary>
        /// 收件方
        /// </summary>
        public ContactAddress To { get; set; }

        /// <summary>
        /// 筛单结果:当filter_type = 1时,不存在1值。
        /// </summary>
        public FilterTypeResult FilterTypeResult { get; set; }

        /// <summary>
        /// 原寄地区域代码, 如果可收派, 此项不能为空。
        /// </summary>
        public string OriginCode { get; set; }

        /// <summary>
        /// 目的地区域代码, 如果可收派, 此项不能为空。
        /// </summary>
        public string DestCode { get; set; }

        /// <summary>
        /// 如果filter_result = 3时为必填,不可以收派的原因代码:1:收方超范围 2:派方超范围,3:其它原因
        /// </summary>
        public NotAllowedReason? Remark { get; set; }

    }
}
