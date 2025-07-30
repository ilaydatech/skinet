import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BusyService {
  loading = false;
  busyRequestCount = 0;

  busy() {
    this.busyRequestCount++;
    this.loading = true;
  }
  //Her API isteği başladığında busyRequestCount bir artırılır.
  //loading true olur → Loading gösterilir.


  idle() {
    this.busyRequestCount--;
    if (this.busyRequestCount <= 0) {
      this.busyRequestCount = 0;
      this.loading = false;
    }
  }
  //tüm istekler bitmişse loading kapatılır
}

//errorInterceptor → API hatasında SnackbarService.error() çağırıyor.

//loadingInterceptor → Sadece yüklenme durumunu yönetiyor.

//BusyService → Loading durumunu tutuyor.