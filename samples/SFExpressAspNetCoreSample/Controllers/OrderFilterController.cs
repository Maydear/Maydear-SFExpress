using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maydear.SFExpress;
using Maydear.SFExpress.Models;
using Microsoft.AspNetCore.Mvc;

namespace SFExpressAspNetCoreSample.Controllers
{
    [Route("OrderFilter")]
    public class OrderFilterController : Controller
    {
        private readonly SfExpressService sfExpressService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sfExpressService"></param>
        public OrderFilterController(SfExpressService sfExpressService)
        {
            this.sfExpressService = sfExpressService;
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
            });
        }
    }
}
