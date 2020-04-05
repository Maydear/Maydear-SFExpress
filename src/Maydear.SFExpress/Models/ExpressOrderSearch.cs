namespace Maydear.SFExpress.Models
{
    /// <summary>
    /// 订单结果查询实体
    /// </summary>
    public class ExpressOrderSearch
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 查询类型:【1,正向单查询,传入的orderid为正向定单号,2,退货单查询,传入的orderid为退货原始订单号】
        /// </summary>
        public OrderSearchType SearchType { get; set; }
    }
}