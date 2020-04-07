using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Maydear.SFExpress;
using Microsoft.AspNetCore.Mvc;

namespace SFExpressAspNetCoreSample.Controllers
{
    public class AddOrderController : Controller
    {
        private readonly SfExpressService sfExpressService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sfExpressService"></param>
        public AddOrderController(SfExpressService sfExpressService)
        {
            this.sfExpressService = sfExpressService;
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
