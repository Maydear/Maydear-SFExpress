using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 货物信息
    /// </summary>
    public class Cargo
    {
        /// <summary>
        /// 货物名称
        /// <para>
        /// 如果需要生成电子面单,则为必填。
        /// </para>
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 货物数量
        /// <para>
        /// 跨境件报关需要填写
        /// </para>
        /// </summary>
        public int Count { get; set; }
    }
}
