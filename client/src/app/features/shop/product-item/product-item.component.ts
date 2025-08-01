import { Component, Input, inject } from '@angular/core';
import { MatCard, MatCardActions, MatCardContent } from "@angular/material/card";

import { CartService } from '../../../core/services/cart.service';
import { CurrencyPipe } from '@angular/common';
import { MatButton } from '@angular/material/button';
import {MatIcon} from '@angular/material/icon';
import { Product } from '../../../shared/models/product';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-product-item',
  imports: [
    MatCard,
    MatCardContent,
    CurrencyPipe,
    MatCardActions,
    MatButton,
    MatIcon,
    RouterLink
],
  templateUrl: './product-item.component.html',
  styleUrl: './product-item.component.scss'
})
//@Input()	Bu property dışarıdan veri alabilir demektir.
export class ProductItemComponent {
@Input() product?: Product;
cartService = inject(CartService);

}
