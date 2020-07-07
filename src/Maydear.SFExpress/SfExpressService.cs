using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Maydear.SFExpress.Internal.Requests;
using Maydear.SFExpress.Models;
using Maydear.SFExpress.Internal.Responses;
using Maydear.SFExpress.Internal;

namespace Maydear.SFExpress
{

    /// <summary>
    /// 顺丰快递服务
    /// </summary>
    public class SfExpressService
    {
        /// <summary>
        /// http请求客户端
        /// </summary>
        protected readonly HttpClient httpClient;

        /// <summary>
        /// 顺丰配置
        /// </summary>
        protected readonly SFExpressOptions options;


        /// <summary>
        /// 构造一个顺丰快递服务
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="options"></param>
        public SfExpressService(HttpClient httpClient, IOptions<SFExpressOptions> options)
        {
            this.httpClient = httpClient;
            this.options = options.Value;
        }

        /// <summary>
        /// 下订单
        /// <para>
        /// 详细说明请查看丰桥API说明<seealso cref="https://qiao.sf-express.com/pages/developDoc/index.html?level2=460077"/>
        /// </para>
        /// </summary>
        /// <param name="expressOrder">快递订单对象</param>
        /// <param name="saveRequestXmlAction">落地请求报文的委托</param>
        /// <param name="saveResponseXmlAction">落地响应报文的委托</param>
        /// <returns></returns>
        public async Task<ExpressOrderReceiptResult> AddOrderAsync(ExpressOrder expressOrder, Action<string> saveRequestXmlAction = null, Action<string> saveResponseXmlAction = null)
        {
            var request = new Request<OrderRequestBody>(new OrderRequestBody(expressOrder), options.ClientCode);
            string xmlContent = request.ToXml();
            saveRequestXmlAction?.Invoke(xmlContent);
            var responseStr = await httpClient.PostAsync(xmlContent, BuidVerifyCode(xmlContent));
            saveResponseXmlAction?.Invoke(responseStr);
            if (responseStr.IsNullOrWhiteSpace())
                return null;
            Response<OrderResponseBody> orderResponse = new Response<OrderResponseBody>() { Body = new OrderResponseBody() };
            orderResponse.Fill(responseStr.ToXmlDocument());
            if (orderResponse.Error != null)
            {
                throw SFExpressException.ThrowException(orderResponse.Error);
            }
            return orderResponse.Body.Result;
        }

        /// <summary>
        /// 订单确认/取消接口
        /// <para>
        /// 详细说明请查看丰桥API说明<seealso cref="https://qiao.sf-express.com/pages/developDoc/index.html?level2=474384"/>
        /// </para>
        /// </summary>
        /// <param name="expressOrderConfirm">快递订单确认对象</param>
        /// <param name="saveRequestXmlAction">落地请求报文的委托</param>
        /// <param name="saveResponseXmlAction">落地响应报文的委托</param>
        /// <returns></returns>
        public async Task<ExpressOrderConfirmResult> OrderConfirmAsync(ExpressOrderConfirm expressOrderConfirm, Action<string> saveRequestXmlAction = null, Action<string> saveResponseXmlAction = null)
        {
            var request = new Request<OrderConfirmRequestBody>(new OrderConfirmRequestBody(expressOrderConfirm), options.ClientCode);
            string xmlContent = request.ToXml();
            saveRequestXmlAction?.Invoke(xmlContent);
            var responseStr = await httpClient.PostAsync(xmlContent, BuidVerifyCode(xmlContent));
            saveResponseXmlAction?.Invoke(responseStr);
            if (responseStr.IsNullOrWhiteSpace())
                return null;
            Response<OrderConfirmResponseBody> orderResponse = new Response<OrderConfirmResponseBody>() { Body = new OrderConfirmResponseBody() };
            orderResponse.Fill(responseStr.ToXmlDocument());
            if (orderResponse.Error != null)
            {
                throw SFExpressException.ThrowException(orderResponse.Error);
            }
            return orderResponse.Body.Result;
        }

        /// <summary>
        /// 订单结果查询接口
        /// <para>
        /// 详细说明请查看丰桥API说明<seealso cref="https://qiao.sf-express.com/pages/developDoc/index.html?level2=351082"/>
        /// </para>
        /// </summary>
        /// <param name="expressOrderQuery">快递订单查询</param>
        /// <param name="saveRequestXmlAction">落地请求报文的委托</param>
        /// <param name="saveResponseXmlAction">落地响应报文的委托</param>
        /// <returns>返回响应数据</returns>
        public async Task<ExpressOrderBaseResult> OrderSearchAsync(ExpressOrderSearch expressOrderQuery, Action<string> saveRequestXmlAction = null, Action<string> saveResponseXmlAction = null)
        {
            var request = new Request<OrderSearchRequestBody>(new OrderSearchRequestBody(expressOrderQuery), options.ClientCode);
            string xmlContent = request.ToXml();
            saveRequestXmlAction?.Invoke(xmlContent);
            var responseStr = await httpClient.PostAsync(xmlContent, BuidVerifyCode(xmlContent));
            saveResponseXmlAction?.Invoke(responseStr);
            if (responseStr.IsNullOrWhiteSpace())
                return null;
            Response<OrderBaseResponseBody> orderResponse = new Response<OrderBaseResponseBody>() { Body = new OrderBaseResponseBody() };
            orderResponse.Fill(responseStr.ToXmlDocument());
            if (orderResponse.Error != null)
            {
                throw SFExpressException.ThrowException(orderResponse.Error);
            }
            return orderResponse.Body.Result;
        }

        /// <summary>
        /// 订单筛选接口，客户系统通过此接口向顺丰系统发送主动的筛单请求,用于判断客户的收、派地址是否属于顺丰的收派范围。
        /// <para>
        /// 详细说明请查看丰桥API说明<seealso cref="https://qiao.sf-express.com/pages/developDoc/index.html?level2=226758"/>
        /// </para>
        /// </summary>
        /// <param name="expressOrderQuery">快递订单搜索对象</param>
        /// <param name="saveRequestXmlAction">落地请求报文的委托</param>
        /// <param name="saveResponseXmlAction">落地响应报文的委托</param>
        /// <returns>返回地址的筛选结果</returns>
        public async Task<ExpressOrderFilterResult> OrderFilterAsync(ExpressOrderFilter expressOrderFilter, Action<string> saveRequestXmlAction = null, Action<string> saveResponseXmlAction = null)
        {
            var request = new Request<OrderFilterRequestBody>(new OrderFilterRequestBody(expressOrderFilter), options.ClientCode);
            string xmlContent = request.ToXml();
            saveRequestXmlAction?.Invoke(xmlContent);
            var responseStr = await httpClient.PostAsync(xmlContent, BuidVerifyCode(xmlContent));
            saveResponseXmlAction?.Invoke(responseStr);
            if (responseStr.IsNullOrWhiteSpace())
                return null;
            Response<OrderFilterResponseBody> orderResponse = new Response<OrderFilterResponseBody>() { Body = new OrderFilterResponseBody() };
            orderResponse.Fill(responseStr.ToXmlDocument());
            if (orderResponse.Error != null)
            {
                throw SFExpressException.ThrowException(orderResponse.Error);
            }
            return orderResponse.Body.Result;
        }

        /// <summary>
        /// 路由查询接口
        /// <para>
        /// 详细说明请查看丰桥API说明<seealso cref="https://qiao.sf-express.com/pages/developDoc/index.html?level2=314896"/>
        /// </para>
        /// </summary>
        /// <param name="expressRoute"></param>
        /// <param name="saveRequestXmlAction">落地请求报文的委托</param>
        /// <param name="saveResponseXmlAction">落地响应报文的委托</param>
        /// <returns></returns>
        public async Task<IEnumerable<ExpressRouteGroup>> RouteAsync(ExpressRoute expressRoute, Action<string> saveRequestXmlAction = null, Action<string> saveResponseXmlAction = null)
        {
            var request = new Request<RouteRequestBody>(new RouteRequestBody(expressRoute), options.ClientCode);
            string xmlContent = request.ToXml();
            saveRequestXmlAction?.Invoke(xmlContent);
            var responseStr = await httpClient.PostAsync(xmlContent, BuidVerifyCode(xmlContent));
            saveResponseXmlAction?.Invoke(responseStr);
            if (responseStr.IsNullOrWhiteSpace())
                return null;
            Response<RouteResponseBody> routeResponse = new Response<RouteResponseBody>() { Body = new RouteResponseBody() };
            routeResponse.Fill(responseStr.ToXmlDocument());
            if (routeResponse.Error != null)
            {
                throw SFExpressException.ThrowException(routeResponse.Error);
            }
            return routeResponse.Body.Result;
        }

        /// <summary>
        /// 子单号申请接口
        /// <para>
        /// 详细说明请查看丰桥API说明<seealso cref="https://qiao.sf-express.com/pages/developDoc/index.html?level2=491555"/>
        /// </para>
        /// </summary>
        /// <param name="expressOrderZD">顺丰子订单号申请实体</param>
        /// <param name="saveRequestXmlAction">落地请求报文的委托</param>
        /// <param name="saveResponseXmlAction">落地响应报文的委托</param>
        /// <returns></returns>
        public async Task<ExpressOrderZDResult> SubOrderRequestAsync(ExpressOrderZD expressOrderZD, Action<string> saveRequestXmlAction = null, Action<string> saveResponseXmlAction = null)
        {
            var request = new Request<OrderZDRequestBody>(new OrderZDRequestBody(expressOrderZD), options.ClientCode);
            string xmlContent = request.ToXml();
            saveRequestXmlAction?.Invoke(xmlContent);
            var responseStr = await httpClient.PostAsync(xmlContent, BuidVerifyCode(xmlContent));
            saveResponseXmlAction?.Invoke(responseStr);
            if (responseStr.IsNullOrWhiteSpace())
                return null;
            Response<OrderZDResponseBody> orderResponse = new Response<OrderZDResponseBody>() { Body = new OrderZDResponseBody() };
            orderResponse.Fill(responseStr.ToXmlDocument());
            if (orderResponse.Error != null)
            {
                throw SFExpressException.ThrowException(orderResponse.Error);
            }
            return orderResponse.Body.Result;
        }

        /// <summary>
        /// 创建校验码
        /// </summary>
        /// <param name="xmlString">报文字符</param>
        /// <returns>返回报文字符生产的额校验码</returns>
        private string BuidVerifyCode(string xmlString)
        {
            return $"{xmlString}{this.options.Checkword}".MD5ToBase64();
        }
    }
}
