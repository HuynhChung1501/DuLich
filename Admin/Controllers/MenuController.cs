
using AutoMapper;
using Dulich.Domain.Models;
using Dulich.Infrastructure;
using Dulich.Service.Service;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMapper _mapper;
        private readonly DASContext _dasContext;
        private readonly MenuService _menuService;

        public MenuController(DASContext dasContext, IMapper mapper)
        {
            _mapper = mapper;
            _dasContext = dasContext;
        }

        #region search
        public IActionResult Index()
        {
            
            var rs = _menuService.GetAll();
            if (rs != null )
            {
                return View(rs);
            }
            return View(new MenuModel());
        }
        #endregion

        #region Thêm mới menu
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MenuModel menu)
        {
            var rs = _mapper.Map<MenuModel>(menu);
            _dasContext.Add(rs);
            _dasContext.SaveChanges();
            return View(menu);
        }
        #endregion

    }
}
