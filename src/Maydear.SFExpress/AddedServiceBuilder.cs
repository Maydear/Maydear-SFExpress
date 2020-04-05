using System;
using System.Collections.Generic;
using System.Text;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 增值服务构造器
    /// </summary>
    public static class AddedServiceBuilder
    {
        /// <summary>
        /// 代收货款
        /// </summary>
        /// <param name="goodsFunds">代收的货款金额</param>
        /// <param name="bankCard">收款银行卡号</param>
        /// <returns>返回代收货款增值服务</returns>
        public static AddedService BuildServiceWithCOD(decimal goodsFunds, string bankCard)
        {
            if (goodsFunds <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(goodsFunds)} 必须大于 0");
            }

            if (bankCard.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException($"“{nameof(bankCard)}” 不能缺少收款银行卡号.");
            }

            return new AddedService()
            {
                Name = "COD",
                Value = goodsFunds.ToString("F3"),
                Value1 = bankCard
            };
        }

        /// <summary>
        /// 散单代收服务
        /// </summary>
        /// <param name="goodsFunds">代收的货款金额</param>
        ///  <param name="serviceFee">散单代收货款服务费</param>
        /// <param name="bankCard">收款银行卡号</param>
        /// <returns>返回代收货款增值服务</returns>
        public static AddedService BuildServiceWithXCOD(decimal goodsFunds, decimal serviceFee, string bankCard)
        {
            if (goodsFunds <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(goodsFunds)} 必须大于 0");
            }

            if (bankCard.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException($"“{nameof(bankCard)}” 不能缺少收款银行卡号.");
            }

            return new AddedService()
            {
                Name = "XCOD",
                Value = goodsFunds.ToString("F3"),
                Value1 = bankCard,
                Value2 = serviceFee.ToString("F3")
            };
        }
        /// <summary>
        /// 保价
        /// </summary>
        /// <param name="worthFunds">价值</param>
        /// <returns>返回保价增值服务</returns>
        public static AddedService BuildServiceWithINSURE(decimal worthFunds)
        {
            if (worthFunds <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(worthFunds)} 必须大于 0");
            }


            return new AddedService()
            {
                Name = "INSURE",
                Value = worthFunds.ToString("F3")
            };
        }

        /// <summary>
        /// 验收服务
        /// </summary>
        /// <param name="mobile">手机号码</param>
        /// <returns>返回验收服务增值服务</returns>
        public static AddedService BuildServiceWithIN52(string mobile)
        {
            if (mobile.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException($"“{nameof(mobile)}” 不能缺少手机号码.");
            }

            return new AddedService()
            {
                Name = "IN52",
                Value = mobile
            };
        }

        /// <summary>
        /// 标准化包装服务
        /// </summary>
        /// <param name="packageFunds">手机号码</param>
        /// <returns>返回标准化包装服务增值服务</returns>
        public static AddedService BuildServiceWithPKFEE(decimal packageFunds)
        {
            if (packageFunds <= 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(packageFunds)} 必须大于 0");
            }

            return new AddedService()
            {
                Name = "PKFEE",
                Value = packageFunds.ToString("F3")
            };
        }
        /// <summary>
        /// 超长超重服务	
        /// </summary>
        /// <returns>返回超长超重增值服务</returns>
        public static AddedService BuildServiceWithIN23()
        {
            return new AddedService()
            {
                Name = "IN23"
            };
        }

        /// <summary>
        /// 签收确认服务	
        /// </summary>
        /// <returns>返回签收确认增值服务</returns>
        public static AddedService BuildServiceWithIN105()
        {
            return new AddedService()
            {
                Name = "IN105"
            };
        }

        /// <summary>
        /// 定时派服务	
        /// </summary>
        /// <param name="date">派送日期</param>
        /// <param name="period">时间段(1:[09:00-12:00]、2:[12:01-18:00]、3[18:01-21:00])</param>
        /// <returns>返回定时派增值服务</returns>
        public static AddedService BuildServiceWithTDELIVERY(DateTime date, int period)
        {
            if (period > 4 || period < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(period));
            }

            return new AddedService()
            {
                Name = "TDELIVERY",
                Value = date.ToString("yyyyMMdd"),
                Value1 = period.ToString()
            };
        }

        /// <summary>
        /// 电子验收	
        /// </summary>
        /// <param name="type">图片类型[1、身份证,2、军官证,3、护照,4、其他]</param>
        /// <param name="number">照片数量</param>
        /// <returns>返回电子验收增值服务</returns>
        public static AddedService BuildServiceWithIN91(int type, int number=1)
        {
            if (type > 5 || type < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }

            return new AddedService()
            {
                Name = "IN91",
                Value = type.ToString(),
                Value1 = number.ToString()
            };
        }

        /// <summary>
        /// 拍照验证
        /// </summary>
        /// <param name="type">图片类型[1、身份证,2、军官证,3、护照,4、其他]</param>
        /// <param name="number">照片数量</param>
        /// <returns>返回拍照验证增值服务</returns>
        public static AddedService BuildServiceWithIN56(int type, int number = 1)
        {
            if (type > 5 || type < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }

            return new AddedService()
            {
                Name = "IN56",
                Value = type.ToString(),
                Value1 = number.ToString()
            };
        }
        /// <summary>
        /// 签收确认服务	
        /// </summary>
        /// <returns>返回签收确认增值服务</returns>
        public static AddedService BuildServiceWithIN99()
        {
            return new AddedService()
            {
                Name = "IN99"
            };
        }

        /// <summary>
        /// 保鲜服务
        /// </summary>
        /// <returns>返回保鲜增值服务</returns>
        public static AddedService BuildServiceWithIN41()
        {
            return new AddedService()
            {
                Name = "IN41"
            };
        }
        /// <summary>
        /// 定时派送(等通知) 服务
        /// </summary>
        /// <returns>返回定时派送(等通知) 增值服务</returns>
        public static AddedService BuildServiceWithNOTICE()
        {
            return new AddedService()
            {
                Name = "NOTICE"
            };
        }
    }
}
