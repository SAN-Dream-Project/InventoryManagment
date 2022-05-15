import { Component, OnInit } from '@angular/core';
import { LoginService } from "../../services/login.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  hasError: boolean = false;
  errorMessage: any = '';

  constructor(private loginService: LoginService) { }

  ngOnInit(): void {
  }

  loginChecker(txtUsername: string, txtPassword: string): void {
    this.loginService.loginChecker(txtUsername, txtPassword);
    setTimeout(()=> {
      sessionStorage.getItem('errorMessage') ? this.hasError = true : this.hasError = false;
      this.errorMessage = sessionStorage.getItem('errorMessage');
    }, 500);
    /*if(this.hasError) {
      setTimeout(()=>{
        this.hasError = false;
      }, 5000);
    }*/
  }

}
