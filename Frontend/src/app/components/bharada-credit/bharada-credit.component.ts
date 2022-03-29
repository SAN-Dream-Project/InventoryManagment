import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { map, Observable, startWith } from 'rxjs';
import { BharadaCredit, BharadaCreditInput } from 'src/app/models/BharadaCredit';
import { DropDown } from 'src/app/models/User';
import { BharadaCreditService } from 'src/app/services/bharada-credit.service';
import { DropdownService } from 'src/app/services/dropdown.service';

@Component({
  selector: 'app-bharada-credit',
  templateUrl: './bharada-credit.component.html',
  styleUrls: ['./bharada-credit.component.less']
})
export class BharadaCreditComponent implements OnInit {
  displayedColumns = ['retailerName', 'bharadaSaleDetail', 'paidAmount', 'createdBy', 'action'];
  dataSource: MatTableDataSource<BharadaCredit>;
  showModal: boolean = false;
  bharadaCredits: any = [];
  formSubmitted: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  }; 
  
  retailers: DropDown[] = [];
  filteredRetailer: Observable<DropDown[]> | undefined;
  retailerCtrl = new FormControl();

  bharadaSaleDetails: DropDown[] = [];
  filteredBharadaSaleDetail: Observable<DropDown[]> | undefined;
  bharadaSaleDetailCtrl = new FormControl();

  labourCharges: DropDown[] = [];
  filteredlabourCharge: Observable<DropDown[]> | undefined;
  labourChargeCtrl = new FormControl(); 

  selectedRetailer: any;
  selectedBharadaSaleDetail = null;

  bharadaCreditSale: BharadaCreditInput = {
    id: '',
    retailerID:'',
    BharadaSaleDetailID:'',
    paidAmount:'',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };
  bharadaCreditForm: FormGroup;
  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private bharadaCreditService: BharadaCreditService, private dropdownService: DropdownService, private ngxSpinnerService: NgxSpinnerService, private toastrService: ToastrService, private formBuilder: FormBuilder) {
    this.paginator = this.bharadaCredits;
    this.sort = this.bharadaCredits;
    this.dataSource = new MatTableDataSource(this.bharadaCredits);
    this.bharadaCreditForm = new FormGroup({});
    setTimeout(() => {
      this.bharadaCreditService.getAllBharadaCredits().subscribe((bharadaCredits) => {
        this.bharadaCredits = bharadaCredits;
        console.log(this.bharadaCredits);
        this.dataSource = new MatTableDataSource(this.bharadaCredits);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000); 
    this.dropdownService.getRetailerList().subscribe((retailers) => {
      this.retailers = retailers;
    });
    this.filteredRetailer = this.retailerCtrl.valueChanges
        .pipe(
          startWith(''),
          map(retailer => retailer ? this._filterRetailers(retailer) : this.retailers.slice())
        );
    this.dropdownService.getBharadaSaleDetailList().subscribe((bharadaSaleDetails) => {
        this.bharadaSaleDetails = bharadaSaleDetails;
        });
    this.filteredBharadaSaleDetail = this.bharadaSaleDetailCtrl.valueChanges
        .pipe(
            startWith(''),
          map(bharadaSale => bharadaSale ? this._filterBharadaSales(bharadaSale) : this.bharadaSaleDetails.slice())
          );
  }
  private _filterRetailers(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.retailers.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  private _filterBharadaSales(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.bharadaSaleDetails.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  SelectedBharadaSaleDetail(bharadaSale: any) {
    this.bharadaCreditSale.BharadaSaleDetailID = bharadaSale.key;
  }
  SelectedRetailer(retailer: any) {
    this.bharadaCreditSale.retailerID = retailer.key;
  }
  ngOnInit(): void {
    this.validateForm();
    this.ngxSpinnerService.show();
    setTimeout(() => {
      this.ngxSpinnerService.hide();
    }, 1000);
  }
  validateForm() {
    this.bharadaCreditForm = this.formBuilder.group({
      retailerID: ['', [Validators.required]],
      bharadaSaleDetailID: ['', [Validators.required]],
      paidAmount: ['', [Validators.required]]
    });
  }
  get formControl(): { [key: string]: AbstractControl } {
    return this.bharadaCreditForm.controls
  }
  appendZeros() {
    /*let currentValue = this.user.primaryMobNo;
    let regEx: any = "^[0-9]+\\.[0-9]{1,2}$";
    currentValue.indexOf('.') !== -1 && regEx.test(currentValue) ? this.user.primaryMobNo = currentValue : this.user.primaryMobNo = currentValue + '.00';*/
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
  openModal(type: any, bharadaSaleObj: any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.bharadaCreditSale = {} as BharadaCreditInput;
       this.selectedBharadaSaleDetail = null;
       this.selectedRetailer = null;
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.bharadaCreditSale = bharadaSaleObj;
      this.selectedBharadaSaleDetail = bharadaSaleObj.bharadaRate;
      this.bharadaCreditSale.BharadaSaleDetailID = this.bharadaSaleDetails.find(x=>x.value === bharadaSaleObj.bharadaRate)?.key;
      this.selectedRetailer = bharadaSaleObj.retailerName;
      this.bharadaCreditSale.retailerID = this.retailers.find(x=>x.value === bharadaSaleObj.retailerName)?.key;
    }
  }
  closeModal() {
    this.showModal = false;
  }
  submitForm(action: string, saleObj: BharadaCreditInput): void {
    this.formSubmitted = true;
    if (this.bharadaCreditForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(saleObj);
    }
    if (action === 'Update') {
      this.updateRecord(saleObj);
    }
  }
  createRecord(bharadaCreditObj: BharadaCreditInput) {
    this.formSubmitted = true;
    if (this.bharadaCreditForm.valid) {
      this.bharadaCreditService.createBharadaCredit(bharadaCreditObj).subscribe(() => {
        this.toastrService.success("Record Created...!");
        setTimeout(() => {
          location.reload();
        }, 1000);
        this.showModal = false;
      });
    }
  }

  updateRecord(bharadaCreditObj: BharadaCreditInput) {
    this.bharadaCreditService.createBharadaCredit(bharadaCreditObj).subscribe(() => {
      this.toastrService.info("Record Updated...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
      this.showModal = false;
    });
  }
  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if (result) {
      this.bharadaCreditService.deleteBharadaCredit(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }
}
