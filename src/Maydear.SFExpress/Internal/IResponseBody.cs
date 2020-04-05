using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Maydear.SFExpress.Internal
{
    /// <summary>
    /// 相应内容
    /// </summary>
    internal interface IResponseBody
    {
        /// <summary>
        /// 填充对象
        /// </summary>
        /// <param name="xmlDocument">xml对象</param>
        void Fill(XmlDocument xmlDocument);
    }
}
