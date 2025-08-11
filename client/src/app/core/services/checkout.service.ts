import { Injectable, inject } from '@angular/core';
import { map, of } from 'rxjs';

import { DeliveryMethod } from '../../shared/models/deliveryMethod';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  deliveryMethods: DeliveryMethod[] = [];

  getDeliveryMethods() {
    if (this.deliveryMethods.length > 0) return of(this.deliveryMethods);
    return this.http.get<DeliveryMethod[]>(this.baseUrl + 'payments/delivery-methods').pipe(
      map(dms => {
        this.deliveryMethods = dms.sort((a, b) => b.price - a.price);
        return dms;
      })
    );
  }
}