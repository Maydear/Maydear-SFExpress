using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 增值服务
    /// </summary>
    public class AddedService
    {
        /// <summary>
        /// 增值服务名, 如COD等。
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 增值服务扩展属性, 参考增值服务传值说明。
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 增值服务扩展属性4
        /// </summary>
        public string Value1 { get; set; }

        /// <summary>
        /// 增值服务扩展属性
        /// </summary>
        public string Value2 { get; set; }

        /// <summary>
        /// 增值服务扩展属性2
        /// </summary>
        public string Value3 { get; set; }

        /// <summary>
        /// 增值服务扩展属性3
        /// </summary>
        public string Value4 { get; set; }

    }
}
