using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Net.Http
{
    internal class RetryHandler : DelegatingHandler
    {
        public int RetryCount { get; set; } = 5;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            for (int i = 0; i < RetryCount; i++)
            {
                try
                {
                    return await base.SendAsync(request, cancellationToken);
                }
                catch (HttpRequestException) when (i == RetryCount - 1)
                {
                    throw;
                }
                catch (HttpRequestException)
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(50 * (i+1)));
                }
            }
            throw null;
        }
    }
}
