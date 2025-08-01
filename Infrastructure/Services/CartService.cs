using System;
using System.Text.Json;
using Core.Entities;
using StackExchange.Redis;

namespace Infrastructure.Services;

//Bu servis sadece sepete ait verileri Redis’te tutmak için var.
//CartService sınıfı, IConnectionMultiplexer üzerinden Redis’e bağlanıyor.
public class CartService(IConnectionMultiplexer redis) : ICartService
{
    private readonly IDatabase _database = redis.GetDatabase();
    //Redis’te bir veritabanı (cache alanı) alıyor.
    //redis.GetDatabase() = Redis’teki veri deposunu açar;
    public async Task<bool> DeleteCartAsync(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }
    //Verilen key (örn: "basket_user123") ile Redis’teki o sepeti sil

    public async Task<ShoppingCart?> GetCartAsync(string key)
    {
        var data = await _database.StringGetAsync(key);
        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<ShoppingCart?>(data!);
    }

    public async Task<ShoppingCart?> SetCartAsync(ShoppingCart cart)
    {
        var created = await _database.StringSetAsync(cart.Id,
        JsonSerializer.Serialize(cart), TimeSpan.FromDays(30));

        if (!created) return null;
        return await GetCartAsync(cart.Id);
    }
    //ShoppingCart nesnesinde Id genelde: Kullanıcı giriş yaptıysa → Kullanıcı Id
    //Giriş yapmadıysa → Tarayıcıya özel random GUI
}
 