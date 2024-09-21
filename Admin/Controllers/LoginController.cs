using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Travel.Application.InterfaceService;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Travel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITravelRepositoryWrapper _travelRepo;
        private readonly ILoginService _loginService;
       

        public LoginController(IMapper mapper, ITravelRepositoryWrapper travelRepo, IConfiguration config, ILoginService loginService)
        {
            _mapper = mapper;
            _travelRepo = travelRepo;
            _loginService = loginService;
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            var user = await _travelRepo.Account.SingleOrDefaultAsync(u => u.UsereName == model.UsereName && u.PassWord == model.PassWord);
            if (user == null)
            {
                return Ok(new ApiResponse
                {
                    Message = "UserName, Password không chính xác!",
                    Success = true,
                });
            }
            else
            {
                return Ok(new ApiResponse
                {
                    Message = "Đăng nhập thành công!",
                    Success = true,
                    Data = _loginService.GenerateToken(user)
                });
            }
        }



        #region kiếm tra dữ liệu
        //[HttpPost]
        //public async Task<IActionResult> ValSignIn(LoginModel model)
        //{
        //    if(model == null)
        //    {
        //        return BadRequest(new ApiResponse
        //        {
        //            Message = "Trường UserName không được bỏ trống!",
        //            Success = false,
        //        });
        //    }
        //    if (model.UsereName == "111") 
        //    {
        //        return BadRequest(new ApiResponse
        //        {
        //            Message = "Trường UserName không được bỏ trống!",
        //            Success = false,
        //        });
        //    }
        //    if (string.IsNullOrEmpty(model.PassWord))
        //    {
        //        return BadRequest(new ApiResponse
        //        {
        //            Message = "Trường PassWord không được bỏ trống!",
        //            Success = false,
        //        });
        //    }

        //    return Ok(new ApiResponse
        //    {
        //        Success = true,
        //        Data = model
        //    });
        //}

        #endregion
    }
}
