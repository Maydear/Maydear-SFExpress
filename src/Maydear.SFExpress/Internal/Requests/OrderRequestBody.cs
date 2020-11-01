using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress.Internal.Requests
{
    internal class OrderRequestBody : IRequestBody
    {

        public OrderRequestBody(ExpressOrder expressOrder)
        {
            Data = expressOrder;
        }
        /// <summary>
        /// 
        /// </summary>
        public string ServiceName => "OrderService";

        /// <summary>
        /// 
        /// </summary>
        public ExpressOrder Data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public string ToXml()
        {
            return $@"<Order {string.Join(" ", BuidAttributesMap().Select(a => $"{a.Key}=\"{a.Value}\""))}>{ToCargosXml()} {ToAddedServicesXml()} </Order>";
        }
        private string ToCargosXml()
        {
            var stringbuilder = new StringBuilder();
            if (Data.Cargos != null)
            {
                foreach (var item in Data.Cargos)
                {
                    var countString = string.Empty;
                    if (item.Count > 0)
                    {
                        countString = $"count='{item.Count}'";
                    }
                    stringbuilder.Append($@"<Cargo name='{item.Name}' {countString}></Cargo>");
                }
            }
            return stringbuilder.ToString();
        }

        private string ToAddedServicesXml()
        {
            var stringbuilder = new StringBuilder();
            if (Data.AddedServices != null)
            {
                foreach (var item in Data.AddedServices)
                {
                    var dict = BuidAddedServiceAttributesMap(item);
                    stringbuilder.Append($@"<AddedService {string.Join(" ", dict.Select(a => $"{a.Key}=\"{a.Value}\""))}></AddedService>");
                }
            }
            return stringbuilder.ToString();
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
            if (Data.From == null || Data.From.Address.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("OrderConfirm.From mast not Empty");
            }
            if (Data.To == null || Data.To.Mobile.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("OrderConfirm.To mast not Empty");
            }
            if (Data.From.Tel.IsNullOrEmpty() && Data.From.Mobile.IsNullOrEmpty())
            {
                throw new ArgumentNullException("OrderConfirm.From.Mobile or OrderConfirm.From.Tel mast not Empty");
            }
            if (Data.To.Tel.IsNullOrEmpty() && Data.To.Mobile.IsNullOrEmpty())
            {
                throw new ArgumentNullException("OrderConfirm.To.Mobile or OrderConfirm.To.Tel mast not Empty");
            }
            if (Data.From.Company.IsNullOrEmpty() && Data.From.Contact.IsNullOrEmpty())
            {
                throw new ArgumentNullException("OrderConfirm.From.Company or OrderConfirm.From.Contact mast not Empty");
            }
            if (Data.To.Company.IsNullOrEmpty() && Data.To.Contact.IsNullOrEmpty())
            {
                throw new ArgumentNullException("OrderConfirm.To.Company or OrderConfirm.To.Contact mast not Empty");
            }
            var dic = new Dictionary<string, string>() {
                { "orderid",Data.OrderId},
                { "j_address",Data.From.Address},
                { "d_address",Data.To.Address},
            };
            if (!Data.From.Tel.IsNullOrEmpty())
            {
                dic.Add("j_tel", string.Join(",", Data.From.Tel));
            }
            if (!Data.From.Mobile.IsNullOrEmpty())
            {
                dic.Add("j_mobile", string.Join(",", Data.From.Mobile));
            }
            if (!Data.From.Company.IsNullOrEmpty())
            {
                dic.Add("j_company", string.Join(",", Data.From.Company));
            }
            if (!Data.From.Contact.IsNullOrEmpty())
            {
                dic.Add("j_contact", string.Join(",", Data.From.Contact));
            }
            if (!Data.MailNos.IsNullOrEmpty())
            {
                dic.Add("mailno", string.Join(",", Data.MailNos));
            }
            if (!string.IsNullOrWhiteSpace(Data.From?.Province))
            {
                dic.Add("j_province", Data.From.Province);
            }
            if (!string.IsNullOrWhiteSpace(Data.From?.City))
            {
                dic.Add("j_city", Data.From.City);
            }
            if (!string.IsNullOrWhiteSpace(Data.From?.Country))
            {
                dic.Add("j_country", Data.From.Country);
            }
            if (!string.IsNullOrWhiteSpace(Data.From?.County))
            {
                dic.Add("j_county", Data.From.County);
            }
            if (!Data.To.Tel.IsNullOrEmpty())
            {
                dic.Add("d_tel", string.Join(",", Data.To.Tel));
            }
            if (!Data.To.Mobile.IsNullOrEmpty())
            {
                dic.Add("d_mobile", string.Join(",", Data.To.Mobile));
            }
            if (!string.IsNullOrWhiteSpace(Data.To?.Province))
            {
                dic.Add("d_province", Data.To.Province);
            }
            if (!string.IsNullOrWhiteSpace(Data.To?.Country))
            {
                dic.Add("d_country", Data.To.Country);
            }
            if (!string.IsNullOrWhiteSpace(Data.To?.City))
            {
                dic.Add("d_city", Data.To.City);
            }
            if (!string.IsNullOrWhiteSpace(Data.To?.County))
            {
                dic.Add("d_county", Data.To.County);
            }
            if (!Data.To.Company.IsNullOrEmpty())
            {
                dic.Add("d_company", string.Join(",", Data.To.Company));
            }
            if (!Data.To.Contact.IsNullOrEmpty())
            {
                dic.Add("d_contact", string.Join(",", Data.To.Contact));
            }
            if (!string.IsNullOrWhiteSpace(Data.CustId))
            {
                dic.Add("custid", Data.CustId);
            }
            if (Data.PayMethod.HasValue)
            {
                dic.Add("pay_method", ((int)Data.PayMethod.Value).ToString());
            }
            if (Data.ExpressType.HasValue)
            {
                dic.Add("express_type", ((int)Data.ExpressType.Value).ToString());
            }
            if (Data.ParcelQuantity.HasValue && Data.ParcelQuantity.Value > 0)
            {
                dic.Add("parcel_quantity", (Data.ParcelQuantity.Value).ToString());
            }
            if (Data.CargoLength.HasValue && Data.CargoLength.Value > 0)
            {
                dic.Add("cargo_length", (Data.CargoLength.Value).ToString("F3"));
            }
            if (Data.CargoWidth.HasValue && Data.CargoWidth.Value > 0)
            {
                dic.Add("cargo_width", (Data.CargoWidth.Value).ToString("F3"));
            }
            if (Data.CargoHeight.HasValue && Data.CargoHeight.Value > 0)
            {
                dic.Add("cargo_height", (Data.CargoHeight.Value).ToString("F3"));
            }
            if (Data.Volume.HasValue && Data.Volume.Value > 0)
            {
                dic.Add("volume", (Data.Volume.Value).ToString("F3"));
            }
            if (Data.CargoTotalWeight.HasValue && Data.CargoTotalWeight.Value > 0)
            {
                dic.Add("cargo_total_weight", (Data.CargoTotalWeight.Value).ToString("F3"));
            }
            if (Data.SendStartTime.HasValue)
            {
                dic.Add("sendstarttime", (Data.SendStartTime.Value).ToString("yyyy-MM-dd hh:mm:ss"));
            }
            if (Data.IsDocall.HasValue)
            {
                dic.Add("is_docall", Data.IsDocall.Value ? "1" : "0");
            }
            if (Data.NeedReturnTrackingNo.HasValue)
            {
                dic.Add("need_return_tracking_no", Data.NeedReturnTrackingNo.Value ? "1" : "0");
            }
            if (!string.IsNullOrWhiteSpace(Data.ReturnTracking))
            {
                dic.Add("return_tracking", Data.ReturnTracking);
            }
            if (Data.ExpressType.HasValue && Data.ExpressType.Value == ExpressType.T4_12)
            {
                if (!Data.TempRange.HasValue)
                {
                    throw new ArgumentNullException("医药专递类型，必须选择温度范围");
                }
                dic.Add("temp_range", Data.TempRange.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(Data.Template))
            {
                dic.Add("template", Data.Template);
            }
            if (!string.IsNullOrWhiteSpace(Data.Remark))
            {
                dic.Add("remark", Data.Template);
            }
            if (Data.OneselfPickupFlg.HasValue)
            {
                dic.Add("oneself_pickup_flg", Data.OneselfPickupFlg.Value ? "1" : "0");
            }
            if (Data.SpecialDeliveryTypeCode.HasValue)
            {
                dic.Add("special_delivery_type_code", Data.SpecialDeliveryTypeCode.Value.ToString());
            }
            if (!string.IsNullOrWhiteSpace(Data.SpecialDeliveryValue))
            {
                dic.Add("special_delivery_value", Data.SpecialDeliveryValue);
            }
            if (!string.IsNullOrWhiteSpace(Data.RealnameNum))
            {
                dic.Add("realname_num", Data.RealnameNum);
            }
            if (Data.RouteLabelForReturn.HasValue)
            {
                dic.Add("routelabelForReturn", Data.RouteLabelForReturn.Value?"1":"0");
            }
            if (Data.RouteLabelService.HasValue)
            {
                dic.Add("routelabelService", Data.RouteLabelService.Value ? "1" : "0");
            }
            if (Data.IsUnifiedWaybillNo.HasValue)
            {
                dic.Add("is_unified_waybill_no", Data.IsUnifiedWaybillNo.Value ? "1" : "0");
            }
            return dic;
        }

        /// <summary>
        /// 构造订单结果查询实体键值对
        /// </summary>
        /// <returns>返回属性键值对</returns>
        private IDictionary<string, string> BuidAddedServiceAttributesMap(AddedService addedService)
        {
            if (addedService == null)
            {
                throw new ArgumentNullException("addedService object mast not null");
            }

            var dic = new Dictionary<string, string>() {
                { "name",addedService.Name}
            };
            if (addedService.Value.IsNotEmpty())
            {
                dic.Add("Value", addedService.Value);
            }
            if (addedService.Value1.IsNotEmpty())
            {
                dic.Add("Value1", addedService.Value1);
            }
            if (addedService.Value2.IsNotEmpty())
            {
                dic.Add("Value2", addedService.Value2);
            }
            if (addedService.Value3.IsNotEmpty())
            {
                dic.Add("Value3", addedService.Value3);
            }
            if (addedService.Value4.IsNotEmpty())
            {
                dic.Add("Value4", addedService.Value4);
            }
            return dic;
        }

    }
}
