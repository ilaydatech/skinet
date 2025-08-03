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
