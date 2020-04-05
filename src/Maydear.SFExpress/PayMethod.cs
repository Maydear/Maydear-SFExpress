using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 付款方式【1:寄方付，2:收方付，3:第三方付】
    /// </summary>
    [Description("付款方式")]
    public enum PayMethod
    {
        /// <summary>
        /// 寄方付
        /// </summary>
        [Description("寄方付")]
        SenderPay = 1,

        /// <summary>
        /// 收方付
        /// </summary>
        [Description("收方付")]
        ConsigneePay = 2,

        /// <summary>
        /// 第三方付
        /// </summary>
        [Description("第三方付")]
        OtherPay = 3
    }
}
