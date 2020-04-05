using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 子单号申请结果
    /// </summary>
    public class ExpressOrderZDResult
    {
        /// <summary>
        /// 客户订单号
        /// <para>
        /// 建议英文字母+ YYMMDD(日期)+流水号, 如:TB1207300000001
        /// </para>
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 顺丰母运单号
        /// </summary>
        public string MainMailNo { get; set; }

        /// <summary>
        /// 子运单号
        /// </summary>
        public IEnumerable<string> MailNoZD { get; set; }
    }
}
