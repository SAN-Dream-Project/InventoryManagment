import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Good } from '../models/Good';

@Injectable({
  providedIn: 'root'
})
export class GoodService {
  URL_TO_GET_GOOD_DETAILS: string = "https://localhost:5001/api/v1/Good/GetAllGood";
  URL_TO_CREATE_OR_UPDATE_GOOD = "https://localhost:5001/api/v1/Good/AddGood";
  URL_TO_DELETE_GOOD_DETAILS: string = "https://localhost:5001/api/v1/Good/DeleteGood";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllGoods(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_GOOD_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteGood(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_GOOD_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createGood(userObj: Good) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_GOOD, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

}
