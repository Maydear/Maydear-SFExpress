using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 不可以收派的原因代码
    /// </summary>
    public enum NotAllowedReason
    {
        /// <summary>
        /// 1:收方超范围
        /// </summary>
        [Description("收方超范围")]
        SenderOverflow = 1,

        /// <summary>
        /// 2:派方超范围
        /// </summary>
        [Description("派方超范围")]
        ReceiverOverflow = 2,

        /// <summary>
        /// 3:其它原因
        /// </summary>
        [Description("其它原因")]
        Other = 3,

    }
}
