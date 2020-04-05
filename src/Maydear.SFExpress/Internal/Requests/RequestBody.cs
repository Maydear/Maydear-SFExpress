using System;
using System.Collections.Generic;
using System.Text;

namespace Maydear.SFExpress.Internal.Requests
{
    /// <summary>
    /// 请求实体
    /// </summary>
    internal abstract class RequestBody: Body
    {
        /// <summary>
        /// 输出xml
        /// </summary>
        /// <returns></returns>
        public abstract string ToXml();
    }
}
