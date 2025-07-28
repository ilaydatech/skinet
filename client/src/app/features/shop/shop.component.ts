import { Component, OnInit, inject } from '@angular/core';
import { MatListOption, MatSelectionList, MatSelectionListChange } from '@angular/material/list';
import {MatMenu, MatMenuTrigger} from '@angular/material/menu';
import {MatPaginator, PageEvent} from '@angular/material/paginator';

import { FiltersDialogComponent } from './filters-dialog/filters-dialog.component';
import { FormsModule } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIcon } from '@angular/material/icon';
import { Pagination } from '../../shared/models/pagination';
import { Product } from '../../shared/models/product';
import { ProductItemComponent } from "./product-item/product-item.component";
import { ShopParams } from '../../shared/models/shopParams';
import { ShopService } from '../../core/services/shop.service';

@Component({
  selector: 'app-shop',
  standalone:true,
  imports: [
    ProductItemComponent,
    MatButton,
    MatIcon,
    MatMenu,
    MatSelectionList,
    MatListOption,
    MatMenuTrigger,
    MatPaginator,
    FormsModule
],
  templateUrl: './shop.component.html',
  styleUrl: './shop.component.scss'
})

//ShopComponent sınıfı, Angular'ın OnInit yaşam döngüsünü kullanacağını belirtir.

export class ShopComponent implements OnInit{
  
  private shopService = inject(ShopService);
  private dialogService = inject(MatDialog);
  products?: Pagination<Product>;
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low-High', value: 'priceAsc'},
    {name: 'Price: High-Low', value: 'priceDesc'}
  ]
  
shopParams = new ShopParams();
pageSizeOptions = [5, 10, 15, 20]
  
  ngOnInit(): void {
    this.initializeShop();   
  }
  initializeShop() {
    this.shopService.getBrands();
    this.shopService.getTypes();
    this.getProducts();
  }
  
  getProducts() {
      this.shopService.getProducts(this.shopParams).subscribe({
      next: response => this.products = response,
      error: error => console.error(error)
    }) 
  }
  
  onSearchChange() {
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }
  
  handlePageEvent(event: PageEvent) {
    this.shopParams.pageNumber = event.pageIndex + 1;
    this.shopParams.pageSize = event.pageSize;
    this.getProducts();
  }
  
  onSortChange(event: MatSelectionListChange) {
     const selectedOption = event.options[0];
     if(selectedOption) {
      this.shopParams.sort = selectedOption.value;
      this.shopParams.pageNumber = 1;
      this.getProducts();
     }
  }
  openFiltersDialog() {
    //filtrele butonunua tıkladığında FiltersDialogComponent açılıyor.
    //selectedBrands ve selectedTypes dizileri filters-dialog.component'e veri olarak aktarılır.
    const dialogRef = this.dialogService.open(FiltersDialogComponent, {
      minWidth: '500px',
      data: {
        selectedBrands: this.shopParams.brands,
        selectedTypes: this.shopParams.types
      }
    });
    //2. ShopComponent verileri alır:
    
    dialogRef.afterClosed().subscribe({
      next: result => {   
        this.shopParams.brands = result.selectedBrands;
        this.shopParams.types = result.selectedTypes;
        this.shopParams.pageNumber = 1;
        this.getProducts();
      }
    })
  }
}
//🟦 1	Filters butonuna basınca dialog açılır
//🟪 2	Dialog içinde kullanıcı seçim yapar
//🟨 3	Apply Filters ile bu veriler dışarı aktarılır
//🟥 4	afterClosed() ile bu veriler yakalanır ve konsola yazılır

//Kullanıcı arama yaptığında:
//🟦 1. Kullanıcı inputa bir şey yazar (ör. “nike”).
//🟪 2. [(ngModel)] ile bu değer shopParams.search içine otomatik kaydedilir.
//🟨 3. Form submit olunca onSearchChange() çağrılır → sayfa 1 yapılır → getProducts() çalışır.
//🟥 4. getProducts() → shopService üzerinden API çağrısı yapar, params.append('search', shopParams.search) ile arama kelimesi eklenir.
//🟦 5. Backend filtrelenmiş ürünleri döner, UI’da gösterilir.
