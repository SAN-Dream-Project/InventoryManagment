import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StockService {
  URL_TO_GET_STOCK_DETAILS: string = "https://localhost:5001/api/v1/Stock/GetAllStock";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllStocks(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_STOCK_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}
}
