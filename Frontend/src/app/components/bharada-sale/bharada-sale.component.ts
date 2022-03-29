import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { map, Observable, startWith } from 'rxjs';
import { BharadaSale, BharadaSaleInput } from 'src/app/models/BharadaSale';
import { DropDown } from 'src/app/models/User';
import { BharadaSaleService } from 'src/app/services/bharada-sale.service';
import { DropdownService } from 'src/app/services/dropdown.service';

@Component({
  selector: 'app-bharada-sale',
  templateUrl: './bharada-sale.component.html',
  styleUrls: ['./bharada-sale.component.less']
})
export class BharadaSaleComponent implements OnInit {
  displayedColumns = ['bharadaRate', 'quantity', 'retailerName', 'totalAmount', 'labourRate', 'totalLabourCosting', 'netAmount','paidAmount','remainingAmount', 'action'];
  dataSource: MatTableDataSource<BharadaSale>;
  showModal: boolean = false;
  bharadaSales: any = [];
  formSubmitted: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  }; 
  
  retailers: DropDown[] = [];
  filteredRetailer: Observable<DropDown[]> | undefined;
  retailerCtrl = new FormControl();

  bharadaRates: DropDown[] = [];
  filteredbharadaRate: Observable<DropDown[]> | undefined;
  bharadaRateCtrl = new FormControl();

  labourCharges: DropDown[] = [];
  filteredlabourCharge: Observable<DropDown[]> | undefined;
  labourChargeCtrl = new FormControl(); 

  seletedlabourCharge:any;
  selectedRetailer: any;
  selectedBharadaRate = null;
  bharadaSale: BharadaSaleInput = {
    id: '',
    bharadaRateID:'',
    quantity:'',
    retailerID:'',
    totalAmount:'',
    discount :'',
    labourRateID:'',
    totalLabourCosting:'',
    netAmount:'',
    paidAmount:'',
    remainingAmount:'',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };
  bharadaSaleForm: FormGroup;
  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private bharadaSaleService: BharadaSaleService, private dropdownService: DropdownService, private ngxSpinnerService: NgxSpinnerService, private toastrService: ToastrService, private formBuilder: FormBuilder) {
    this.paginator = this.bharadaSales;
    this.sort = this.bharadaSales;
    this.dataSource = new MatTableDataSource(this.bharadaSales);
    this.bharadaSaleForm = new FormGroup({});
    setTimeout(() => {
      this.bharadaSaleService.getAllBharadaSales().subscribe((bharadaSales) => {
        this.bharadaSales = bharadaSales;
        this.dataSource = new MatTableDataSource(this.bharadaSales);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000); 
    this.dropdownService.getRetailerList().subscribe((retailers) => {
      this.retailers = retailers;
      console.log(this.retailers);
    });
    this.filteredRetailer = this.retailerCtrl.valueChanges
        .pipe(
          startWith(''),
          map(retailer => retailer ? this._filterRetailers(retailer) : this.retailers.slice())
        );
    this.dropdownService.getBharadaCrateriaList().subscribe((bharadaRates) => {
        this.bharadaRates = bharadaRates;
        console.log(this.bharadaRates);
        });
    this.filteredbharadaRate = this.bharadaRateCtrl.valueChanges
        .pipe(
            startWith(''),
          map(bharadaRate => bharadaRate ? this._filterBharadaRates(bharadaRate) : this.bharadaRates.slice())
          );
    this.dropdownService.getLabourRateList().subscribe((labourCharges) => {
        this.labourCharges = labourCharges;
        console.log(this.labourCharges);
        });
    this.filteredlabourCharge = this.labourChargeCtrl.valueChanges
        .pipe(
          startWith(''),
          map(labourCharge => labourCharge ? this._filterlabourCharges(labourCharge) : this.labourCharges.slice())
        );
  }
  private _filterRetailers(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.retailers.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  private _filterBharadaRates(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.bharadaRates.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  private _filterlabourCharges(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.labourCharges.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  SelectedBharadaRate(bharadaRate: any) {
    this.bharadaSale.bharadaRateID = bharadaRate.key;
  }
  SelectedRetailer(retailer: any) {
    this.bharadaSale.retailerID = retailer.key;
  }
  SelectedlabourCharge(labourRate: any) {
    this.bharadaSale.labourRateID = labourRate.key;
    this.bharadaSale.totalLabourCosting = (this.bharadaSale.quantity/100)*labourRate.value;
    // this.bharadaSale.toatalAmount = (this.bharadaSale.quntity * this.bharadaSale.rate)-((this.sale.quntity/100)*labourRate.value);
  }
  ngOnInit(): void {
    this.validateForm();
    this.ngxSpinnerService.show();
    setTimeout(() => {
      this.ngxSpinnerService.hide();
    }, 1000);
  }
  validateForm() {
    this.bharadaSaleForm = this.formBuilder.group({
      bharadaRateID: ['', [Validators.required]],
      retailerID: ['', [Validators.required]],
      quantity: ['', [Validators.required]],
      labourRateID: ['', [Validators.required]],
      totalLabourCosting: ['', [Validators.required]],
      totalAmount: ['', [Validators.required]],
      netAmount: ['', [Validators.required]],
      paidAmount: ['', [Validators.required]],
      remainingAmount: ['', [Validators.required]]
    });
  }
  get formControl(): { [key: string]: AbstractControl } {
    return this.bharadaSaleForm.controls
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
      this.bharadaSale = {} as BharadaSaleInput;
       this.selectedBharadaRate = null;
       this.selectedRetailer = null;
       this.seletedlabourCharge = null;
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.bharadaSale = bharadaSaleObj;
      this.selectedBharadaRate = bharadaSaleObj.bharadaRate;
      this.bharadaSale.bharadaRateID = this.bharadaRates.find(x=>x.value === bharadaSaleObj.bharadaRate)?.key;
      this.selectedRetailer = bharadaSaleObj.retailerName;
      this.bharadaSale.retailerID = this.retailers.find(x=>x.value === bharadaSaleObj.retailerName)?.key;
      this.seletedlabourCharge = bharadaSaleObj.labourRate;
      this.bharadaSale.labourRateID = this.labourCharges.find(x=>x.value == bharadaSaleObj.labourRate)?.key;
    }
  }
  closeModal() {
    this.showModal = false;
  }
  submitForm(action: string, saleObj: BharadaSaleInput): void {
    this.formSubmitted = true;
    if (this.bharadaSaleForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(saleObj);
    }
    if (action === 'Update') {
      this.updateRecord(saleObj);
    }
  }
  createRecord(bharadaSaleObj: BharadaSaleInput) {
    this.formSubmitted = true;
    if (this.bharadaSaleForm.valid) {
      this.bharadaSaleService.createBharadaSale(bharadaSaleObj).subscribe(() => {
        this.toastrService.success("Record Created...!");
        setTimeout(() => {
          location.reload();
        }, 1000);
        this.showModal = false;
      });
    }
  }

  updateRecord(bharadaSaleObj: BharadaSaleInput) {
    this.bharadaSaleService.createBharadaSale(bharadaSaleObj).subscribe(() => {
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
      this.bharadaSaleService.deleteBharadaSale(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }
}
