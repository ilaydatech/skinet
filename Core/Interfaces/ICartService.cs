using System;
using Core.Entities;

namespace Infrastructure;

public interface ICartService
{
    Task<ShoppingCart?> GetCartAsync(string key);
    Task<ShoppingCart?> SetCartAsync(ShoppingCart cart);
    Task<bool> DeleteCartAsync(string key);
}
//Docker Compose → Redis’i başlatır
//Program.cs → Redis’e bağlantı açar
//ShoppingCart → Redis’e yazılacak veriyi tanımlar
//CartService → Redis ile Set/Get/Delete işlemleri yapar
//CartController → API üzerinden istek alır, CartService’e yönlendirir