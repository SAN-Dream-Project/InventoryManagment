import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {PurchaseInput, PurchaseReportInput} from '../models/Purchase';

@Injectable({
  providedIn: 'root'
})
export class PurchaseService {

  URL_TO_GET_PURCHASE_DETAILS: string = "https://localhost:5001/api/Purchase/GetAllPurchase";
  URL_TO_GET_ADD_PURCHASE: string = "https://localhost:5001/api/Purchase/AddPurchase";
  URL_TO_GET_DELETE_PURCHASE: string = "https://localhost:5001/api/Purchase/DeletePurchase";
  URL_TO_GET_PURCHASE_AVERAGE_RATE: string = "https://localhost:5001/api/Purchase/GetPurchaseAverageRates";
  URL_TO_GET_PURCHASE_REPORT = "https://localhost:5001/api/Purchase/GetPurchaseReportData";
  bearerToken:any = '';

  constructor(private httpClient: HttpClient) {
    if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
      this.bearerToken = sessionStorage.getItem('bearerToken');
    }
  }

  getAllPurchases(): Observable<any> {
    return this.httpClient.get<any>(this.URL_TO_GET_PURCHASE_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
  getPurchaseAverageRate(): Observable<any> {
    return this.httpClient.get<any>(this.URL_TO_GET_PURCHASE_AVERAGE_RATE, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
  createPurchase(userObj: PurchaseInput) {
    return this.httpClient.post<any>(this.URL_TO_GET_ADD_PURCHASE, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }
  deletePurchase(id: string): Observable<any> {
    return this.httpClient.delete<any>(this.URL_TO_GET_DELETE_PURCHASE+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

  //Reports
  getPurchaseReport(purchaseReportObj: PurchaseReportInput): Observable<any> {
    return this.httpClient.post<any>(this.URL_TO_GET_PURCHASE_REPORT, purchaseReportObj, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

}
