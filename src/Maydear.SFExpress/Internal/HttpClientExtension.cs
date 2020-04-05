using Maydear.SFExpress.Internal;
using Maydear.Utilities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    /// <summary>
    /// Http 扩展方法
    /// </summary>
    internal static class HttpClientExtension
    {
        /// <summary>
        /// POST方式执行Http请求
        /// </summary>
        /// <param name="client">httpClient</param>
        /// <param name="requestUri">请求的uri</param>
        /// <param name="xml">发送的xml内容</param>
        /// <param name="verifyCode">校验码</param>
        /// <param name="cancellationToken">取消进程令牌</param>
        /// <returns>返回服务器响应的内容</returns>
        public static Task<string> PostAsync(this HttpClient client, string requestUri, string xml, string verifyCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();
            IDictionary<string, string> param = new Dictionary<string, string>
            {
                { "xml", xml },
                { "verifyCode", verifyCode }
            };
            client.PostAsync(requestUri, new FormUrlEncodedContent(param)).ContinueWith((requestTask) =>
             {
                 if (TaskHelper.HandleFaultsAndCancelation(requestTask, tcs))
                 {
                     return;
                 }

                 try
                 {
                     HttpResponseMessage result = requestTask.Result;
                     if (result.IsSuccessStatusCode)
                     {
                         result.Content.ReadAsStringAsync().ContinueWith((resultTask) =>
                         {
                             if (TaskHelper.HandleFaultsAndCancelation(resultTask, tcs))
                             {
                                 return;
                             }
                             tcs.SetResult(resultTask.Result);
                         });
                     }
                     else
                     {
                         StringBuilder stringBuilder = new StringBuilder();
                         stringBuilder.AppendLine($"({(int)result.StatusCode})");
                         stringBuilder.AppendLine(result.ReasonPhrase);
                         stringBuilder.AppendLine(result.Content.ReadAsStringAsync().Result);
                         tcs.SetException(new HttpRequestException(stringBuilder.ToString()));
                     }
                 }
                 catch (Exception ex)
                 {
                     tcs.SetException(ex);
                 }
             });

            return tcs.Task;
        }

        /// <summary>
        /// POST方式执行Http请求
        /// </summary>
        /// <param name="client">httpClient</param>
        /// <param name="xml">发送的xml内容</param>
        /// <param name="verifyCode">校验码</param>
        /// <param name="cancellationToken">取消进程令牌</param>
        /// <returns>返回服务器响应的内容</returns>
        public static Task<string> PostAsync(this HttpClient client, string xml, string verifyCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return PostAsync(client, Constants.DEFAULT_SERVICE_PATH, xml, verifyCode, cancellationToken);
        }

    }
}
