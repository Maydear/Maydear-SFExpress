using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    public class ExpressOrderConfirm
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
        /// 客户订单操作标识:【1:确认，2:取消】
        /// </summary>
        public DealType DealType { get; set; }

        /// <summary>
        /// 报关批次
        /// </summary>
        public string CustomsBatchs { get; set; }

        /// <summary>
        /// 代理单号
        /// </summary>
        public string AgentNo { get; set; }

        /// <summary>
        ///  收派员工号
        /// </summary>
        public string ConsignEmpCode { get; set; }

        /// <summary>
        /// 原寄地网点代码
        /// </summary>
        public string SourceZoneCode { get; set; }

        /// <summary>
        /// 头程运单号
        /// </summary>
        public string InProcessWaybillNo { get; set; }

        /// <summary>
        /// 扩展信息
        /// </summary>
        public ExpressOrderConfirmSubject OrderConfirmSubjects { get; set; }

    }
}
