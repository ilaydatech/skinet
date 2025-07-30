import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { NavigationExtras, Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';

import { SnackbarService } from '../services/snackbar.service';
import { inject } from '@angular/core';

//req → API isteği (hangi URL’ye ne gönderildiği)
//next → İstek gönderildikten sonra cevap alınmasını sağlar.
export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
  const snackbar = inject(SnackbarService);
//Router → Hatalarda kullanıcıyı farklı sayfaya göndermek için.
//Snackbar → Küçük mesaj kutuları (uyarılar) göstermek için.
  return next(req).pipe(
    catchError((err: HttpErrorResponse) => {
      if (err.status === 400) {
        if (err.error.errors) {
          const modalStateErrors = [];
          for (const key in err.error.errors) {
            if (err.error.errors[key]) {
              modalStateErrors.push(err.error.errors[key])
            }
          }
          throw modalStateErrors.flat();
        } else {
          snackbar.error(err.error.title || err.error)
        }
      }
      if (err.status === 401) {
        snackbar.error(err.error.title || err.error)
      }
      //401 kullanıcı giriş yapmamışsa veya yetkisi yoksa gösterlir
      
      if (err.status === 404) {
        router.navigateByUrl('/not-found');
      }
      if (err.status === 500) {
        const navigationExtras: NavigationExtras = {state: {error: err.error}};
        router.navigateByUrl('/server-error', navigationExtras);
      }
      return throwError(() => err)
    })
  )
};
//1.Her API isteğini dinler.

//2.Hata varsa status koduna bakar.

//3.Kod 400, 401, 404 veya 500 ise uygun işlem yapar:

//Mesaj gösterir (Snackbar)

//Kullanıcıyı farklı sayfaya yönlendirir

//Form hatalarını tekrar fırlatır

// 4.Hata uygulamanın diğer kısımlarına iletilir.

