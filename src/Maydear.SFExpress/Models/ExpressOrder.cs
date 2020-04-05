using System;
using System.Collections.Generic;

namespace Maydear.SFExpress.Models
{
    public class ExpressOrder
    {
        /// <summary>
        /// 快件产品编码
        /// <para>
        /// 详见附录 《快件产品类别表》<see cref="Maydear.SFExpress.ExpressType"/>,只有在商务上与 顺丰约定的类别方可使用。
        /// </para>
        /// </summary>
        public ExpressType? ExpressType { get; set; }

        /// <summary>
        /// 客户订单号
        /// <para>
        /// 建议英文字母+ YYMMDD(日期)+流水号, 如:TB1207300000001
        /// </para>
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 顺丰运单号(一般不用填)
        /// </summary>
        /// <remarks>
        /// 一个订单只能有一个母单号,如果是子母单的情况, 以半角逗号分隔,主单号在第一个位置, 如“755123456789,001123456789,002123456789”, 一般情况此属性不用传值。
        /// </remarks>
        public IEnumerable<string> MailNos { get; set; }

        /// <summary>
        /// 寄件方
        /// </summary>
        public ContactAddress From { get; set; }

        /// <summary>
        /// 收件方
        /// </summary>
        public ContactAddress To { get; set; }

        /// <summary>
        /// 包裹数
        /// <para>
        /// 一个包裹对应一个运单 号, 如果是大于1个包裹, 则按照子母件的方式返回母运单号和子运单号。
        /// </para>
        /// </summary>
        public int? ParcelQuantity { get; set; }

        /// <summary>
        ///  付款方式【1:寄方付，2:收方付，3:第三方付】
        /// </summary>
        public PayMethod? PayMethod { get; set; }

        /// <summary>
        /// 月结卡号
        /// </summary>
        public string CustId { get; set; }

        /// <summary>
        ///  (选填) 客户订单货物总长，单位厘米
        ///  <para>
        ///  精确到小数点后3位,包含子母件。
        ///  </para>
        /// </summary>
        public decimal? CargoLength { get; set; }

        /// <summary>
        ///  (选填) 客户订单货物总宽，单位厘米
        ///  <para>
        ///  精确到小数点后3位,包含子母件。
        ///  </para>
        /// </summary>
        public decimal? CargoWidth { get; set; }

        /// <summary>
        /// (选填) 客户订单货物总宽，单位厘米
        ///  <para>
        ///   精确到小数点后3位,包含子母件。
        ///  </para>
        /// </summary>
        public decimal? CargoHeight { get; set; }

        /// <summary>
        /// (选填) 订单货物总体积（单位立方厘米）
        ///  <para>
        ///  精确到小数点后3位, 会用于计抛(是否计抛具体商务沟通中双方约定)。
        ///  </para>
        /// </summary>
        public decimal? Volume { get; set; }

        /// <summary>
        /// (选填) 订单货物总重量（单位千克）
        ///  <para>
        ///  包含子母件,精确到小数点后3位,如果提供此值, 必须>0 。
        ///  </para>
        /// </summary>
        public decimal? CargoTotalWeight { get; set; }

        /// <summary>
        /// (选填) 上门取件时间 要求上门取件开始时间
        ///  <para>
        ///  格式: YYYY-MM-DD HH24:MM:SS
        ///  </para>
        ///  <para>
        ///  示例:2012-7-30 09:30:00。
        ///   </para>
        /// </summary>
        public DateTime? SendStartTime { get; set; }

        /// <summary>
        /// (选填) 是否要求通过手持终端通知顺丰收派员收件
        ///  <para>
        ///  1:要求,其它值为不要求
        ///  </para>
        /// </summary>
        public bool? IsDocall { get; set; }

        /// <summary>
        /// (选填) 是否要求签回单号
        /// <para>
        /// true(1):要求(丰密签回单必传<seealso cref="RouteLabelForReturn"/>、<seealso cref="RouteLabelService"/>)
        /// false(0):为不要求
        /// </para>
        /// </summary>
        public bool? NeedReturnTrackingNo { get; set; }

        /// <summary>
        /// (选填) 顺丰签回单服务运单号
        /// </summary>
        public string ReturnTracking { get; set; }

        /// <summary>
        /// (当<see cref="ExpressType"/> == 12 则必填)温度范围类型。
        /// <para>
        /// 1:为冷藏;3:为冷冻
        /// </para>
        /// </summary>
        public int? TempRange { get; set; }

        /// <summary>
        /// 业务模板编码
        /// <para>
        /// 业务模板指顺丰系统针对客户业务需求配置的一套接口处理逻辑, 一个接入编码可对应多个业务模板。
        /// </para>
        /// </summary>
        public string Template { get; set; }

        /// <summary>
        /// (选填) 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// (选填) 快件自取
        /// <para>
        /// false(0):表示客户不同意快件自取,true(1):表示客户同意快件自取;
        /// </para>
        /// </summary>
        public bool? OneselfPickupFlg { get; set; }

        /// <summary>
        /// (选填) 特殊派送类型代码
        /// <para>
        /// 1:身份验证
        /// </para>
        /// </summary>
        public int? SpecialDeliveryTypeCode { get; set; }

        /// <summary>
        /// (选填) 特殊派件具体表述
        /// <para>
        /// 证件类型<seealso cref="SpecialDeliveryTypeCode"/>:证件后8位;如:1:09296231(1表示身份证,暂不支持其他证件)
        /// </para>
        /// </summary>
        public string SpecialDeliveryValue { get; set; }

        /// <summary>
        /// (选填)实名认证流水号
        /// </summary>
        public string RealnameNum { get; set; }

        /// <summary>
        ///  (当<see cref="NeedReturnTrackingNo"/> == true 则必填)签回单路由标签返回
        /// <para>
        /// 默认 false。true(1):查询,false(0):不查询
        /// </para>
        /// </summary>
        public bool? RouteLabelForReturn { get; set; }

        /// <summary>
        ///  (当<see cref="NeedReturnTrackingNo"/> == true 则必填) 路由标签查询服务
        /// <para>
        /// 默认 false。true(1):查询,false(0):不查询
        /// </para>
        /// </summary>
        public bool? RouteLabelService { get; set; }

        /// <summary>
        /// (选填)是否使用国家统一面单号
        /// <para>
        /// 默认 false。true(1):是,false(0):不否
        /// </para>
        /// </summary>
        public bool? IsUnifiedWaybillNo { get; set; }

        /// <summary>
        /// 货物
        /// </summary>
        public IEnumerable<Cargo> Cargos { get; set; }

        /// <summary>
        /// 增值服务
        /// <para>增值服务的构造器<seealso cref="AddedServiceBuilder"/></para>
        /// </summary>
        public IEnumerable<AddedService> AddedServices { get; set; }

    }
}