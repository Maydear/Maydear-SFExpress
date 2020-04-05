using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace System
{
    internal static class XmlDocumentExtension
    {
        /// <summary>
        /// 将XML格式的字符串转换为XMLDocument对象
        /// </summary>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static XmlDocument ToXmlDocument(this string xmlString)
        {
            XmlDocument xmlDocument = new XmlDocument
            {
                PreserveWhitespace = true
            };
            MemoryStream inStream = new MemoryStream(new UTF8Encoding().GetBytes(xmlString));
            xmlDocument.Load(inStream);
            return xmlDocument;
        }

        /// <summary>
        /// 获取节点内容
        /// </summary>
        /// <param name="doc">XML文档</param>
        /// <param name="tagName">标记名称</param>
        /// <returns></returns>
        public static string GetNodeText(this XmlDocument responseDoc, string tagName)
        {
            XmlNodeList elementsByTagName = responseDoc.GetElementsByTagName(tagName);
            if (elementsByTagName != null && elementsByTagName[0] != null)
            {
                return elementsByTagName[0].InnerXml;
            }
            return string.Empty;
        }


        /// <summary>
        /// 获取节点内容
        /// </summary>
        /// <param name="doc">XML文档</param>
        /// <param name="tagName">标记名称</param>
        /// <returns></returns>
        public static IDictionary<string, string> GetNodeAttributes(this XmlDocument responseDoc, string tagName)
        {
            XmlNodeList elementsByTagName = responseDoc.GetElementsByTagName(tagName);
            if (elementsByTagName != null && elementsByTagName[0] != null)
            {
                IDictionary<string, string> dict = new Dictionary<string, string>();
                foreach (XmlAttribute item in elementsByTagName[0].Attributes)
                {
                    dict.Add(item.Name, item.Value);
                }
            }
            return null;
        }

        /// <summary>
        /// 获取节点内容
        /// </summary>
        /// <param name="doc">XML文档</param>
        /// <param name="tagName">标记名称</param>
        /// <returns></returns>
        public static IDictionary<string, string> GetAttributes(this XmlNode xmlNode)
        {

            IDictionary<string, string> dict = new Dictionary<string, string>();
            if (xmlNode == null)
            {
                return dict;
            }

            foreach (XmlAttribute item in xmlNode.Attributes)
            {
                dict.Add(item.Name, item.Value);
            }
            return dict;
        }

    }
}
