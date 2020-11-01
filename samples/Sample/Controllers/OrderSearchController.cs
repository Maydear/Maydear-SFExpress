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
    [Route("OrderSearch")]
    public class OrderSearchController : Controller
    {
        private readonly SfExpressService sfExpressService;
        private readonly ILogger<RouteController> logger;

        public OrderSearchController(SfExpressService sfExpressService, ILogger<RouteController> logger)
        {
            this.sfExpressService = sfExpressService;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<ExpressOrderBaseResult> Index(string orderid)
        {
            return sfExpressService.OrderSearchAsync(new Maydear.SFExpress.Models.ExpressOrderSearch()
            {
                OrderId = orderid,
                SearchType = OrderSearchType.Normal
            }, s => logger.LogWarning(s), s => logger.LogWarning(s));
        }
    }
}
