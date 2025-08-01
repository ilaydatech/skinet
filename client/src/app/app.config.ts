import { APP_INITIALIZER, ApplicationConfig, inject, provideAppInitializer, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

import { InitService } from './core/services/init.service';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { errorInterceptor } from './core/interceptors/error-interceptor';
import { lastValueFrom } from 'rxjs';
import { loadingInterceptor } from './core/interceptors/loading-interceptor';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';

//Angular uygulaması açılırken, hangi özelliklerin yükleneceğini ve nasıl davranacağını burada tanımlıyoruz.
export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(withInterceptors([errorInterceptor, loadingInterceptor])),
    
    provideAppInitializer(async () => {
      const initService = inject(InitService);
      return lastValueFrom(initService.init()).finally(() => {
        const splash = document.getElementById('initial-splash');
        if (splash) {
          splash.remove();
        }
      });
    }),

    {
      provide: MAT_DIALOG_DEFAULT_OPTIONS,
      useValue: { autoFocus: 'dialog', restoreFocus: true }
    }
  ]
};
//Hataları dinle → provideBrowserGlobalErrorListeners() ile uygulama boyunca oluşacak hataları dinliyor.

//Performansı iyileştir → provideZoneChangeDetection ile gereksiz ekran yenilemeleri azaltılıyor.

//Yönlendirmeleri ayarla → provideRouter(routes) ile sayfalar arası geçiş ayarları yükleniyor.

//API çağrılarını özelleştir → provideHttpClient(withInterceptors([errorInterceptor, loadingInterceptor])) ile:

//errorInterceptor → API hatalarını yakalayacak.

//loadingInterceptor → API isteği yapılırken yükleniyor göstergesini çalıştıracak.