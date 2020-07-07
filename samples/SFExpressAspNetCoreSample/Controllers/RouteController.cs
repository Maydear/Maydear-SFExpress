using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maydear.SFExpress;
using Maydear.SFExpress.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SFExpressAspNetCoreSample.Controllers
{
    /// <summary>
    /// 路由页面
    /// </summary>
    [Route("Route")]
    public class RouteController : Controller
    {
        private readonly SfExpressService sfExpressService;
        private readonly ILogger<RouteController> logger;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sfExpressService"></param>
        public RouteController(SfExpressService sfExpressService,ILogger<RouteController> logger)
        {
            this.sfExpressService = sfExpressService;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<IEnumerable<ExpressRouteGroup>> Index(string[] mailNo)
        {
            return sfExpressService.RouteAsync(new Maydear.SFExpress.Models.ExpressRoute()
            {
                MethodType = RouteMethodType.Standard,
                TrackingType = TrackingType.MailNumber,
                TrackingNumber = mailNo
            }, s=>logger.LogWarning(s), s => logger.LogWarning(s));
        }
    }
}
