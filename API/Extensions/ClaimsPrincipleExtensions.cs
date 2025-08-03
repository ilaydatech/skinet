using System;
using System.Security.Authentication;
using System.Security.Claims;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

//ClaimsPrincipleExtensions → Login olan kullanıcıyı cookie/email üzerinden kolayca bulmanı sağlar.
public static class ClaimsPrincipleExtensions
{
    public static async Task<AppUser> GetUserByEmail(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
        var userToReturn = await userManager.Users.FirstOrDefaultAsync(x =>
            x.Email == user.GetEmail());

        if (userToReturn == null) throw new AuthenticationException("User not found");

        return userToReturn;
    }

//Bu method, kullanıcıyı email’den bulup adres bilgisiyle birlikte geri döndürür.
     public static async Task<AppUser> GetUserByEmailWithAddress(this UserManager<AppUser> userManager, ClaimsPrincipal user)
    {
        var userToReturn = await userManager.Users
            .Include(x => x.Address) //AppUser tablosuna bağlı Address tablosunu da sorguya dahil eder.
            .FirstOrDefaultAsync(x => x.Email == user.GetEmail()); // Cookie içindeki email ile DB’de arama yapar.

        if (userToReturn == null) throw new AuthenticationException("User not found");

        return userToReturn;
    }

    public static string GetEmail(this ClaimsPrincipal user)
    {
        var email = user.FindFirstValue(ClaimTypes.Email)
            ?? throw new AuthenticationException("Email claim not found");
        return email;
    }
}