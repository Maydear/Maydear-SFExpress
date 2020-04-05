using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{

    /// <summary>
    /// 订单的面单明细信息
    /// </summary>
    public class ExpressOrderRlsDetail
    {
        /// <summary>
        /// 顺丰运单号【吐槽一下，都是运单号咋名字都不一样顺丰的不一样呗】
        /// </summary>
        public string WaybillNo { get; set; }

        /// <summary>
        /// 原寄地中转场
        /// </summary>
        public string SourceTransferCode { get; set; }

        /// <summary>
        /// 原寄地城市代码
        /// </summary>
        public string SourceCityCode { get; set; }

        /// <summary>
        /// 原寄地网点代码
        /// </summary>
        public string SourceDeptCode { get; set; }


        /// <summary>
        /// 原寄地单元区域
        /// </summary>
        public string SourceTeamCode { get; set; }

        /// <summary>
        /// 目的地城市代码,eg:755
        /// </summary>
        public string DestCityCode { get; set; }

        /// <summary>
        /// 目的地网点代码, eg:755AQ
        /// </summary>
        public string DestDeptCode { get; set; }

        /// <summary>
        /// 目的地网点代码映射码
        /// </summary>
        public string DestDeptCodeMapping { get; set; }

        /// <summary>
        /// 目的地单元区域, eg:001
        /// </summary>
        public string DestTeamCode { get; set; }

        /// <summary>
        /// 目的地单元区域映射码
        /// </summary>
        public string DestTeamCodeMapping { get; set; }

        /// <summary>
        /// 目的地中转场
        /// </summary>
        public string DestTransferCode { get; set; }

        /// <summary>
        /// 打单时的路由标签信息
        /// <para>如果是大网的路由标签,这里的值是目的地网点代码;</para>
        /// <para>如果是同城配的路由标签,这里的值是根据同城配的设置映射出来的值,不同的配置结果会不一样,不能根据-符号切分</para>
        /// <para>(如:上海同城配, 可能是:集散点-目的地网点-接驳点, 也有可能是目的地网点代码-集散点-接驳点)</para>
        /// </summary>
        public string DestRouteLabel { get; set; }

        /// <summary>
        /// 产品名称对应RLS:pro_name
        /// </summary>
        public string ProName { get; set; }

        /// <summary>
        /// 快件内容: 如:C816、SP601
        /// </summary>
        public string CargoTypeCode { get; set; }

        /// <summary>
        /// 时效代码, 如:T4
        /// </summary>
        public string LimitTypeCode { get; set; }

        /// <summary>
        /// 产品类型, 如:B1
        /// </summary>
        public string ExpressTypeCode { get; set; }

        /// <summary>
        /// 入港映射码,eg:S10
        /// </summary>
        public string CodingMapping { get; set; }

        /// <summary>
        /// 出港映射码
        /// </summary>
        public string CodingMappingOut { get; set; }

        /// <summary>
        ///  XB标志 0:不需要打印XB 1:需要打印XB
        /// </summary>
        public int? XbFlag { get; set; }

        /// <summary>
        ///  打印标志
        ///  <para>返回值总共有9位,每位只有0和1两种</para>
        ///  <para>0:表示按丰密面单默认的规则</para>
        ///  <para>1:是显示,顺序如下,如111110000</para>
        ///  <para>0:表示打印寄方姓名、寄方电话、寄方公司名、寄方地址和重量, 收方姓名、收方电话、收方公司和收方地址按丰密面单默认规则</para>
        ///  <para>   
        ///  1:寄方姓名
        ///  2:寄方电话
        ///  3:寄方公司名
        ///  4:寄方地址
        ///  5:重量
        ///  6:收方姓名
        ///  7:收方电话
        ///  8:收方公司名
        ///  9:收方地址
        ///  </para>
        /// </summary>
        public string PrintFlag { get; set; }

        /// <summary>
        /// 二维码,根据规则生成字符串信息
        /// <para>格式为MMM={'k1':'(目的地中转场代码)','k2':'(目的地原始网点代码)','k3':'(目的地单元区域)','k4':'(附件通过三维码(express_type_code、 limit_type_code、 cargo_type_code)映射时效类型)','k5':'(运单号)','k6':'(AB标识)','k7':'(校验码)'}</para>
        /// </summary>
        public string TwoDimensionCode { get; set; }

        /// <summary>
        /// 时效类型:值为二维码中的K4
        /// </summary>
        public string ProCode { get; set; }

        /// <summary>
        /// 打印图标
        /// <para>根据托寄物判断需要打印的图标(重货, 蟹类, 生鲜, 易碎，Z标)返回值有8位，每一位只有0和1两种，0表示按运单默认的规则，1表示显示。后面两位默认0备用。</para>
        /// <para>顺序如下：重货,蟹类,生鲜,易碎,医药类,Z标,酒类,0</para>
        /// <para>如：00000000表示不需要打印重货，蟹类，生鲜，易碎,医药,Z标,酒类,备用</para>
        /// </summary>
        public string PrintIcon { get; set; }

        /// <summary>
        /// AB标
        /// </summary>
        public string AbFlag { get; set; }

        /// <summary>
        /// 查询出现异常时返回信息。返回代码:0 系统异常 1 未找到面单
        /// </summary>
        public string ErrMsg { get; set; }

        /// <summary>
        /// 目的地口岸代码
        /// </summary>
        public string DestPortCode { get; set; }

        /// <summary>
        /// 目的国别(国别代码如:JP)
        /// </summary>
        public string DestCountry { get; set; }

        /// <summary>
        /// 目的地邮编
        /// </summary>
        public string DestPostCode { get; set; }

        /// <summary>
        /// 总价值(保留两位小数, 数字类型, 可补位)
        /// </summary>
        public string GoodsValueTotal { get; set; }

        /// <summary>
        /// 币种
        /// </summary>
        public string CurrencySymbol { get; set; }

        /// <summary>
        /// 件数
        /// </summary>
        public string GoodsNumber { get; set; }

        /// <summary>
        /// 根据k1-k6生成的校验码
        /// </summary>
        public string CheckCode { get; set; }

    }
}
