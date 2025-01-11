using AutoMapper;
using Dulich.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.InterfaceService;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json.Linq;

namespace Travel.Application.Services
{
     public class LoginService : BaseMasterService, ILoginService
    {

        private readonly IMapper _mapper;
        private readonly DASContext _travale;
        private readonly IConfiguration _config;
        private readonly IPhanQuyenService _phanQuyenService;

        public LoginService(IPhanQuyenService phanQuyenService, ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext, IConfiguration configuration) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _travale = dASContext;
            _config = configuration;
            _phanQuyenService = phanQuyenService;

        }
        public async Task<string> GenerateToken(Account acount)
        {
            var JwtTokenHadler = new JwtSecurityTokenHandler();
            var secretKey = _config["AppSettings:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Secret key is not configured.");
            }
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey ?? string.Empty);
            var roles = await (_phanQuyenService.GetRolesByUser(acount.ID));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, acount.FullName),
                    new Claim(ClaimTypes.Email, acount.Email ?? string.Empty),
                    new Claim(ClaimTypes.Role, acount.Email ?? string.Empty),
                    new Claim("UsereName", acount.UsereName),
                    new Claim("UserId", acount.ID.ToString()),
                    new Claim("TokenId", Guid.NewGuid().ToString()),
            };
            claims.AddRange(roles.Select(roles => new Claim("Permission", roles.Module_type.ToString())));
            claims.AddRange(roles.Select(roles => new Claim("Module", roles.Permission_type.ToString())));

            var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(5),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256)
);
            
            foreach (var claim in token.Claims)
            {
                Console.WriteLine($"{claim.Type}: {claim.Value}");
            }
            // Trả về chuỗi token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
