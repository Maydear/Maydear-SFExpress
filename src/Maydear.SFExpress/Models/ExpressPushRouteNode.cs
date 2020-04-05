using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ExpressPushRouteNode : ExpressRouteNode
    {
        /// <summary>
        /// 路由节点信息编号, 每一个id代表一条不同的路由节点信息。
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 顺丰运单号
        /// <para>
        /// 一个订单只能有一个母单号,如果是子母单的情况, 以半角逗号分隔, 主单号在第一个位置,如“755123456789,001123456789,002123456789”。
        /// </para>
        /// </summary>
        public string MailNo { get; set; }

        /// <summary>
        /// 客户订单号
        /// <para>
        /// 建议英文字母+ YYMMDD(日期)+流水号, 如:TB1207300000001
        /// </para>
        /// </summary>
        public string OrderId { get; set; }
    }
}
