import {Component, OnInit, ViewChild} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import {Purchase} from "../../models/Purchase";
import {UserService} from "../../services/user.service";
import {NgxSpinnerService} from "ngx-spinner";
import {ToastrService} from "ngx-toastr";
import {AbstractControl, FormBuilder, FormGroup, Validators} from "@angular/forms";
import {CustomValidator} from "../demos/data-table/custom-validator";
import {PurchaseService} from "../../services/purchase.service";

@Component({
  selector: 'app-purchase-section',
  templateUrl: './purchase-section.component.html',
  styleUrls: ['./purchase-section.component.less']
})
export class PurchaseSectionComponent implements OnInit {

  displayedColumns = ['goodName', 'goodSupplierName', 'grossGoodQuantity', 'goodRate', 'kadataQuantity', 'kadtaTotal', 'netGoodQuantity', 'labourRate', 'totalLabourCosting', 'totalAmout', 'action'];
  dataSource: MatTableDataSource<Purchase>;
  showModal: boolean = false;
  users: any = [];
  purchases:any=[];
  purchaseForm: FormGroup;
  formSubmitted: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  purchase: Purchase = {
    id: '',
    goodName: '',
    goodSupplierName: '',
    grossGoodQuantity: '',
    goodRate: '',
    kadataQuantity: '',
    kadtaTotal: '',
    netGoodQuantity: '',
    labourRate: '',
    totalLabourCosting: '',
    totalAmout: '',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private purchaseService: PurchaseService, private ngxSpinnerService: NgxSpinnerService, private toastrService: ToastrService, private formBuilder: FormBuilder) {
    this.paginator = this.users;
    this.sort = this.users;
    this.dataSource = new MatTableDataSource(this.users);
    this.purchaseForm = new FormGroup({});
    setTimeout(() => {
      this.purchaseService.getAllPurchases().subscribe((purchases) => {
        console.table(purchases);
        this.purchases = purchases;
        this.dataSource = new MatTableDataSource(this.purchases);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000);
  }

  ngOnInit(): void {
    this.validateForm();
    this.ngxSpinnerService.show();
    setTimeout(() => {
      this.ngxSpinnerService.hide();
    }, 1000);
  }

  validateForm() {
    this.purchaseForm = this.formBuilder.group({
      goodName: ['', [Validators.required]],
      goodSupplierName: ['', [Validators.required]],
      grossGoodQuantity: ['', [Validators.required]],
      goodRate: ['', [Validators.required]],
      kadataQuantity: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern("^[0-9]+\\.[0-9]{1,2}$")]],
      kadtaTotal: ['', [Validators.required]],
      netGoodQuantity: ['', [Validators.required]],
      labourRate: ['', [Validators.required]],
      totalLabourCosting: ['', [Validators.required]],
      totalAmout: ['', [Validators.required]]
    });
  }

  get formControl(): { [key: string]: AbstractControl } {
    return this.purchaseForm.controls
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: KeyboardEvent) {
    let filterValue = (event.target as HTMLInputElement).value;
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource !== undefined ? this.dataSource.filter = filterValue : undefined;
  }

  openModal(type: any, purchaseObj: any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.purchase = {} as Purchase;
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.purchase = purchaseObj;
    }
  }

  closeModal() {
    this.showModal = false;
  }

  submitForm(action: string, userObj: Purchase): void {
    this.formSubmitted = true;
    if (this.purchaseForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(userObj);
    }
    if (action === 'Update') {
      this.updateRecord(userObj);
    }
  }

  appendZeros() {
    /*let currentValue = this.user.primaryMobNo;
    let regEx: any = "^[0-9]+\\.[0-9]{1,2}$";
    currentValue.indexOf('.') !== -1 && regEx.test(currentValue) ? this.user.primaryMobNo = currentValue : this.user.primaryMobNo = currentValue + '.00';*/
  }

  createRecord(purchaseObj: Purchase) {
    /*purchaseObj.gender = parseInt(purchaseObj.gender);
    purchaseObj.status = true;
    this.formSubmitted = true;
    if (this.purchaseForm.valid) {
      this.purchaseService.createPurchase(purchaseObj).subscribe(() => {
        this.toastrService.success("Record Created...!");
        setTimeout(() => {
          location.reload();
        }, 1000);
        this.showModal = false;
      });
    }*/
  }

  updateRecord(purchaseObj: Purchase) {
    /*this.purchaseService.createPurchase(purchaseObj).subscribe(() => {
      this.toastrService.info("Record Updated...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
      this.showModal = false;
    });*/
  }

  deleteRecord(id: string): void {
    /*var result = confirm("Are you sure you want to delete ?");
    if (result) {
      this.purchaseService.deletePurchase(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }*/
  }

}
