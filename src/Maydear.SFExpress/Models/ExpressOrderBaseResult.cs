namespace Maydear.SFExpress.Models
{
    public class ExpressOrderBaseResult
    {
        /// <summary>
        /// 客户订单号
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
        /// 原寄地区域代码
        /// </summary>
        public string OriginCode { get; set; }

        /// <summary>
        /// 目的地区域代码
        /// </summary>
        public string DestCode { get; set; }

        /// <summary>
        /// 筛单结果[1:人工确认;2:可收派;3:不可以收派]
        /// </summary>
        public int FilterResult { get; set; }

        /// <summary>
        /// 不可以收派的原因代码[1:收方超范围;2:派方超范围;3:其它原因]
        /// <para>
        /// <seealso cref="FilterResult"/> == 3,必定有值
        /// </para>
        /// </summary>
        public string Remark { get; set; }
    }
}