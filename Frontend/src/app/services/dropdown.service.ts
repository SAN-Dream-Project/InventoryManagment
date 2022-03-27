import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class DropdownService {

  URL_TO_CREATE_OR_UPDATE_GOODLIST = "https://localhost:5001/api/v1/Good/GetGoodList"
  URL_TO_SUPPLIER_LIST = "https://localhost:5001/api/v1/GoodSupplier/GetGoodSuppilerList"
  URL_TO_KADATA_LIST = "https://localhost:5001/api/v1/Kadata/GetKadataList"
  URL_TO_LABOURRATE_LIST = "https://localhost:5001/api/v1/LabourRate/GetLabourRateList"
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {
    if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
      this.bearerToken = sessionStorage.getItem('bearerToken');
    }
  }

  getGoodList():Observable<any>{
    return this.httpClient.get<any>(this.URL_TO_CREATE_OR_UPDATE_GOODLIST, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
  getSupplierList():Observable<any>{
    return this.httpClient.get<any>(this.URL_TO_SUPPLIER_LIST, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
  getKadataList():Observable<any>{
    return this.httpClient.get<any>(this.URL_TO_KADATA_LIST, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
  getLabourRateList():Observable<any>{
    return this.httpClient.get<any>(this.URL_TO_LABOURRATE_LIST, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
}
