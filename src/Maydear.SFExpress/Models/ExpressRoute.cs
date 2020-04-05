using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ExpressRoute
    {
        /// <summary>
        /// 查询号类别
        /// </summary>
        public TrackingType TrackingType { get; set; } = TrackingType.MailNumber;

        /// <summary>
        /// 查询号
        /// </summary>
        /// <remarks>
        /// 如果tracking_type=1,则此值为顺丰运单号
        /// 如果tracking_type = 2, 则此值为客户订单号
        /// 如果tracking_type = 3, 则此值为逆向单原始订单号
        /// </remarks>
        public IEnumerable<string> TrackingNumber { get; set; }

        /// <summary>
        /// 路由查询类别,1:标准路由查询
        /// </summary>
        public RouteMethodType MethodType { get; set; } = RouteMethodType.Standard;

        /// <summary>
        /// 参考编码(目前针对亚马逊客户, 由客户传)
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// 校验电话号码后四位值;
        /// </summary>
        /// <remarks>
        /// 按运单号查询路由时,可通过该参数传入用于校验的电话号码后4位(寄方或收方都可以),如果涉及多个运单号,对应该值也需按顺序传入多个,并以英文逗号隔开。
        /// </remarks>
        public IEnumerable<string> CheckPhoneNo { get; set; }
    }
}
