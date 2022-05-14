import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { throwError } from 'rxjs';
import { PurchaseService } from 'src/app/services/purchase.service';

@Component({
  selector: 'app-good-purchase-average-rate',
  templateUrl: './good-purchase-average-rate.component.html',
  styleUrls: ['./good-purchase-average-rate.component.less']
})
export class GoodPurchaseAverageRateComponent implements OnInit {

  users: any = [];
  error: any;

  constructor(private purchaseService: PurchaseService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.ngxSpinnerService.show();
    setTimeout(() => {
      this.getAllUsers();
    }, 1000);
  }

  getAllUsers() {
    this.ngxSpinnerService.show();
    this.purchaseService.getAllPurchases().subscribe((usersDetails) => {
      this.users = usersDetails;
    }, (error) => {
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
