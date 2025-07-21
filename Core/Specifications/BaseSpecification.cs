using System.Linq.Expressions;
using Core.Interfaces;
namespace Core.Specifications;

//ISpecification<T> arayüzünü uygular ve Criteria değerini constructor (yapıcı metod) aracılığıyla alır.

public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
{
      protected BaseSpecification() : this(null) { }
      public Expression<Func<T, bool>>? Criteria => criteria;
      public Expression<Func<T, object>>? OrderBy { get; private set; }
      public Expression<Func<T, object>>? OrderByDescending { get; private set; }

      public bool IsDistinct { get; private set; }

      public int Take { get; private set; } // Kaç adet veri alınacak

      public int Skip { get; private set; } // Kaç kayıt atlanacak (örnek: önceki sayfadakiler)

      public bool IsPagingEnabled { get; private set; } // Sayfalama açık mı?

      public IQueryable<T> ApplyCriteria(IQueryable<T> query)
      {
            //Markası Apple olan ürünleri istiyorum
            if (Criteria != null)
            {
                  query = query.Where(Criteria);
            }
            return query;
      }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
      {
            OrderBy = orderByExpression;
      }
      protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
      {
            OrderByDescending = orderByDescExpression;
      }

      protected void ApplyDistinct()
      {
            IsDistinct = true;
      }
      protected void ApplyPaging(int skip, int take)
      {
            Skip = skip; //class seviyesinde tanımlı özelliğe (property) dışarıdan gelen parametreler atanıyor.
            Take = take;
            IsPagingEnabled = true;
      }
}

public class BaseSpecification<T, TResult>(Expression<Func<T, bool>> criteria)
    : BaseSpecification<T>(criteria), ISpecification<T, TResult>
{
      protected BaseSpecification() : this(null!) { }
      public Expression<Func<T, TResult>>? Select { get; private set; }

      protected void AddSelect(Expression<Func<T, TResult>> selectExpression)
      {
            Select = selectExpression;
     }
}