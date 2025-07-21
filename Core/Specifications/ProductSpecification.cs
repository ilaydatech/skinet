using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecParams specParams) : base(x =>
        (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
        (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand)) &&
        (specParams.Types.Count == 0 || specParams.Types.Contains(x.Type))
    )
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex -1), specParams.PageSize);

        switch (specParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(x => x.Price);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;
        }
    }
}
// using System;
// using Core.Entities;

// namespace Core.Specifications;

// public class ProductSpecification : BaseSpecification<Product>
// {
//     //tüm markalar geçerli kabul edilir veya Brand property'si tanımlı mı
//     public ProductSpecification(ProductSpecParams specParams) : base(x =>
//        (specParams.Brands.Count == 0 || specParams.Brands.Contains(x.Brand)) &&
//        (specParams.Types.Count == 0 || specParams.Types.Contains(x.Type))
//     ) 
//     {  //specParams.PageSize = 6; specParams.PageIndex = 3; ApplyPaging(6 * (3 - 1), 6)
//        //ApplyPaging(12, 6) Skip(12).Take(6) Yani 3. sayfada gösterilecek ürünleri çek.

//         ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
//         switch (specParams.Sort)
//         {
//             case "priceAsc":
//                 AddOrderBy(x => x.Price);
//                 break;
//             case "priceDesc":
//                 AddOrderByDescending(x => x.Price);
//                 break;
//             default:
//                 AddOrderBy(x => x.Name);
//                 break;
//         }
//     }
// }
