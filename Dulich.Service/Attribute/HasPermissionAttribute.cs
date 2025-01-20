
using AutoMapper;
using Dulich.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Travel.Application.Enums;
using Travel.Application.Helpers;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Travel.Application.InterfaceService;
using Travel.Domain.Interface;
using Travel.Domain.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using System.Linq;
using Travel.Infrastructure.Migrations;
using System.Security.Claims;
using Travel.Utility;
public class HasPermissionAttribute : Attribute, IAuthorizationFilter
{
    public string Permissions { get; set; }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        
        var user = context.HttpContext.User;
        if (user?.Identity == null || !user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == "IdUser");
        if (userIdClaim == null)
        {
            throw new AppException("User ID claim is missing or invalid");
        }

        var permission = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
        if (permission != null) {
            string permissionValueint = Utils.GetDescriptionByValue(EnumPermission.Admin);
            if (permissionValueint != Permissions)
            {
                context.Result = new ForbidResult(); // HTTP 403 nếu không thuộc module
            }
        }
        else
        {
            throw new AppException("User hiện tại chưa được phần quyền");
        }
    }

}