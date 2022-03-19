import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { throwError} from "rxjs";
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { UserService } from "../../services/user.service";

@Component({
  selector: 'app-user-section',
  templateUrl: './user-section.component.html',
  styleUrls: ['./user-section.component.less']
})
export class UserSectionComponent implements OnInit {

  users: any = [];
  error: any;

  constructor(private HttpClient: HttpClient, private userService:UserService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.ngxSpinnerService.show();
    setTimeout(() => {
      this.getAllUsers();
    }, 1000);
  }

  getAllUsers() {
    this.ngxSpinnerService.show();
    this.userService.getAllUsers().subscribe((usersDetails) => {
      this.users = usersDetails;
    }, (error) => {
      console.log(error);
      this.error = this.handleError(error);
    });
    setTimeout(() => {
      this.ngxSpinnerService.hide();
    }, 500);
  }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      return 'An error occurred:'+ error.error;
    } else if (error.status === 401){
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      return `You are unauthorized :`+ error.error;
    }
    else {
      // Return an observable with a user-facing error message.
      return throwError(() => new Error('Something bad happened; please try again later.'));
    }
  }

}
