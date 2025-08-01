using System;
using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

//{{url}}/api/cart?id=cart1 ile postmanda ulaşıyoruz.
public class CartController(ICartService cartService) : BaseApiController
{
    // Sepeti id'ye göre getir (Redis'ten)
    [HttpGet]
    public async Task<ActionResult<ShoppingCart>> GetCartById(string id) //Dönene cevap ShppingCart olacak.
    {
        var cart = await cartService.GetCartAsync(id);
        //GetCartAsync(id) → Servise “Bu ID’ye ait sepeti getir” diyoruz.
        return Ok(cart ?? new ShoppingCart { Id = id });
    }
    [HttpPost]
    public async Task<ActionResult<ShoppingCart>> UpdateCart(ShoppingCart cart)
    {
        var updatedCart = await cartService.SetCartAsync(cart);

        if (updatedCart == null) return BadRequest("Problem with cart");

        return updatedCart;
    }
    [HttpDelete]
    public async Task<ActionResult> DeleteCart(string id)
    {
        var result = await cartService.DeleteCartAsync(id);

        if (!result) return BadRequest("Problem deleting cart");

        return Ok();
    }

}
