import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router"
import { LoginService } from "../../services/login.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.less']
})
export class LoginComponent implements OnInit {

  constructor(private loginService:LoginService, private router:Router) { }

  ngOnInit(): void {
  }

  loginChecker(txtUsername:string, txtPassword:string): void {
    this.loginService.loginChecker(txtUsername, txtPassword) ? this.router.navigate(['/home']) : this.router.navigate(['/']);
  }

}
