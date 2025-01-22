using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Travel.Application.Helpers;
using Travel.Application.InterfaceService;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using Travel.Utility;
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
            if (Utils.IsNullOrEmpty(model.UsereName) && Utils.IsNullOrEmpty(model.PassWord) )
            {
                return BadRequest(new { message = "Trường UserName và Password không được để trống!" });
            }
            var user = await _travelRepo.Account.SingleOrDefaultAsync(u => u.UsereName == model.UsereName);

            if (user == null || model.UsereName == string.Empty)
            {
                return Unauthorized(new { message = "Đăng nhập không thành công!" });
            }

            bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(model.PassWord, user?.PassWord);
            if (isPasswordMatch)
            {
                return Ok(new { message = "Đăng nhập thành công!" , dataToken = _loginService.GenerateToken(user)});
            }
            else
            {
                return Unauthorized(new { message = "Đăng nhập không thành công!" });
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
