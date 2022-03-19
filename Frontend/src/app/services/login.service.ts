import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  URL_TO_GET_BEARER_TOKEN: string = "https://localhost:5001/api/v1/TokenAuthentication/authentication";
  constructor(private httpClient: HttpClient, private router: Router) { }
  httpOptions: object = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: ''
    })
  };
  userCredentials:object = {
    userName: "nitingodase",
    password: "123qwe"
  };

  getBearerToken(Obj: any): void {
    this.httpClient.post<any>(this.URL_TO_GET_BEARER_TOKEN, Obj, this.httpOptions).subscribe((tokenInformation) => {
      sessionStorage.setItem('bearerToken', 'Bearer '+tokenInformation.token);
    });
  }

  loginChecker(txtUsername: string, txtPassword: string): boolean {
    if(txtUsername === 'AshutoshDKedar' && txtPassword === 'A.D.K') {
      this.getBearerToken(this.userCredentials);
      this.router.navigate(['/home']);
      return true;
    } else {
      return false;
    }
  }

}
