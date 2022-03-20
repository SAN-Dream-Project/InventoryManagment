import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  URL_TO_GET_EMPLOYEE_DETAILS: string = "https://localhost:5001/api/v1/EmployeeDetail/GetAllEmployeeDetail";
  URL_TO_CREATE_OR_UPDATE_EMPLOYEE = "https://localhost:5001/api/v1/EmployeeDetail/AddEmployeeDetail";
  URL_TO_DELETE_EMPLOYEE_DETAILS: string = "https://localhost:5001/api/v1/EmployeeDetail/DeleteEmployeeDetail";
  bearerToken:any = '';
  constructor(private httpClient: HttpClient) {if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
    this.bearerToken = sessionStorage.getItem('bearerToken');
  } 
}
getAllEmployees(): Observable<any> {
  return this.httpClient.get<any>(this.URL_TO_GET_EMPLOYEE_DETAILS, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

deleteEmployee(id: string): Observable<any> {
  return this.httpClient.delete<any>(this.URL_TO_DELETE_EMPLOYEE_DETAILS+"?id="+id, {headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}

createEmployee(userObj: Employee) {
  return this.httpClient.post<any>(this.URL_TO_CREATE_OR_UPDATE_EMPLOYEE, userObj,{headers: (new HttpHeaders({'Authorization': this.bearerToken}))});
}
}
