using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return BadRequest(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}