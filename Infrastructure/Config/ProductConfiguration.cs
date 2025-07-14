using System;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace Infrastructure.Config;

 //Bu sınıf, Product tablosunun veritabanındaki özelliklerini (kurallarını) belirliyor.
public class ProductConfiguration : IEntityTypeConfiguration<Product> //Bu sınıf Product modeli için özel ayarları tanımlar.


{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Name).IsRequired();
    }
}
