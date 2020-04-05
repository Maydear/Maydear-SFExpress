using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 快件产品编码，对应 《快件产品类别表》
    /// <para>
    /// https://qiao.sf-express.com/pages/developDoc/index.html?level2=689001
    /// </para>
    /// </summary>
    public enum ExpressType
    {
        /// <summary>
        /// (1)顺丰标快
        /// </summary>
        [Description("顺丰标快")]
        T4_1 = 1,

        /// <summary>
        /// (11)医药安心递
        /// </summary>
        [Description("医药安心递")]
        T4_11 = 11,

        /// <summary>
        /// (12)医药专递
        /// </summary>
        [Description("医药专递")]
        T4_12 = 12,

        /// <summary>
        /// (15)生鲜速配
        /// </summary>
        [Description("生鲜速配")]
        T4_15 = 15,

        /// <summary>
        /// (16)大闸蟹专递
        /// </summary>
        [Description("大闸蟹专递")]
        T4_16 = 16,

        /// <summary>
        /// (18)重货快运
        /// </summary>
        [Description("顺丰标快（陆运）")]
        T4_18 = 18,

        /// <summary>
        /// (30)三号便利箱/袋
        /// </summary>
        [Description("三号便利箱/袋")]
        T4_30 = 30,

        /// <summary>
        /// (31)便利封/袋
        /// </summary>
        [Description("便利封/袋")]
        T4_31 = 31,

        /// <summary>
        /// (32)二号便利箱/袋
        /// </summary>
        [Description("二号便利箱/袋")]
        T4_32 = 32,

        /// <summary>
        /// (33)岛内件（80CM）
        /// </summary>
        [Description("岛内件（80CM）")]
        T4_33 = 33,

        /// <summary>
        /// (2)顺丰标快（陆运）
        /// </summary>
        [Description("顺丰标快（陆运）")]
        T6 = 2,

        /// <summary>
        /// (13)物流普运
        /// </summary>
        [Description("物流普运")]
        T6_13 = 13,

        /// <summary>
        /// (5)顺丰次晨
        /// </summary>
        [Description("顺丰次晨")]
        T8_5 = 5,

        /// <summary>
        /// (6)顺丰即日
        /// </summary>
        [Description("顺丰即日")]
        T1_6 = 6,

        /// <summary>
        /// (9)顺丰国际小包（平邮）
        /// </summary>
        [Description("顺丰国际小包（平邮）")]
        T13_9 = 9,

        /// <summary>
        /// (23)国际特惠（文件）
        /// </summary>
        [Description("国际特惠（文件）")]
        T9_23 = 23,

        /// <summary>
        /// (24)国际特惠（包裹）
        /// </summary>
        [Description("国际特惠（包裹）")]
        T9_24 = 24,

        /// <summary>
        /// (25)国际特惠（D类）
        /// </summary>
        [Description("国际特惠（D类）")]
        T9_25 = 25,

        /// <summary>
        /// (26)国际特惠（保税）
        /// </summary>
        [Description("国际特惠（保税）")]
        T7_26 = 26,

        /// <summary>
        /// (27)国际特惠（保税）
        /// </summary>
        [Description("国际特惠（商家代理）")]
        T7_27 = 27,

        /// <summary>
        /// (29)国际电商专递-标准
        /// </summary>
        [Description("国际电商专递-标准")]
        T7_29 = 29,

        /// <summary>
        /// (36)汇票专送
        /// </summary>
        [Description("汇票专送")]
        T4_36 = 36,

        /// <summary>
        /// (110)证照专递
        /// </summary>
        [Description("证照专递")]
        T4_110 = 110,

        /// <summary>
        /// (111)顺丰干配
        /// </summary>
        [Description("顺丰干配")]
        T6_111 = 111,

        /// <summary>
        /// (112)顺丰空配
        /// </summary>
        [Description("顺丰空配")]
        T4_112 = 112,

        /// <summary>
        /// (125)专线普运
        /// </summary>
        [Description("专线普运")]
        T5_125 = 125,

        /// <summary>
        /// (154)重货包裹
        /// </summary>
        [Description("重货包裹")]
        T6_154 = 154,

        /// <summary>
        /// (155)小票零担
        /// </summary>
        [Description("小票零担")]
        T6_155 = 155,

        /// <summary>
        /// (195)医药安心递（陆）
        /// </summary>
        [Description("医药安心递（陆）")]
        T6_195 = 195,

        /// <summary>
        /// (199)极速包裹
        /// </summary>
        [Description("极速包裹")]
        T4_199 = 199,

        /// <summary>
        /// (200)冷运速配
        /// </summary>
        [Description("冷运速配")]
        T4_200 = 200,

        /// <summary>
        /// (202)顺丰微小件
        /// </summary>
        [Description("顺丰微小件")]
        T4_202 = 202,

        /// <summary>
        /// (204)陆运微小件
        /// </summary>
        [Description("陆运微小件")]
        T6_204 = 204,

        /// <summary>
        /// (10)顺丰国际小包（挂号）
        /// </summary>
        [Description("顺丰国际小包（挂号）")]
        T14_10  = 10 ,

        /// <summary>
        /// (153)重货专运
        /// </summary>
        [Description("重货专运")]
        T12_153 = 153,

        /// <summary>
        /// (201)冷运特惠
        /// </summary>
        [Description("冷运特惠")]
        T15_201 = 201,

        /// <summary>
        /// (208)特惠专配
        /// </summary>
        [Description("特惠专配")]
        T77_208 = 208,  

        /// <summary>
        /// (203)医药快运
        /// </summary>
        [Description("医药快运")]
        T38_203 = 203,

        /// <summary>
        /// (34)即日2200
        /// </summary>
        [Description("即日2200")]
        T105_34 = 34   


    }
}
