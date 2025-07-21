using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
//Veritabanındaki ürünleri sayfa sayfa çek
// toplam kaç ürün var onu da söyle, ve her şeyi JSON olarak döndür.”
public class BaseApiController : ControllerBase
{
    protected async Task<ActionResult> CreatePagedResult<T>(IGenericRepository<T> repo,
        ISpecification<T> spec, int pageIndex, int pageSize) where T : BaseEntity
    {
        var items = await repo.ListAsync(spec);  // O sayfaya ait ürünleri al
        var count = await repo.CountAsync(spec); // Toplam ürün sayısı

        var pagination = new Pagination<T>(pageIndex, pageSize, count, items);

        return Ok(pagination);
    }
}
// using System;
// using Core.Entities;
// using Core.Interfaces;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.CodeAnalysis;

// namespace API.Controllers;

// [ApiController]
// [Route("api/[controller]")]
// public class BaseApiController : ControllerBase
// {
//     protected async Task Task<IActionResult> CreatePagedResult<T>(IGenericRepository<T> repo,
//     ISpecification<T> spec, int pageIndex, intpageSize) where T : BaseEntity
//     {
//         var items = await repo.ListAsync(spec);
//         var count = await repo.CountAsync(spec);

//         var pagination = new Pagination<T>(specParams.PageIndex,
//         specParams.PageSize, count, products);
//    }
// }
