using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maydear.SFExpress;
using Maydear.SFExpress.Models;
using Microsoft.AspNetCore.Mvc;

namespace SFExpressAspNetCoreSample.Controllers
{
    [Route("OrderConfirm")]
    public class OrderConfirmController : Controller
    {
        private readonly SfExpressService sfExpressService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sfExpressService"></param>
        public OrderConfirmController(SfExpressService sfExpressService)
        {
            this.sfExpressService = sfExpressService;
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
            });
        }
    }
}
