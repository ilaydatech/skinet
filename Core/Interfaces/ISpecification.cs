using System;
using System.Linq.Expressions;

namespace Core.Interfaces;

//Markası react olan ürünleri istiyorum" → bu bir Criteria ifadesidir.
//Bu arayüzü uygulayan sınıflar, Criteria özelliğini nasıl tanımlayacaklarını belirlemek zorundadır.

// ISpecification<T>	     Sözleşme	Ne yapılacağını söyler.
// BaseSpecification<T>	     Uygulama	Nasıl yapılacağını belirtir.
// SpecificationEvaluator<T> Kullanım	Filtreyi sorguya uygular.
public interface ISpecification<T>
{
      Expression<Func<T, bool>>? Criteria { get; }
      Expression<Func<T, object>>? OrderBy { get; }
      Expression<Func<T, object>>? OrderByDescending { get; }

      bool IsDistinct { get; }
}
public interface ISpecification<T, TResult> : ISpecification<T>
{
      Expression <Func<T, TResult>>? Select { get; }
}