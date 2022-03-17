import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  URL: string = "https://localhost:5001/api/v1/User/GetAllUser";
  URL_TO_GET_BEARER_TOKEN: string = "https://localhost:5001/api/v1/TokenAuthentication/authentication";
  httpOptions: object = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: ''
    })
  };

  bearerToken:string = '';

  constructor(private httpClient: HttpClient) {  }

  getBearerToken(Obj: any): string {
    this.httpClient.post<any>(this.URL_TO_GET_BEARER_TOKEN, Obj, this.httpOptions).subscribe((tokenInformation) => {
      this.bearerToken = 'Bearer '+tokenInformation.token;
    });
    return this.bearerToken;
  }

  getAllUsers(): Observable<any> {
    return this.httpClient.get<any>(this.URL, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

}
