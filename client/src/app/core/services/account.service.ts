import { Address, User } from '../../shared/models/user';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private http = inject(HttpClient);
  currentUser = signal<User | null>(null); //signal → Kullanıcının login durumunu saklar
 
 //Login isteğini API’ye yollar
  login(values: any) {
    let params = new HttpParams();
    params = params.append('useCookies', true);
    return this.http.post<User>(this.baseUrl + 'login', values, {params})
   }
   
   register(values: any) {
    return this.http.post(this.baseUrl + 'account/register', values);
   }
   
   getUserInfo() {
    return this.http.get<User>(this.baseUrl + 'account/user-info').pipe(
      map(user => {
        this.currentUser.set(user); // kullanıcıyı sinyale kaydeder.
        return user;
      })
    )
   }
   
   logout() {
    return this.http.post(this.baseUrl + 'account/logout', {});
   }
   
   updatedAddress(address: Address) {
    return this.http.post(this.baseUrl + 'account/address', address);
   }
   
   getAuthState() {
    return this.http.get<{isAuthenticated: boolean}>(this.baseUrl + 'account/auth-status');
   }
}