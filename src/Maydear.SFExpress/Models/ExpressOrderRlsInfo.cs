using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Models
{
    public class ExpressOrderRlsInfo
    {
        /// <summary>
        /// 返回调用结果,
        /// ERR:调用失败;
        /// OK调用成功
        /// </summary>
        public string InvokeResult { get; set; }

        /// <summary>
        /// 0000(接口参数异常)
        /// 0010(其它异常)
        /// 0001(xml解析异常)
        /// 0002(字段校验异常)
        /// 0003(票数节点超出最大值, 批量请求最大票数为100票)
        /// 0004(RLS获取路由标签的必要字段为空)
        /// 1000 成功
        /// </summary>
        public string RlsCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorDesc { get; set; }

        /// <summary>
        /// 调用明细结果
        /// </summary>
        public ExpressOrderRlsDetail Detail { get; set; }
    }
}
