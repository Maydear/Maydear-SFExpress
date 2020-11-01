using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maydear.SFExpress;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sample.Controllers
{
    public class AddOrderController : Controller
    {
        private readonly SfExpressService sfExpressService;
        private readonly ILogger<RouteController> logger;

        public AddOrderController(SfExpressService sfExpressService, ILogger<RouteController> logger)
        {
            this.sfExpressService = sfExpressService;
            this.logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }


    }
}
