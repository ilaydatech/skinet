import { Component, inject, input } from '@angular/core';

import { CartItem } from '../../../shared/models/cart';
import { CartService } from '../../../core/services/cart.service';
import { CurrencyPipe } from '@angular/common';
import { MatButton } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-cart-item',
  imports: [
    RouterLink,
    MatButton,
    MatIcon,
    CurrencyPipe
  ],
  templateUrl: './cart-item.component.html',
  styleUrl: './cart-item.component.scss'
})
export class CartItemComponent {
  item = input.required<CartItem>();
  //Bu satır, CartComponent’ten gelen item bilgisini alır.
  cartService = inject(CartService);

  incrementQuantity() {
    this.cartService.addItemToCart(this.item());
  }
  decrementQuantity() {
    this.cartService.removeItemFromCart(this.item().productId);
  }
  removeItemFromart() {
    this.cartService.removeItemFromCart(this.item().productId, this.item().quantity);
  }
}
