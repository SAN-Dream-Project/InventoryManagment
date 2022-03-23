import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Retailer } from '../models/Retailer';

@Injectable({
  providedIn: 'root'
})
export class RetailerService {
  URL_TO_GET_RETAILER_DETAILS: string = "https://localhost:5001/api/v1/Retailer/GetAllRetailer";
  URL_TO_CREATE_OR_UPDATE_RETAILER = "https://localhost:5001/api/v1/Retailer/AddRetailer";
  URL_TO_DELETE_RETAILER_DETAILS: string = "https://localhost:5001/api/v1/Retailer/DeleteRetailer";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllRetailers(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_RETAILER_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteRetailer(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_RETAILER_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createRetailer(userObj: Retailer) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_RETAILER, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

}
