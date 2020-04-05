using System;
using System.Xml;

namespace Maydear.SFExpress.Internal.Responses
{
    /// <summary>
    /// 
    /// </summary>
    internal class ErrorBody : IResponseBody
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 填充对象
        /// </summary>
        /// <param name="xmlDocument"></param>
        public void Fill(XmlDocument xmlDocument)
        {
            Message = xmlDocument.GetNodeText("ERROR");

            var attr= xmlDocument.GetNodeAttributes("ERROR");

            if (attr != null)
            {
                if (attr.ContainsKey("code"))
                {
                    Code = attr["code"].AsIntOrDefault();
                }
            }
        }
    }
}
