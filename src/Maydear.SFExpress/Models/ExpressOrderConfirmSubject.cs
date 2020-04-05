using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    public class ExpressOrderConfirmSubject
    {
        /// <summary>
        /// 订单货物总重量, 包含子母件,单位千克,精确到小数点后2位,如果提供此值,必须>0。
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// 货物的总体积(值为长, 宽, 高),包含子母件, 以半角逗号分隔,单位厘米,精确到小数点后2位,会用于计抛(是否计抛具体商务沟通中双方约定)。
        /// </summary>
        public Volume Volume { get; set; }

        /// <summary>
        /// 顺丰签回单服务运单号
        /// </summary>
        public string ReturnTracking { get; set; }

        /// <summary>
        /// 快件产品类别, 详见附录《快件产品类别表》,只有在商务上与顺丰约定的类别方可使用。如果此字段为空,则以下单时的为准。
        /// </summary>
        public ExpressType? ExpressType { get; set; }

        /// <summary>
        /// 子单号(以半角逗号分隔)如果此字段为空, 以下订单时为准。
        /// </summary>
        public IEnumerable<string> ChildrenNos { get; set; }

        /// <summary>
        /// 电子面单图片规格[1:A4 2:A5]
        /// </summary>
        public string WayBillSize { get; set; }

        /// <summary>
        /// 是否生成电子面单图片
        /// </summary>
        public bool? IsGenEletricPic { get; set; }

    }
}
