using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Internal
{
    internal interface IRequestBody
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        string ServiceName { get; }

        /// <summary>
        /// 转为Xml报文
        /// </summary>
        /// <returns></returns>
        string ToXml();
    }
}
