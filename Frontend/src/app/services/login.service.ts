import { Injectable } from '@angular/core';
import {Router} from "@angular/router";
import {HttpClient, HttpErrorResponse, HttpHeaders} from "@angular/common/http";
import {throwError} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  URL_TO_GET_BEARER_TOKEN: string = "https://localhost:5001/api/v1/TokenAuthentication/authentication";
  constructor(private httpClient: HttpClient, private router: Router) { }
  httpOptions: any = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: ''
    })
  };
  userCredentials: any;
  error: any;

  getBearerToken(Obj: any): void {
    this.httpClient.post<any>(this.URL_TO_GET_BEARER_TOKEN, Obj, this.httpOptions).subscribe((tokenInformation: any) => {
      sessionStorage.setItem('bearerToken', 'Bearer '+tokenInformation.token);
      sessionStorage.setItem('isLoggedIn', 'true');
      this.router.navigate(['/home']);
    }, (error) => {
      sessionStorage.setItem('errorMessage', this.handleError(error).toString());
    });
  }

  loginChecker(txtUsername: string, txtPassword: string): boolean {
    this.userCredentials = {
      userName: txtUsername,
      password: txtPassword
    }
    this.getBearerToken(this.userCredentials);
    return true;
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      return 'An error occurred:'+ error.error;
    } else if (error.status === 401){
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      return 'You are unauthorized.';
    }
    else {
      // Return an observable with a user-facing error message.
      return throwError(() => new Error('Something bad happened; please try again later.'));
    }
  }

}
