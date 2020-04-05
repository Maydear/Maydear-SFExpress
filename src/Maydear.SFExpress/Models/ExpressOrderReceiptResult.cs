namespace Maydear.SFExpress.Models
{
    public class ExpressOrderReceiptResult : ExpressOrderBaseResult
    {
        /// <summary>
        /// 顺丰签回单服务运单号
        /// </summary>
        public string ReturnTrackingNo { get; set; }

        /// <summary>
        /// 地址映射码
        /// </summary>
        public string MappingMark { get; set; }

        /// <summary>
        /// 是否送货上楼
        /// </summary>
        public bool? IsUpstairs { get; set; }

        /// <summary>
        /// 包含特殊仓库增值服务
        /// </summary>
        public bool? IsSpecialWarehouseService { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ExpressOrderRlsInfo RlsInfo { get; set; }
    }
}