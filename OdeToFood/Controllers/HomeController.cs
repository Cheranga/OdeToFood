using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => Content("Hello from Home=>Index"));
        }
    }
}
