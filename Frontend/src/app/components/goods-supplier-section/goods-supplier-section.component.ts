import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Supplier } from 'src/app/models/suppiler';
import { SupplierService } from 'src/app/services/supplier.service';

@Component({
  selector: 'app-goods-supplier-section',
  templateUrl: './goods-supplier-section.component.html',
  styleUrls: ['./goods-supplier-section.component.less']
})
export class GoodsSupplierSectionComponent implements OnInit {
  suppliers:any = [];
  supplierForm: FormGroup;
  displayedColumns = ['firstName', 'middleName', 'lastName','mobileNo', 'emailId', 'address', 'action'];
  dataSource: MatTableDataSource<Supplier>;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  formSubmitted: boolean = false;
  supplier: Supplier = {
    id: '',
    firstName: '',
    middleName: '',
    lastName: '',
    mobileNo: '',
    emailID: '',
    address: '',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: '',
    gender: '',
  };

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;
  constructor(private supplierService: SupplierService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService,private formBuilder: FormBuilder) {
    this.paginator = this.suppliers;
    this.sort = this.suppliers;
    this.dataSource = new MatTableDataSource(this.suppliers);
    this.supplierForm = new FormGroup({});
    /*for (let i = 1; i <= 100; i++) { this.users.push(createNewUser(i)); }*/
    // Assign the data to the data source for the table to render
    setTimeout(() => {
      this.supplierService.getAllSuppilers().subscribe((suppliers) => {
        this.suppliers = suppliers;
        this.dataSource = new MatTableDataSource(this.suppliers);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000);
  }

  ngOnInit(): void { this.ngxSpinnerService.show();
    setTimeout(()=> {
      this.ngxSpinnerService.hide();
    }, 1000);
    this.supplierForm = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      middleName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      mobileNo: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern("^[0-9]*$")]],
      emailID: ['', [Validators.email]],
      address: ['', [Validators.maxLength(100)]],
      gender: ['', [Validators.required]]
    });
  }
  get formControl(): { [key: string]: AbstractControl } {
    return this.supplierForm.controls
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }applyFilter(event: KeyboardEvent) {
    let filterValue = (event.target as HTMLInputElement).value;
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource !== undefined ? this.dataSource.filter = filterValue : undefined;
  }

  openModal(type:any, supplierbj:any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.supplier = {} as Supplier;
      this.supplier.gender = '';
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.supplier= supplierbj;
    }
  }

  closeModal() {
    this.showModal = false;
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.supplierService.deleteSuppilers(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }

  submitForm(action: string, employeeObj: Supplier): void {
    this.formSubmitted = true;
    if (this.supplierForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(employeeObj);
    }
    if (action === 'Update') {
      this.updateRecord(employeeObj);
    }
  }
  createRecord(supplierObj: Supplier) {
    supplierObj.gender = parseInt(supplierObj.gender);
    this.supplierService.createSuppilers(supplierObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

  updateRecord(supplierObj: Supplier) {
    supplierObj.gender = parseInt(supplierObj.gender);
    this.supplierService.createSuppilers(supplierObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

}
