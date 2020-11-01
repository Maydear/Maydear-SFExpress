using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maydear.SFExpress;
using Maydear.SFExpress.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sample.Controllers
{
    [Route("OrderFilter")]
    public class OrderFilterController : Controller
    {
        private readonly SfExpressService sfExpressService;
        private readonly ILogger<RouteController> logger;

        public OrderFilterController(SfExpressService sfExpressService, ILogger<RouteController> logger)
        {
            this.sfExpressService = sfExpressService;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<ExpressOrderFilterResult> Index(string address)
        {
            return sfExpressService.OrderFilterAsync(new ExpressOrderFilter()
            {
                FilterType= FilterType.Auto,
                ToFullAddress = address
            }, s => logger.LogWarning(s), s => logger.LogWarning(s));
        }
    }
}
