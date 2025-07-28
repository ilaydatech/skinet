import { Component, inject } from '@angular/core';
import { MatListOption, MatSelectionList } from '@angular/material/list';

import { MatButton } from '@angular/material/button';
import { MatDivider } from '@angular/material/divider';
import { ShopService } from '../../../core/services/shop.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-filters-dialog',
  standalone: true,
  imports: [
    MatDivider,
    MatSelectionList,
    MatListOption,
    MatButton,
    FormsModule
  ],
  templateUrl: './filters-dialog.component.html',
  styleUrl: './filters-dialog.component.scss'
})
export class FiltersDialogComponent {
  shopService = inject(ShopService);
  private dialogRef = inject(MatDialogRef<FiltersDialogComponent>);
  data = inject(MAT_DIALOG_DATA);
//shop.component.ts'den -dışarıdan gelen data

  selectedBrands: string[] = this.data.selectedBrands;
  selectedTypes: string[] = this.data.selectedTypes;
//Kullanıcının filtre seçimleri bu dizilere kaydedilir.

  applyFilters() {
    this.dialogRef.close({
      selectedBrands: this.selectedBrands,
      selectedTypes: this.selectedTypes
      //1. Seçilen markalar ve tipler, dialog'u açan bileşene geri gönderilir.
    })

  }
}
