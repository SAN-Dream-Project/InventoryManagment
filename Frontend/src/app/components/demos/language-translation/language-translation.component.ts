import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";

@Component({
  selector: 'app-language-translation',
  templateUrl: './language-translation.component.html',
  styleUrls: ['./language-translation.component.less']
})
export class LanguageTranslationComponent implements OnInit {

  language: any;
  users: any = [];
  bearerToken:any = '';

  constructor(private httpClient: HttpClient) {
    if(sessionStorage.getItem('bearerToken') !='' || sessionStorage.getItem('bearerToken') !== null || sessionStorage.getItem('bearerToken') !== undefined) {
      this.bearerToken = sessionStorage.getItem('bearerToken');
    }
  }

  ngOnInit(): void {
    this.language = localStorage.getItem("selectedLanguage") || 'en';
    setTimeout(()=> {
      this.httpClient.get<any>("https://localhost:5001/api/v1/User/GetAllUser",
        {headers:
            new HttpHeaders({
              'Authorization': this.bearerToken
            })
        }).subscribe((users)=>{
          this.users = users;
      });
    }, 1000);
  }

  selectLanguage(event: any) {
    const selectedLanguage = (event.target as HTMLInputElement).value;
    localStorage.setItem('selectedLanguage', selectedLanguage);
    window.location.reload();
  }

}
