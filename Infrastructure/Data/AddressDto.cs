using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

//AddressDto istemciden (Postman, Angular frontend vs.) gelen veya istemciye giden adres bilgisini taşımak için kullanılır.
//Veritabanı modeli (Address entity) ile doğrudan dışarıya açılmak istenmez, bunun yerine DTO kullanılır.
public class AddressDto
{
    [Required] public string Line1 { get; set; } = string.Empty;
    public string? Line2 { get; set; }
    [Required] public string City { get; set; } = string.Empty;
    [Required] public string State { get; set; } = string.Empty;
    [Required] public string PostalCode { get; set; } = string.Empty;
    [Required] public string Country { get; set; } = string.Empty;
}
//{
//  "line1": "123 Main Street",
//  "line2": "Apt 4B",
//  "city": "New York",
//}
//Bu JSON AddressDto olarak karşılanır.
//Controller içinde Address entity’e dönüştürülür.
//Sonra veritabanına kaydedilir.

//📌 Backend → Frontend
//Kullanıcının adresi DB’den çekilir.
//AddressDto formatında frontend’e geri döner.