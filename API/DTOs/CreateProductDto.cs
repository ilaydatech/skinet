using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

//Frontend'den gelen ürün oluşturma verisinin doğrulanması için kullanılan model.
// Ürün oluşturmak için kullanılan veri modeli (DTO = Data Transfer Object)

public class CreateProductDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Required]
    public string PictureUrl { get; set; } = string.Empty;

    [Required]
    public string Type { get; set; } = string.Empty;

    [Required]
    public string Brand { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Quantity in stock must be at least 1")]
    public int QuantityInStock { get; set; }
}