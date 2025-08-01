import { Component, inject } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { MatButton } from '@angular/material/button';

@Component({
  selector: 'app-test-error',
  imports: [
    MatButton
  ],
  templateUrl: './test-error.component.html',
  styleUrl: './test-error.component.scss'
})

//hata türlerini bilerek tetikleyip errorInterceptor ve
// SnackbarService’in doğru çalışıp çalışmadığını test etmek için kullanılıyor.

//Bu bileşen, farklı hata kodlarını tetiklemek için butonlar içerir.
//Hatalar Interceptor’a gider.
//Interceptor → Snackbar mesajı veya yönlendirme yapar.
export class TestErrorComponent {
  private http = inject(HttpClient);
  baseUrl = 'https://localhost:5001/api/';
  validationErrors?: string[];

  get404Error() {
    this.http.get(this.baseUrl + 'buggy/notfound').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  get400Error() {
    this.http.get(this.baseUrl + 'buggy/badrequest').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/internalerror').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  get401Error() {
    this.http.get(this.baseUrl + 'buggy/unauthorized').subscribe({
      next: response => console.log(response),
      error: error => console.log(error)
    });
  }

  get400ValidationError() {
    this.http.post(this.baseUrl + 'buggy/validationerror', {}).subscribe({
      next: response => console.log(response),
      error: error => this.validationErrors = error
    });
  }
}
//API’ye bilerek yanlış istekler gönderir.

//404, 400, 500, 401 gibi hataları tetikler.

