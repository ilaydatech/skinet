using System;
using System.Linq.Expressions;

namespace Core.Interfaces;

//Markası react olan ürünleri istiyorum" → bu bir Criteria ifadesidir.
//Bu arayüzü uygulayan sınıflar, Criteria özelliğini nasıl tanımlayacaklarını belirlemek zorundadır.

// ISpecification<T>	     Sözleşme	Ne yapılacağını söyler.
// BaseSpecification<T>	     Uygulama	Nasıl yapılacağını belirtir.
// SpecificationEvaluator<T> Kullanım	Filtreyi sorguya uygular.

// ISpecification<T> → Specification pattern'ın temel sözleşmesi
// Uygulayan sınıf, filtreleme (Criteria), sıralama (OrderBy), ve gerekirse Distinct işlemlerini tanımlar
public interface ISpecification<T>
{
      Expression<Func<T, bool>>? Criteria { get; }
      Expression<Func<T, object>>? OrderBy { get; }
      Expression<Func<T, object>>? OrderByDescending { get; }
      bool IsDistinct { get; }
      int Take { get; }
      int Skip { get; }
      bool IsPagingEnabled { get; }   // Sayfalama aktif mi?
      IQueryable<T> ApplyCriteria(IQueryable<T> query); //Sorguya filtre uygulamak
}

// Bu arayüz, üsttekinin gelişmiş versiyonudur ve DTO dönüşü destekler
// ISpecification<T, TResult> → Sorgunun sonucunda sadece belirli alanlar döndürülebilir
// Örn: sadece Name ve Price alanı içeren bir ProductDto döndür
public interface ISpecification<T, TResult> : ISpecification<T>
{
      Expression<Func<T, TResult>>? Select { get; }
}