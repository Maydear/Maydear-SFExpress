using System;
using System.Xml;

namespace Maydear.SFExpress.Internal.Responses
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Response<T> : IResponseBody where T : IResponseBody
    {
        /// <summary>
        /// 服务名称
        /// </summary>
        public string ServiceName { get; }

        /// <summary>
        /// 头信息
        /// </summary>
        public string Head { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public ErrorBody Error { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T Body { get; set; }

        /// <summary>
        /// 填充对象
        /// </summary>
        /// <param name="xmlDocument"></param>
        public void Fill(XmlDocument xmlDocument)
        {
            var headContent = xmlDocument.GetNodeText("Head");

            if (headContent.Equals("OK"))
            {
                Error = null;
                Body?.Fill(xmlDocument);
            }
            else if (headContent.Equals("ERR"))
            {
                Error = new ErrorBody();
                Error.Fill(xmlDocument);
            }
        }
    }
}
