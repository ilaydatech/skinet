import { Component, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';

import { BusyService } from '../../core/services/busy.service';
import { CartService } from '../../core/services/cart.service';
import { MatBadge } from "@angular/material/badge";
import { MatButton } from "@angular/material/button";
import { MatIcon } from "@angular/material/icon";
import { MatProgressBar } from "@angular/material/progress-bar";

@Component({
  selector: 'app-header',
  imports: [
    MatIcon,
    MatButton,
    MatBadge,
    RouterLink,
    RouterLinkActive,
    MatProgressBar
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  busyService = inject(BusyService);
  cartService = inject(CartService);
}