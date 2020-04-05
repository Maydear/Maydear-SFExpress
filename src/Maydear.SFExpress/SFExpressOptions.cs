using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 顺丰快递配置参数
    /// </summary>
    public class SFExpressOptions : IOptions<SFExpressOptions>
    {
        /// <summary>
        /// 顾客编码，该字段通过在丰桥平台获取
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// 校验码，该字段通过在丰桥平台获取
        /// </summary>
        public string Checkword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SFExpressOptions Value => this;
    }
}
