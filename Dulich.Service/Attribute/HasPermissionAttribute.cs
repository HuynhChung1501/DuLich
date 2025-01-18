
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
public class HasPermissionAttribute : Attribute, IAuthorizationFilter
{
    public EnumPermission[] Permissions { get; set; }
    public EnumModule[] Modules { get; set; }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        Modules = Modules ?? new EnumModule[] {};
        Permissions = Permissions ?? new EnumPermission[] {};
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
        var userId = userIdClaim.Value;
        bool isAccess = false;
        isAccess = await CheckPermission(userId, Modules, Permissions);
        // Kiểm tra module
        if (!isAccess)
        {
            context.Result = new ForbidResult(); // HTTP 403 nếu không thuộc module
            return;
        }
    }

    public async Task<bool> CheckPermission(string userId, EnumModule[] Modules, EnumPermission[] Permissions)
    {

        return true;
    }
}