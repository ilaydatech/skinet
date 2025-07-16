using System;
using Core.Entities;

namespace Core.Interfaces;
//bu bir class değil interface dosyası
public interface IProductRepository
{
    // Fonksiyon imzaları (planlar)
    //product → fonksiyonun içine giren o anki veri (örnek ürün).
    Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort);
    Task<Product?> GetProductByIdAsync(int id);
    Task<IReadOnlyList<string>> GetBrandsAsync();
    Task<IReadOnlyList<string>> GetTypesAsync();
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
    bool ProductExists(int id);
    Task<bool> SaveChangesAsync();

}
