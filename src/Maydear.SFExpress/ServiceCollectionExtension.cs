using Maydear.SFExpress;
using Maydear.SFExpress.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Polly;
using Polly.Registry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 存储对象
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 增加HTTP服务依赖
        /// </summary>
        /// <param name="services">依赖注入服务集合</param>
        /// <param name="configuration">配置对象</param>
        /// <returns>依赖注入服务集合</returns>
        public static IServiceCollection AddSfExpressService(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return services.AddSfExpressService(options =>
            {
                options.Checkword = configuration.GetSection("Express:SFExpress:Checkword").Value ?? configuration.GetSection("SFExpress:Checkword").Value;
                options.ClientCode = configuration.GetSection("Express:SFExpress:ClientCode").Value ?? configuration.GetSection("SFExpress:ClientCode").Value;
            });
        }

        /// <summary>
        /// 增加HTTP服务依赖
        /// </summary>
        /// <param name="services">依赖注入服务集合</param>
        /// <param name="setupOptions">顺丰快递选项</param>
        /// <returns>依赖注入服务集合</returns>
        public static IServiceCollection AddSfExpressService(this IServiceCollection services, Action<SFExpressOptions> setupOptions)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (setupOptions == null)
            {
                throw new ArgumentNullException(nameof(setupOptions));
            }
            services.AddOptions();
            services.Configure(setupOptions);
            if (!services.Any((ServiceDescriptor d) => d.ServiceType == typeof(SfExpressService)))
            {
                services.AddHttpClient(c =>
                {
                    c.BaseAddress = new Uri(Constants.DEFAULT_DOMAIN);
                    c.DefaultRequestHeaders.Connection.Add("keep-alive");
                    c.Timeout = TimeSpan.FromSeconds(60);
                    c.MaxResponseContentBufferSize = int.MaxValue; // 10 MB
                });
            }
            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configureClient"></param>
        /// <returns></returns>
        private static IHttpClientBuilder AddHttpClient(this IServiceCollection services, Action<HttpClient> configureClient)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            if (configureClient == null)
            {
                throw new ArgumentNullException(nameof(configureClient));
            }
            IPolicyRegistry<string> registry = services.AddPolicyRegistry();

            Polly.Timeout.TimeoutPolicy<HttpResponseMessage> timeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10));
            Polly.Timeout.TimeoutPolicy<HttpResponseMessage> longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60));

            registry.Add("regular", timeout);
            registry.Add("long", longTimeout);

            return services.AddHttpClient("SFExpress", configureClient)
              .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(100)))
              .AddPolicyHandlerFromRegistry("regular")
              .AddPolicyHandler((request) =>
              {
                  return request.Method == HttpMethod.Get ? timeout : longTimeout;
              })
              .AddPolicyHandlerFromRegistry((reg, request) =>
              {
                  return request.Method == HttpMethod.Get ?
                      reg.Get<IAsyncPolicy<HttpResponseMessage>>("regular") :
                      reg.Get<IAsyncPolicy<HttpResponseMessage>>("long");
              })
              .AddTransientHttpErrorPolicy(p => p.RetryAsync())
              .AddHttpMessageHandler(() => new RetryHandler())
              .AddTypedClient<SfExpressService>();
        }
    }
}
