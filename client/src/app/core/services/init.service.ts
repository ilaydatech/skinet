import { Injectable, inject } from '@angular/core';
import { forkJoin, of } from 'rxjs';

import { AccountService } from './account.service';
import { CartService } from './cart.service';

@Injectable({
  providedIn: 'root'
})
export class InitService {
  private cartService = inject(CartService);
  private accountService = inject(AccountService);
  init() {
    const cardId = localStorage.getItem('cart_id');
    const cart$ = cardId ? this.cartService.getCart(cardId) : of(null);
    
    return forkJoin({
      cart: cart$,
      user: this.accountService.getUserInfo()
    })
  }
}
