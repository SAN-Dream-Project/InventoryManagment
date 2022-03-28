import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SaleInput } from '../models/Sale';

@Injectable({
  providedIn: 'root'
})
export class SaleService {
  URL_TO_GET_SALE_DETAILS: string = "https://localhost:5001/api/v1/SaleDetail/GetAllSaleDetail";
  URL_TO_GET_ADD_SALE: string = "https://localhost:5001/api/SaleDetail/AddSaleDetail";
  URL_TO_GET_DELETE_SALE: string = "https://localhost:5001/api/SaleDetail/DeleteSaleDetail";
  bearerToken:any = '';

  constructor(private httpClient: HttpClient) {
    if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
      this.bearerToken = sessionStorage.getItem('bearerToken');
    }
  }

  GetAllSaleDetails(): Observable<any> {
    return this.httpClient.get<any>(this.URL_TO_GET_SALE_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
  createSaleDetail(userObj: SaleInput) {
    return this.httpClient.post<any>(this.URL_TO_GET_ADD_SALE, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
  deleteSale(id: string): Observable<any> {
    return this.httpClient.delete<any>(this.URL_TO_GET_DELETE_SALE+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
}
