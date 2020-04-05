using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 确认操作类型
    /// </summary>
    [Description("确认操作类型")]
    public enum DealType
    {
        /// <summary>
        /// 1:确认，
        /// </summary>
        [Description("确认")]
        Confirm = 1,

        /// <summary>
        /// 2:取消
        /// </summary>
        [Description("取消")]
        Cancel = 2
    }
}
