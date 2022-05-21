import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Kadata } from '../models/Kadata';

@Injectable({
  providedIn: 'root'
})
export class KadataService {
  URL_TO_GET_KADATA_DETAILS: string = "https://localhost:5001/api/v1/Kadata/GetAllKadata";
  URL_TO_CREATE_OR_UPDATE_KADATA = "https://localhost:5001/api/v1/Kadata/AddKadata";
  URL_TO_DELETE_KADATA_DETAILS: string = "https://localhost:5001/api/v1/Kadata/DeleteKadata";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllKadatas(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_KADATA_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteKadata(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_KADATA_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createKadata(userObj: Kadata) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_KADATA, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

}
