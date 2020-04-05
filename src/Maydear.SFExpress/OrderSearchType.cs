using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 订单结果查询类型
    /// </summary>
    [Description("订单结果查询类型")]
    public enum OrderSearchType
    {
        /// <summary>
        /// 正常单据查询,,传入的orderid为正向定单号
        /// </summary>
        [Description("正常单据")]
        Normal =1,

        /// <summary>
        /// 退货单查询,传入的orderid为退货原始订单号
        /// </summary>
        [Description("退货单据")]
        Returned = 2,
    }
}
