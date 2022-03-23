import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LabourRate } from '../models/LabourRate';

@Injectable({
  providedIn: 'root'
})
export class LabourRateService {

  URL_TO_GET_LOBOURRATE_DETAILS: string = "https://localhost:5001/api/v1/LabourRate/GetAllLabourRates";
  URL_TO_CREATE_OR_UPDATE_LOBOURRATE = "https://localhost:5001/api/v1/LabourRate/AddLabourRate";
  URL_TO_DELETE_LOBOURRATE_DETAILS: string = "https://localhost:5001/api/v1/LabourRate/DeleteLabourRate";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllLabourRates(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_LOBOURRATE_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteLabourRate(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_LOBOURRATE_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createLabourRate(userObj: LabourRate) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_LOBOURRATE, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

}
