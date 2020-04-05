using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    public class ExpressRouteNode
    {
        /// <summary>
        /// 路由节点发生的时间2012-7-30 09:30:00
        /// </summary>
        public DateTime AcceptTime { get; set; }

        /// <summary>
        /// 路由节点发生的地点
        /// </summary>
        public string AcceptAddress{ get; set; }

        /// <summary>
        /// 路由节点具体描述
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 路由节点操作码
        /// </summary>
        public RouteOperateCode OperateCode { get; set; }
    }
}
