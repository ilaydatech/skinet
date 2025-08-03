using System;
using Microsoft.AspNetCore.Identity;

namespace Core.Entities;
//Bu bir kullanıcı modeli
//ASP.NET Core Identity’nin sağladığı kullanıcı modelini (IdentityUser) genişletiyor.
//IdentityUser zaten Email, UserName, PasswordHash gibi alanlara sahip.
//AppUser ile sen kendi alanlarını (FirstName, LastName) ekliyorsun

public class AppUser : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Address? Address { get; set; }
    
}
