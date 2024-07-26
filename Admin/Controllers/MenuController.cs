
using Dulich.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class MenuController : Controller
    {
        #region search

        #endregion
        public IActionResult Index()
        {
            return View();
        }


        #region Thêm mới menu
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Create(Menu menu)
        { 
            return View(menu);
        }
        #endregion

    }
}
