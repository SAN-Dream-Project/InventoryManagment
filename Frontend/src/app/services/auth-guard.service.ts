import { Injectable } from '@angular/core'

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {
  getAuthenticationStatus(): boolean {
    return sessionStorage.getItem('isLoggedIn') == 'true' ? true : false;
  }
}
