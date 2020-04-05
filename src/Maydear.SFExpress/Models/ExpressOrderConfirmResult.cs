using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 订单确认/取消执行结果
    /// </summary>
    public class ExpressOrderConfirmResult
    {
        /// <summary>
        /// 客户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 顺丰母运单号，如果dealtype=1,必填
        /// </summary>
        public string MailNo { get; set; }

        /// <summary>
        /// 操作结果状态【fasle:客户订单号与顺丰运单不匹配、true :操作成功】
        /// </summary>
        public bool ResStatus { get; set; }

    }
}
