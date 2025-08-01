import { Cart, CartItem } from '../../shared/models/cart';
import { Injectable, computed, inject, signal } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Product } from '../../shared/models/product';
import { environment } from '../../../environments/environment';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  cart = signal<Cart | null>(null); //Signal sayesinde sepette bir değişiklik olursa otomatik olarak UI güncellenir
  itemCount = computed(() => {
  return this.cart()?.items.reduce((sum, item) => sum + item.quantity, 0) 
  //itemCount, sepet signal’inde değişiklik olunca otomatik olarak toplam ürün sayısını hesaplayan bir computed property’dir.
})
  //cartComponent içinde cart'ı çağıracağız. cart() burada signal’in o anki değerini alıyor.
  //cart = signal<Cart | null>(null)
  //KULLANICI ÜRÜN EKLER → addItemToCart()
  //Sepet yoksa → createCart() çalışır  
  //Sepet varsa → item eklenir/güncellenir  
  //setCart(cart) → cart.set(yeniCart)
  //Signal değeri değişir

  totals = computed(() => {
    const cart = this.cart();
    if(!cart) return null;
    const subtotal = cart.items.reduce((sum, item) => sum + item.price * item.quantity, 0)
    const shipping = 0;
    const discount = 0;
    return {
      subtotal,
      shipping,
      discount,
      total: subtotal + shipping -discount
    }
  })
  
  getCart(id: string) {
    return this.http.get<Cart>(this.baseUrl + 'cart?id=' + id).pipe(
      map(cart => {
        this.cart.set(cart); // Gelen veriyi signal’e yaz
        return cart;         // Aynı veriyi dışarıya geri döndür
      })
    )
  }
  //map() ile gelen veriyi hem this.cart.set() ile signal’e yazıyor hem de return ediyor.
  //Fonksiyon artık Observable<Cart> döndürüyor.


  
  setCart(cart: Cart) {
    return this.http.post<Cart>(this.baseUrl + 'cart', cart).subscribe({
      next: cart => this.cart.set(cart)
    })
  }
 //update cart on the redaers server

 
  addItemToCart(item: CartItem | Product, quantity = 1){
    const cart = this.cart() ?? this.createCart();
    if (this.isProduct(item)) {
    item = this.mapProductToCartItem(item);
  }
  cart.items = this.addOrUpdateItem(cart.items, item, quantity);
  this.setCart(cart);
  }
//Sepete ürün eklemek

  removeItemFromCart(productId: number, quantity = 1) {
  const cart = this.cart();
  if (!cart) return;
  const index = cart.items.findIndex(x => x.productId === productId);
  if (index !== -1) {
    if (cart.items[index].quantity > quantity) {
      cart.items[index].quantity -= quantity;
    } else {
      cart.items.splice(index, 1);
    }
    if (cart.items.length === 0) {
      this.deleteCart();
    } else {
      this.setCart(cart)
    }
  }
}
deleteCart() {
  this.http.delete(this.baseUrl + 'cart?id=' + this.cart()?.id).subscribe({
    next: () => {
      localStorage.removeItem('cart_id');
      this.cart.set(null);
    }
  })
}
  
  private addOrUpdateItem(items: CartItem[], item: CartItem, quantity: number): CartItem[] {
    const index = items.findIndex(x => x.productId === item.productId);
    if (index === -1){
      item.quantity = quantity;
      items.push(item);
    } else {
      items[index].quantity += quantity
    }
    return items;
  }
  //Ürün ekleme/güncelleme mantığı

  
  private mapProductToCartItem(item: Product): CartItem {
    return {
      productId: item.id,
      productName: item.name,
      price: item.price, 
      quantity: 0,
      pictureUrl: item.pictureUrl,
      brand: item.brand,
      type: item.type
    }
  }
  // Product → CartItem dönüşümü 

  private isProduct(item: CartItem | Product): item is Product {
     return(item as Product).id !== undefined;
  }
//Tip kontrolü (Product mı CartItem mı?)

  private createCart(): Cart {
    const cart = new Cart();
    localStorage.setItem('cart_id', cart.id);
    return cart;
}
//Yeni sepet oluşturmak
}

//Kullanıcı ürün ekler.
//Sepet yoksa createCart() ile oluşturulur.
//Product ise CartItem’a çevrilir.
//Ürün sepete eklenir veya miktarı artırılır.
//Güncel sepet setCart() ile backend’e gönderilir.
//Backend’ten dönen sepet UI’da görünür.

