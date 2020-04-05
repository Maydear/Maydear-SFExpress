using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 查询号类别
    /// </summary>
    public enum TrackingType
    {
        //1:根据顺丰运单号查询,order节点中tracking_number将被当作顺丰运单号处理
        MailNumber=1,
        //2:根据客户订单号查询, order节点中tracking_number将被当作客户订单号处理

        OrderNumber = 2,
        /// <summary>
        /// 3:逆向单, 根据客户原始订单号查询, order节点中tracking_number将被当作逆向单原始订单号处理
        /// </summary>

        ReverseOrderNumber = 3,
    }
}
