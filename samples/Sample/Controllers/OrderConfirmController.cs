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
    [Route("OrderConfirm")]
    public class OrderConfirmController : Controller
    {
        private readonly SfExpressService sfExpressService;
        private readonly ILogger<RouteController> logger;

        public OrderConfirmController(SfExpressService sfExpressService, ILogger<RouteController> logger)
        {
            this.sfExpressService = sfExpressService;
            this.logger = logger;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<ExpressOrderConfirmResult> Index(string orderid, string mailNo)
        {
            return sfExpressService.OrderConfirmAsync(new ExpressOrderConfirm(){
                DealType = DealType.Cancel,
                MailNo= mailNo,
                OrderId= orderid
            }, s => logger.LogWarning(s), s => logger.LogWarning(s));
        }
    }
}
