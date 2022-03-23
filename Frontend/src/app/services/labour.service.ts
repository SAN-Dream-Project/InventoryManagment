import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Labour } from '../models/Labour';

@Injectable({
  providedIn: 'root'
})
export class LabourService {
  URL_TO_GET_LABOUR_DETAILS: string = "https://localhost:5001/api/v1/Labour/GetAllLabours";
  URL_TO_CREATE_OR_UPDATE_LABOUR = "https://localhost:5001/api/v1/Labour/AddLabour";
  URL_TO_DELETE_LABOUR_DETAILS: string = "https://localhost:5001/api/v1/Labour/DeleteLabour";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllLabours(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_LABOUR_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteLabour(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_LABOUR_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createLabour(userObj: Labour) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_LABOUR, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

}
