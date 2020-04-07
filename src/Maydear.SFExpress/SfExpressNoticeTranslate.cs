using System;
using System.Collections.Generic;
using System.Text;
using Maydear.SFExpress.Internal;
using Maydear.SFExpress.Models;

namespace Maydear.SFExpress
{
    /// <summary>
    /// 顺丰快递通知翻译
    /// </summary>
    public static class SfExpressNoticeTranslate
    {
        /// <summary>
        /// 路由通知报文解析处理
        /// <para>
        /// 详细说明请查看丰桥API说明<seealso cref="https://qiao.sf-express.com/pages/developDoc/index.html?level2=532019"/>
        /// </para>
        /// </summary>
        /// <param name="xmlString">报文字符</param>
        /// <param name="actionProcess">报文解析后执行的处理</param>
        /// <returns>返回响应报文</returns>
        public static string RouteProcess(string xmlString, Func<ExpressPushRouteNode, bool> actionProcess)
        {
            if (xmlString.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(xmlString));
            }
            ExpressPushRouteNode expressPushRouteNode = ExpressPushRouteNodeParser.Parse(xmlString);
            if (expressPushRouteNode == null)
            {
                return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response><Head>ERR</Head><ERROR code=\"4002\">报文解析错误</ERROR></Response>";
            }
            var reult = actionProcess.Invoke(expressPushRouteNode);

            if (reult)
            {
                return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response><Head>OK</Head></Response>";
            }
            else
            {
                return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response><Head>ERR</Head><ERROR code=\"4001\">系统发生数据错误或运行时异常</ERROR></Response>";
            }
        }

        /// <summary>
        /// 订单状态通知报文解析处理
        /// <para>
        /// 详细说明请查看丰桥API说明<seealso cref="https://qiao.sf-express.com/pages/developDoc/index.html?level2=330428"/>
        /// </para>
        /// </summary>
        /// <param name="xmlString">报文字符</param>
        /// <param name="actionProcess">报文解析后执行的处理</param>
        /// <returns>返回响应报文</returns>
        public static string PushOrderStateProcess(string xmlString, Func<ExpressOrderState, bool> actionProcess)
        {
            if (xmlString.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(xmlString));
            }
            ExpressOrderState expressOrderState = ExpressOrderStateParser.Parse(xmlString);
            if (expressOrderState == null)
            {
                return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response><success>false</success><msg>解析报文出错！</msg></Response>";
            }

            var reult = actionProcess.Invoke(expressOrderState);

            if (reult)
            {
                return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response><success>true</success></Response>";
            }
            else
            {
                return "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response><success>false</success><msg>订单状态接收异常</msg></Response>";
            }

        }
    }
}
