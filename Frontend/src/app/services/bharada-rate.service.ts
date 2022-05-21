import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { BharadaRate } from '../models/BharadaRate';

@Injectable({
  providedIn: 'root'
})
export class BharadaRateService {
  URL_TO_GET_BHARADA_RATE_DETAILS: string = "https://localhost:5001/api/v1/BharadaRate/GetAllBharadaRate";
  URL_TO_CREATE_OR_UPDATE_BHARADA_RATE = "https://localhost:5001/api/v1/BharadaRate/AddBharadaRate";
  URL_TO_DELETE_BHARADA_RATE_DETAILS: string = "https://localhost:5001/api/v1/BharadaRate/DeleteBharadaRate";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllBharadaRates(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_BHARADA_RATE_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteBharadaRate(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_BHARADA_RATE_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createBharadaRate(userObj: BharadaRate) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_BHARADA_RATE, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

}
