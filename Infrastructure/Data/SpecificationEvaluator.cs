using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data;
//spec (yani ISpecification<T> türünde bir nesne) içindeki Criteria’yı alır ve sorguya (IQueryable<T>) uygular.
public class SpecificationEvaluator<T> where T : BaseEntity
{
    public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); // Eğer filtre varsa uygula
        }
        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy); // Artan sıralama uygula
        }
        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }
        if (spec.IsDistinct)
        {
            query = query.Distinct();
        }
        if (spec.IsPagingEnabled)
        {
            // Sayfalama aktifse: belirtilen kadar kaydı atla ve sonra al
            query = query.Skip(spec.Skip).Take(spec.Take);
        }
        return query; // Sonuç olarak tüm filtre, sıralama ve sayfalama uygulanmış hale gelir
        
    }

    public static IQueryable<TResult> GetQuery<TSpec, TResult>(IQueryable<T> query,
     ISpecification<T, TResult> spec)
    {
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria); //x => x.Brand == brand
        }
        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }
        if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }

        var selectQuery = query as IQueryable<TResult>;

        if (spec.Select != null)
        {
            selectQuery = query.Select(spec.Select);
        }

        if (spec.IsDistinct)
        {
            selectQuery = selectQuery?.Distinct();
        }

        if (spec.IsPagingEnabled)
        {
            selectQuery = selectQuery?.Skip(spec.Skip).Take(spec.Take);
        }
        return selectQuery ?? query.Cast<TResult>();
    }

}
