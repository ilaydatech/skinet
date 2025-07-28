import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';

import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';
import { ShopParams } from '../../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';
  private http = inject(HttpClient);
  types: string[] = [];
  brands: string[] = [];
  
  //params.append('search', shopParams.search): HTTP GET isteğinin query string’ine search=... parametresini ekliyor.
  //Eğer kullanıcı "nike" yazarsa backend’e giden istek:
  //api/products?search=nike

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brands.length > 0) {
      params = params.append('brands', shopParams.brands.join(','));
    }
    
    if (shopParams.types.length > 0) {
      params = params.append('types', shopParams.types.join(','));
    }
    
    if(shopParams.sort){
     params = params.append('sort', shopParams.sort);
    }
    
    if(shopParams.search) {
      params = params.append('search', shopParams.search)
    }
    
    params = params.append('pageSize', shopParams.pageSize);
    params = params.append('pageIndex', shopParams.pageNumber)
    
    //Filtreleri al → URL’ye query string olarak ekle → sunucudan filtreli ürünleri çek.
    //Kullanıcı hangi markaları/tipleri seçtiyse, sadece onlara ait ürünler çekilmiş olur.
    return this.http.get<Pagination<Product>>(this.baseUrl + 'products', {params})
  }
  
  getBrands() {
    if (this.brands.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'products/brands').subscribe({
      next: response => this.brands = response
    })
  }
  getTypes() {
    if (this.types.length > 0) return;
    return this.http.get<string[]>(this.baseUrl + 'products/types').subscribe({
      next: response => this.types = response
    })
  }
}
