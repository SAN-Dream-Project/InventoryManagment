import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BharadaSale, BharadaSaleInput } from '../models/BharadaSale';

@Injectable({
  providedIn: 'root'
})
export class BharadaSaleService {
  URL_TO_GET_BHARADA_SALE_DETAILS: string = "https://localhost:5001/api/v1/BharadaSaleDetail/GetAllBharadaSaleDetail";
  URL_TO_CREATE_OR_UPDATE_BHARADA_SALE = "https://localhost:5001/api/v1/BharadaSaleDetail/AddBharadaSaleDetail";
  URL_TO_DELETE_BHARADA_SALE_DETAILS: string = "https://localhost:5001/api/v1/BharadaSaleDetail/DeleteBharadaSaleDetail";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllBharadaSales(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_BHARADA_SALE_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteBharadaSale(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_BHARADA_SALE_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createBharadaSale(userObj: BharadaSaleInput) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_BHARADA_SALE, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}
}
