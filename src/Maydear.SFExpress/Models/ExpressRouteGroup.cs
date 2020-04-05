using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 按运单分组的路由
    /// </summary>
    public class ExpressRouteGroup
    {
        /// <summary>
        /// 顺丰运单号
        /// </summary>
        public string MailNo { get; set; }

        public IEnumerable<ExpressRouteNode> Nodes { get; set; }
    }
}
