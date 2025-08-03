using API.DTOs;
using API.Extensions;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController(SignInManager<AppUser> signInManager) : BaseApiController
{
    [HttpPost("register")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var user = new AppUser
        {
            FirstName = registerDto.FirstName,
            LastName = registerDto.LastName,
            Email = registerDto.Email,
            UserName = registerDto.Email
        };

        var result = await signInManager.UserManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem();
        }

        return Ok();
    }

    [Authorize]
    [HttpPost("logout")]
    public async Task<ActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return NoContent();
    }

    [HttpGet("user-info")]
    public async Task<ActionResult> GetUserInfo()
    {
        if (User.Identity?.IsAuthenticated == false) return NoContent();

        var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);

        return Ok(new
        {
            user.FirstName,
            user.LastName,
            user.Email,
            Address = user.Address?.ToDto()
        });
    }

    [HttpGet("auth-status")]
    public ActionResult GetAuthState()
    {
        return Ok(new
        {
            IsAuthenticated = User.Identity?.IsAuthenticated ?? false
        });
    }
    
    [Authorize]
    [HttpPost("address")]
    public async Task<ActionResult<Address>> CreateOrUpdateAddress(AddressDto addressDto)
    {
        // Kullanıcıyı email’den (ve adresiyle birlikte) bul
        var user = await signInManager.UserManager.GetUserByEmailWithAddress(User);

        if (user.Address == null)
        {
            // Eğer adresi yoksa yeni adres ekle
            user.Address = addressDto.ToEntity();
        }
        else
        {   
            //Adresi varsa güncelle
            user.Address.UpdateFromDto(addressDto);
        }
             //Kullanıcı bilgilerini DB’ye kaydet
        var result = await signInManager.UserManager.UpdateAsync(user);

        if (!result.Succeeded) return BadRequest("Problem updating user address");

        return Ok(user.Address.ToDto());
    }
}
//örneğin sen postmande json dosyasına firstname ve lastname girdin.
//RegisterDto bu veriyi karşılar (validation yapılır).
//Controller bu veriyi AppUser modeline map eder.
//CreateAsync ile StoreContext üzerinden veritabanına kayıt yapılır.
//Identity tabloları (AspNetUsers) oluşur ve FirstName, LastName kolonları da dolar.

//AppUser bir modeldir.
//DTO (Data Transfer Object) sadece istemciden (Postman, Angular frontend, vb.) gelen veriyi taşımak için kullanılan bir modeldir.

//Register → Postman’dan gelen bilgileri alır, AppUser’a kaydeder. AppUser modelini StoreContext üzerinden veritabanına kaydeder.
//Logout → Giriş yapan kullanıcının cookie’sini/token’ını siler.
//UserInfo → Cookie içindeki email’den kullanıcıyı bulur, bilgilerini döner.
//AuthState → Kullanıcının giriş yapıp yapmadığını kontrol eder.