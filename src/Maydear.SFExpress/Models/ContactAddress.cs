using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{

    /// <summary>
    /// 联系地址信息
    /// </summary>
    public class ContactAddress
    {
        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 所在省份,必须是标准的省名称称谓 如:广东省,如果是直辖市,请直接传北京、上海等。
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 所属城市名称,必须是标准的城市称谓 如:深圳市,如果是直辖市,请直接传北京(或北京市)、上海(或上海市)等。
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 县/区
        /// </summary>
        public string County { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile { get; set; }
    }
}
