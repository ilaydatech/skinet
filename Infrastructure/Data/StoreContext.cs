using System;
using Core.Entities;
using Infrastructure.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

//DbSet<Product>	EF Core'a bu entity için bir tablo oluşturmasını söyler
//DbContextOptions	Bağlantı dizesi gibi ayarları dışarıdan alır
//OnModelCreating	İlişkiler, kolon ayarları gibi detayları tanımlar
//ApplyConfigurationsFromAssembly	ProductConfiguration.cs gibi tüm konfigürasyon dosyalarını otomatik uygular
public class StoreContext(DbContextOptions options) : IdentityDbContext<AppUser>(options)
{
    //IdentityDbContext<AppUser> sayesinde firstname lastname gibi alanlar apsNetUsers tablosuna eklenir.
    //Bir Products tablosu oluştur. Her satırı Product sınıfının bir örneği olacak
    public DbSet<Product> Products { get; set; }

    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
    }
}
