using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 子单号申请
    /// </summary>
    public class ExpressOrderZD
    {

        /// <summary>
        /// 客户订单号
        /// <para>
        /// 建议英文字母+ YYMMDD(日期)+流水号, 如:TB1207300000001
        /// </para>
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 新增加的包裹数,最大20
        /// </summary>
        public int ParcelQuantity { get; set; } = 1;
    }
}
