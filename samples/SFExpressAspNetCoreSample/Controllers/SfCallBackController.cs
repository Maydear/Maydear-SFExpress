using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Maydear.SFExpress;
using Microsoft.AspNetCore.Mvc;

namespace SFExpressAspNetCoreSample.Controllers
{
    /// <summary>
    /// 顺丰回调
    /// </summary>
    /// <remarks>
    /// 注意：顺丰的回调只支持http，不支持https，如果使用https需要联系顺丰开通。
    /// </remarks>
    [Route("callBack/v1/[controller]")]
    public class SfCallBackController : Controller
    {
        /// <summary>
        /// 路由推送回调form模式
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns>返回报文结构体</returns>
        [HttpPost("Route")]
        public IActionResult Route(string content)
        {
            var resultString = "";
            try
            {
                resultString = SfExpressNoticeTranslate.RouteProcess(content, s =>
                {
                    //处理回调信息
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(s));
                    return true;
                });
            }
            catch (Exception ex)
            {
                resultString = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response service=\"RoutePushService\"><Head>ERR</Head><ERROR code=\"4001\">" + ex.Message + "</ERROR></Response>";
            }

            return Content(resultString, "application/xml");
        }


        /// <summary>
        /// 路由推送回调text模式
        /// </summary>
        /// <returns>返回报文实体</returns>
        [HttpPost("Route/text")]
        public async Task<IActionResult> Route()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var content = await reader.ReadToEndAsync();
                var resultString = "";
                try
                {
                    resultString = SfExpressNoticeTranslate.RouteProcess(content, s =>
                    {
                        //处理回调信息
                        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(s));
                        return true;
                    });
                }
                catch (Exception ex)
                {
                    resultString = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response service=\"RoutePushService\"><Head>ERR</Head><ERROR code=\"4001\">" + ex.Message + "</ERROR></Response>";
                }

                return Content(resultString, "application/xml");
            }
        }

        /// <summary>
        /// 快递揽收状态回调
        /// </summary>
        /// <param name="content">内容</param>
        /// <returns>返回报文实体</returns>
        [HttpPost("OrderState")]
        public IActionResult OrderState(string content)
        {
            var resultString = "";
            try
            {
                resultString = SfExpressNoticeTranslate.PushOrderStateProcess(content, s =>
                {
                    Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(s));
                    return true;
                });
            }
            catch (Exception ex)
            {
                resultString = $"<?xml version=\"1.0\" encoding=\"UTF-8\" ?><Response><success>false</success><msg>{ex.Message}</msg></Response>";
            }

            return Content(resultString, "application/xml");
        }
    }
}
