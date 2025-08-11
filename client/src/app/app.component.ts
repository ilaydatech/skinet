import { Component, OnInit, inject } from '@angular/core';

import { HeaderComponent } from "./layout/header/header.component";
import { RouterOutlet } from '@angular/router';
import { ShopComponent } from './features/shop/shop.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent{
title = "Skinet";
}