using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ZStore_WEB.Models;

namespace ZStore_WEB.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
