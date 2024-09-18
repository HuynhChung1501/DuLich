using AutoMapper;
using Dulich.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Travel.Application.InterfaceService;
using Travel.Domain.Interface;
using Travel.Domain.Models;

namespace Travel.Application.Services
{
     public class LoginService : BaseMasterService, ILoginService
    {

        private readonly IMapper _mapper;
        private readonly DASContext _travale;
        private readonly IConfiguration _config;

        public LoginService(ITravelRepositoryWrapper travelRepository, IMapper mapper, DASContext dASContext, IConfiguration configuration) : base(travelRepository)
        {
            _mapper = mapper;
            _travelRepo = travelRepository;
            _travale = dASContext;
            _config = configuration;

        }
        public string GenerateToken(Account acount)
        {
            var JwtTokenHadler = new JwtSecurityTokenHandler();
            var secretKey = _config["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey ?? string.Empty);

            var TokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, acount.FullName),
                    new Claim(ClaimTypes.Email, acount.Email ?? string.Empty),
                    new Claim("UsereName", acount.UsereName),
                    new Claim("Id", acount.ID.ToString()),

                    //Roles

                    new Claim("TokenId", Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var toKen = JwtTokenHadler.CreateToken(TokenDescription ?? new SecurityTokenDescriptor());
            return JwtTokenHadler.WriteToken(toKen);
        }
    }
}
