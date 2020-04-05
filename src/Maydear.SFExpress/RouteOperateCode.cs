using System;
using System.ComponentModel;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 路由操作码
    /// </summary>
    public enum RouteOperateCode
    {
        /// <summary>
        /// 快件在【XXX营业点】已装车, 准备发往 【XXX集散中心】
        /// </summary>
        [Description("快件在【营业点】已装车, 准备发往 【集散中心】")]
        Code30 = 30,

        /// <summary>
        /// 快件到达 【XXX集散中心】
        /// </summary>
        [Description("快件到达 【集散中心】")]
        Code31 =31,

        /// <summary>
        /// 派件异常原因
        /// </summary>
        [Description("派件异常原因")]
        Code33 =33,

        /// <summary>
        /// 正在派送途中, 请您准备签收(派件人:XXX, 电话:XXX)
        /// </summary>
        [Description("正在派送途中, 请您准备签收(派件人:XXX, 电话:XXX)")]
        Code44 =44,

        /// <summary>
        /// 顺丰已收件
        /// </summary>
        [Description("顺丰已收件")]
        Code50 =50,

        /// <summary>
        /// 由于XXX原因 派件不成功
        /// </summary>
        [Description("由于XXX原因 派件不成功")]
        Code70 =70,

        /// <summary>
        /// 已签收, 感谢使用顺丰, 期待再次为您服务
        /// </summary>
        [Description("已签收, 感谢使用顺丰, 期待再次为您服务")]
        Code80 =80,

        /// <summary>
        /// 应客户要求, 快件正在转寄中
        /// </summary>
        [Description("应客户要求, 快件正在转寄中")]
        Code99 =99,

        /// <summary>
        /// 快件到达顺丰店/站
        /// </summary>
        [Description("快件到达顺丰店/站")]
        Code130 =130,

        /// <summary>
        /// 快件正送往顺丰店/站
        /// </summary>
        [Description("快件正送往顺丰店/站")]
        Code123 =123,

        /// <summary>
        /// 代理收件
        /// </summary>
        [Description("代理收件")]
        Code607 =607,

        /// <summary>
        /// 快件已退回/转寄, 新单号为: XXX
        /// </summary>
        [Description("快件已退回/转寄, 新单号为: XXX")]
        Code648 =648,

        /// <summary>
        /// 快件在XXX, 准备送往下一站
        /// </summary>
        [Description("快件在XXX, 准备送往下一站")]
        Code3036 =3036,

        /// <summary>
        /// 在官网"运单资料&签收图", 可查看签收人信
        /// </summary>
        [Description("在官网\"运单资料 & 签收图\", 可查看签收人信")]
        Code8000 =8000
    }
}
