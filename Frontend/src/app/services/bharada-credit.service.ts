import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BharadaCreditInput } from '../models/BharadaCredit';

@Injectable({
  providedIn: 'root'
})
export class BharadaCreditService {

  URL_TO_GET_BHARADA_CREDIT_DETAILS: string = "https://localhost:5001/api/v1/BharadaCreditDetail/GetAllBharadaCreditDetail";
  URL_TO_CREATE_OR_UPDATE_BHARADA_CREDIT = "https://localhost:5001/api/v1/BharadaCreditDetail/AddBharadaCreditDetail";
  URL_TO_DELETE_BHARADA_CREDIT_DETAILS: string = "https://localhost:5001/api/v1/BharadaCreditDetail/DeleteBharadaCreditDetail";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllBharadaCredits(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_BHARADA_CREDIT_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteBharadaCredit(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_BHARADA_CREDIT_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createBharadaCredit(userObj: BharadaCreditInput) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_BHARADA_CREDIT, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}
}
