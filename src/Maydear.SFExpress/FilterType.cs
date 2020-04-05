using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 筛单类别
    /// </summary>
    public enum FilterType
    {
        /// <summary>
        /// 1:自动筛单(系统根据地址库进行判断, 并返回结果, 系统无法检索到可派送的将返回不可派送)
        /// </summary>
        [Description("自动筛单")]
        Auto =1,

        /// <summary>
        /// 2:可人工筛单(系统首先根据地址库判断, 如果无法自动判断是否收派, 系统将生成需要人工判断的任务, 后续由人工处理, 处理结束后, 顺丰可主动推送给客户系统)
        /// </summary>
        [Description("人工筛单")]
        Manual =2
    }
}
