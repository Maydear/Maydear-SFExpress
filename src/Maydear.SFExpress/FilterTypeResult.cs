using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 地址筛单结果
    /// </summary>
    public enum FilterTypeResult
    {
        /// <summary>
        /// 1:人工确认
        /// </summary>
        [Description("人工确认")]
        ManualConfirmation = 1,

        /// <summary>
        /// 2:可收派
        /// </summary>
        [Description("可收派")]
        Allowed = 2,

        /// <summary>
        /// 2:不可以收派
        /// </summary>
        [Description("不可以收派")]
        NotAllowed = 3,

    }
}
