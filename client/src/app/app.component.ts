import { Component, OnInit, inject } from '@angular/core';

import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Pagination } from './shared/models/pagination';
import { Product } from './shared/models/product';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  baseUrl = "https://localhost:5001/api/"
  private http = inject(HttpClient);
  title = 'skinet';
  products: Product[] = [];

  // HttpClient.get() bir Observable döndürür. Bu, ileride veri döneceği sözünü verir.


    ngOnInit(): void {
    this.http.get<Pagination<Product>>(this.baseUrl + 'products').subscribe({
      next: response => this.products = response.data,
      error: error => console.log(error),
      complete: () => console.log('complate')
    })
  }
}
