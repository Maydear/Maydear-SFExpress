using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Requests
{
    /// <summary>
    /// 订单筛选实体
    /// </summary>
    internal class OrderConfirmRequestBody : IRequestBody
    {
        public OrderConfirmRequestBody(ExpressOrderConfirm expressOrderConfirm)
        {
            Data = expressOrderConfirm;
        }

        /// <summary>
        /// 订单确认/取消实体
        /// </summary>
        public ExpressOrderConfirm Data { get; private set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName => "OrderConfirmService";

        /// <summary>
        /// 输出Xml
        /// </summary>
        /// <returns></returns>
        public string ToXml()
        {
            return $@"<OrderConfirm {string.Join(" ", BuidAttributesMap().Select(a => $"{a.Key}=\"{a.Value}\""))} >{BulidOptionXmlString()}</OrderConfirm>";
        }

        /// <summary>
        /// 构造二级xml报文
        /// </summary>
        /// <returns></returns>
        private string BulidOptionXmlString()
        {
            if (Data == null)
                return "";
            if (Data.OrderConfirmSubjects == null)
            {
                return "";
            }
            var dictOption = BuidOptionAttributesMap();
            if (dictOption == null || dictOption.IsNullOrEmpty())
            {
                return "";
            }

            return $"<OrderConfirmOption {string.Join(" ", dictOption.Select(a => $"{a.Key}=\"{a.Value}\""))} />";
        }

        /// <summary>
        /// 构造订单结果查询实体键值对
        /// </summary>
        /// <returns>返回属性键值对</returns>
        private IDictionary<string, string> BuidAttributesMap()
        {
            if (Data == null)
            {
                throw new ArgumentNullException("OrderConfirm object mast not null");
            }
            if (Data.OrderId.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("OrderConfirm.OrderId mast not Empty");
            }

            if (Data.DealType == DealType.Confirm)
            {
                if (Data.MailNo.IsNullOrWhiteSpace())
                {
                    throw new ArgumentNullException("OrderConfirm.MailNo mast not Empty");
                }
            }
            var dic = new Dictionary<string, string>() {
                { "orderid",Data.OrderId},
                { "method_type",((int)Data.DealType).ToString()}
            };
            if (!Data.MailNo.IsNullOrWhiteSpace())
            {
                dic.Add("mailno", Data.MailNo);
            }
            if (!Data.CustomsBatchs.IsNullOrWhiteSpace())
            {
                dic.Add("customs_batchs", Data.CustomsBatchs);
            }
            if (!Data.AgentNo.IsNullOrWhiteSpace())
            {
                dic.Add("agent_no", Data.AgentNo);
            }
            if (!Data.ConsignEmpCode.IsNullOrWhiteSpace())
            {
                dic.Add("consign_emp_code", Data.AgentNo);
            }
            if (!Data.SourceZoneCode.IsNullOrWhiteSpace())
            {
                dic.Add("source_zone_code", Data.AgentNo);
            }
            if (!Data.InProcessWaybillNo.IsNullOrWhiteSpace())
            {
                dic.Add("in_process_waybill_no", Data.AgentNo);
            }
            return dic;
        }


        /// <summary>
        /// 构造订单赛选二级选项键值对
        /// </summary>
        /// <returns>返回属性键值对</returns>
        private IDictionary<string, string> BuidOptionAttributesMap()
        {
            if (Data.OrderConfirmSubjects == null ||
                (
                  !Data.OrderConfirmSubjects.Weight.HasValue &&
                  Data.OrderConfirmSubjects.Volume == null &&
                  Data.OrderConfirmSubjects.ReturnTracking.IsNullOrWhiteSpace() &&
                  !Data.OrderConfirmSubjects.ExpressType.HasValue &&
                  Data.OrderConfirmSubjects.ChildrenNos.IsNullOrEmpty() &&
                  Data.OrderConfirmSubjects.WayBillSize.IsNullOrWhiteSpace() &&
                  Data.OrderConfirmSubjects.IsGenEletricPic.HasValue
                )
            )
            {
                return null;
            }
            var dic = new Dictionary<string, string>();

            if (Data.OrderConfirmSubjects.Weight.HasValue && Data.OrderConfirmSubjects.Weight.Value > 0)
            {
                dic.Add("weight", Data.OrderConfirmSubjects.Weight.Value.ToString("F2"));
            }
            if (Data.OrderConfirmSubjects.Volume != null && Data.OrderConfirmSubjects.Volume.Length > 0 && Data.OrderConfirmSubjects.Volume.Width > 0 && Data.OrderConfirmSubjects.Volume.Height > 0)
            {
                dic.Add("volume", $"{Data.OrderConfirmSubjects.Volume.Length.ToString("F2")},{Data.OrderConfirmSubjects.Volume.Width.ToString("F2")},{Data.OrderConfirmSubjects.Volume.Height.ToString("F2")}");
            }
            if (!Data.OrderConfirmSubjects.ReturnTracking.IsNullOrWhiteSpace())
            {
                dic.Add("return_tracking", Data.OrderConfirmSubjects.ReturnTracking);
            }
            if (Data.OrderConfirmSubjects.ExpressType.HasValue)
            {
                dic.Add("return_tracking", ((int)Data.OrderConfirmSubjects.ExpressType.Value).ToString());
            }
            if (Data.OrderConfirmSubjects.ChildrenNos.IsNotEmpty())
            {
                dic.Add("children_nos", string.Join(",", Data.OrderConfirmSubjects.ChildrenNos));
            }
            if (!Data.OrderConfirmSubjects.WayBillSize.IsNullOrWhiteSpace())
            {
                dic.Add("children_nos", Data.OrderConfirmSubjects.WayBillSize);
            }
            if (Data.OrderConfirmSubjects.IsGenEletricPic.HasValue)
            {
                dic.Add("is_gen_eletric_pic", Data.OrderConfirmSubjects.IsGenEletricPic.Value ? "1" : "0");
            }
            return dic;
        }
    }
}
