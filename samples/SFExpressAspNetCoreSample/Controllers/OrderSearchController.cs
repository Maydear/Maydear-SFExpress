using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maydear.SFExpress;
using Maydear.SFExpress.Models;
using Microsoft.AspNetCore.Mvc;

namespace SFExpressAspNetCoreSample.Controllers
{
    [Route("OrderSearch")]
    public class OrderSearchController : Controller
    {
        private readonly SfExpressService sfExpressService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sfExpressService"></param>
        public OrderSearchController(SfExpressService sfExpressService)
        {
            this.sfExpressService = sfExpressService;
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
            });
        }
    }
}
