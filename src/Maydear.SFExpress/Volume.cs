using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 货物的总体积(值为长, 宽, 高)
    /// </summary>
    public class Volume
    {
        /// <summary>
        /// 长
        /// </summary>
        public decimal Length { get; set; }

        /// <summary>
        /// 宽
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// 高
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Length.ToString("F2")},{Width.ToString("F2")},{Height.ToString("F2")}";
        }
    }
}
