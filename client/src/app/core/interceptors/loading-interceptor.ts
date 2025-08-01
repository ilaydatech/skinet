import { delay, finalize } from 'rxjs';

import { BusyService } from '../services/busy.service';
import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const busyService = inject(BusyService);
  
  busyService.busy();
  
  return next(req).pipe(
    delay(1000),
    finalize(() => busyService.idle())
  )
};
//API isteği devam ederken ekrana “yükleniyor” göstergesi için kullanılır--animasyon
//İstek başlarken: busyService.busy() → Loading açılır.
//İstek bittiğinde: busyService.idle() → Loading kapanır.

