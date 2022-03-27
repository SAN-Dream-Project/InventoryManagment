import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  URL_TO_GET_PURCHASE_DETAILS: string = "https://localhost:5001/api/Purchase/GetAllPurchase";
  bearerToken:any = '';

  constructor(private httpClient: HttpClient) {
    if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
      this.bearerToken = sessionStorage.getItem('bearerToken');
    }
  }

  getAllPurchases(): Observable<any> {
    return this.httpClient.get<any>(this.URL_TO_GET_PURCHASE_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

}
