using System;

namespace Maydear.SFExpress.Models
{
    public class ExpressOrderState
    {
        /// <summary>
        /// 客户订单号
        /// <para>
        /// 建议英文字母+ YYMMDD(日期)+流水号, 如:TB1207300000001
        /// </para>
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 顺丰运单号
        /// <para>
        /// 一个订单只能有一个母单号,如果是子母单的情况, 以半角逗号分隔, 主单号在第一个位置,如“755123456789,001123456789,002123456789”。
        /// </para>
        /// </summary>
        public string MailNo { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string OrderStateCode { get; set; }

        /// <summary>
        /// 订单状态描述
        /// </summary>
        public string OrderStateDesc { get; set; }


        /// <summary>
        /// 收件员工工号
        /// </summary>
        public string EmpCode { get; set; }

        /// <summary>
        /// 收件员手机号
        /// </summary>
        public string EmpPhone { get; set; }


        /// <summary>
        /// 网点
        /// </summary>
        public string NetCode { get; set; }

        /// <summary>
        /// 最晚上门时间
        /// </summary>
        public DateTime? LastTime { get; set; }

        /// <summary>
        /// 客户预约时间
        /// </summary>
        public DateTime? BookTime { get; set; }

        /// <summary>
        /// 承运商代码(SF)
        /// </summary>
        public string CarrierCode { get; set; }

    }
}