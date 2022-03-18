import { Injectable } from '@angular/core';
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private router: Router) { }

  loginChecker(txtUsername: string, txtPassword: string): boolean {
    if(txtUsername === 'AshutoshDKedar' && txtPassword === 'A.D.K') {
      this.router.navigate(['/home']);
      return true;
    } else {
      return false;
    }
  }

}
