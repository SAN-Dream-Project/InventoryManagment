import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {Observable} from "rxjs";
import {User} from "../models/User";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  URL_TO_GET_USER_DETAILS: string = "https://localhost:5001/api/v1/User/GetAllUser";
  URL_TO_CREATE_OR_UPDATE_USER = "https://localhost:5001/api/v1/User/AddUser";
  URL_TO_DELETE_USER_DETAILS: string = "https://localhost:5001/api/v1/User/DeleteUser";
  URL_TO_CREATE_OR_UPDATE_GOODLIST = "https://localhost:5001/api/v1/Good/GetGoodList";
  bearerToken:any = '';

  constructor(private httpClient: HttpClient) {
    if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
      this.bearerToken = sessionStorage.getItem('bearerToken');
    }
  }

  getAllUsers(): Observable<any> {
    return this.httpClient.get<any>(this.URL_TO_GET_USER_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

  deleteUser(id: string): Observable<any> {
    return this.httpClient.delete<any>(this.URL_TO_DELETE_USER_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

  createUser(userObj: User) {
    return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_USER, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

  getGoodList():Observable<any>{
    return this.httpClient.get<any>(this.URL_TO_CREATE_OR_UPDATE_GOODLIST, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
  }

}
