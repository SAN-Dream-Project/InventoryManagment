import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  URL_TO_CREATE_OR_UPDATE_GOODLIST = "https://localhost:5001/api/v1/Good/GetGoodList"
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {
    if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
      this.bearerToken = sessionStorage.getItem('bearerToken');
    }
  }

  getGoodList():Observable<any>{
    return this.httpClient.get<any>(this.URL_TO_CREATE_OR_UPDATE_GOODLIST, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

}
