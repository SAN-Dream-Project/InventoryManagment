import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Supplier } from '../models/suppiler';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  URL_TO_GET_SUPPLIER_DETAILS: string = "https://localhost:5001/api/v1/GoodSupplier/GetAllGoodSupplier";
  URL_TO_CREATE_OR_UPDATE_SUPPLIER = "https://localhost:5001/api/v1/GoodSupplier/AddGoodSupplier";
  URL_TO_DELETE_SUPPLIER_DETAILS: string = "https://localhost:5001/api/v1/GoodSupplier/DeleteGoodSupplier";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllSuppilers(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_SUPPLIER_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteSuppilers(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_SUPPLIER_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createSuppilers(userObj: Supplier) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_SUPPLIER, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

}
