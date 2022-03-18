import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor() { }

  loginChecker(txtUsername:string, txtPassword: string): boolean {
    if(txtPassword === 'admin' && txtPassword === 'admin') {
      return true;
    } else {
      return false;
    }
  }

}
