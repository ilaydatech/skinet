import { Component, inject } from '@angular/core';

import { CartItemComponent } from "./cart-item/cart-item.component";
import { CartService } from '../../core/services/cart.service';
import { EmptyStateComponent } from "../../shared/components/empty-state/empty-state.component";
import { OrderSummaryComponent } from "../../shared/components/order-summary/order-summary.component";

@Component({
  selector: 'app-cart',
  imports: [CartItemComponent, OrderSummaryComponent, EmptyStateComponent],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.scss'
})
export class CartComponent {
  cartService = inject(CartService);
}
