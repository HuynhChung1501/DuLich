
using Dulich.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Travel.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "SendEmail")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
