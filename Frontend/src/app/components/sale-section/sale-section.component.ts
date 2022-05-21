import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { map, Observable, startWith } from 'rxjs';
import { Sale, SaleInput } from 'src/app/models/Sale';
import { DropDown } from 'src/app/models/User';
import { DropdownService } from 'src/app/services/dropdown.service';
import { SaleService } from 'src/app/services/sale.service';

@Component({
  selector: 'app-sale-section',
  templateUrl: './sale-section.component.html',
  styleUrls: ['./sale-section.component.less']
})
export class SaleSectionComponent implements OnInit {
  displayedColumns = ['goodName', 'goodRetailerName', 'quantity', 'rate',  'totalLabourCosting', 'totalAmount', 'action'];
  dataSource: MatTableDataSource<Sale>;
  showModal: boolean = false;
  showPrintModal: boolean = false;
  printObj: any;
  sales: any = [];
  formSubmitted: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };

  retailers: DropDown[] = [];
  filteredRetailer: Observable<DropDown[]> | undefined;
  retailerCtrl = new FormControl();

  goods: DropDown[] = [];
  filteredGood: Observable<DropDown[]> | undefined;
  goodCtrl = new FormControl();

  labourCharges: DropDown[] = [];
  filteredlabourCharge: Observable<DropDown[]> | undefined;
  labourChargeCtrl = new FormControl();

  seletedlabourCharge:any;
  selectedRetailer: any;
  selectedGood = null;
  sale: SaleInput = {
    id: '',
    goodID: '',
    retailerID: '',
    quantity: '',
    rate: '',
    labourRateID: '',
    totalLabourCosting: '',
    discount: '',
    totalAmount: '',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: '',
    vehicleNumber: '',
    driverName: '',
    transportCharges: ''
  };
  saleForm: FormGroup;
  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private saleService: SaleService, private dropdownService: DropdownService, private ngxSpinnerService: NgxSpinnerService, private toastrService: ToastrService, private formBuilder: FormBuilder) {
    this.paginator = this.sales;
    this.sort = this.sales;
    this.dataSource = new MatTableDataSource(this.sales);
    this.saleForm = new FormGroup({});
    setTimeout(() => {
      this.saleService.GetAllSaleDetails().subscribe((sales) => {
        this.sales = sales;
        this.dataSource = new MatTableDataSource(this.sales);
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
    this.dropdownService.getGoodList().subscribe((goods) => {
      this.goods = goods;
    });
    this.filteredGood = this.goodCtrl.valueChanges
    .pipe(
        startWith(''),
      map(good => good ? this._filterGoods(good) : this.goods.slice())
    );
    this.dropdownService.getLabourRateList().subscribe((labourCharges) => {
      this.labourCharges = labourCharges;
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

  private _filterGoods(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.goods.filter(x => x.value.toLowerCase().includes(filterValue));
  }

  private _filterlabourCharges(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.labourCharges.filter(x => x.value.toLowerCase().includes(filterValue));
  }

  SelectedGood(good: any) {
    this.sale.goodID = good.key;
  }

  SelectedRetailer(retailer: any) {
    this.sale.retailerID = retailer.key;
  }

  ngOnInit(): void {
    this.validateForm();
    this.ngxSpinnerService.show();
    setTimeout(() => {
      this.ngxSpinnerService.hide();
    }, 1000);
  }

  validateForm() {
    this.saleForm = this.formBuilder.group({
      goodID:['', [Validators.required]],
      retailerID: ['', [Validators.required]],
      quantity: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      rate: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      // labourRateID: ['', [Validators.required]],
      totalLabourCosting: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      totalAmount: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      vehicleNumber: ['', []],
      driverName:  ['', []],
      transportCharges: ['', []],
    });
  }

  get formControl(): { [key: string]: AbstractControl } {
    return this.saleForm.controls
  }

  appendZeros() {
    /*let currentValue = this.user.primaryMobNo;
    let regEx: any = "^[0-9]+\\.[0-9]{1,2}$";
    currentValue.indexOf('.') !== -1 && regEx.test(currentValue) ? this.user.primaryMobNo = currentValue : this.user.primaryMobNo = currentValue + '.00';*/
  }

  calculateTotalAmount() {
    this.sale.totalAmount = (this.sale.quantity * this.sale.rate) - this.sale.totalLabourCosting; //- this.sale.transportCharges;
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
      this.sale = {} as SaleInput;
      this.sale.quantity = 0.00;
      this.sale.rate = 0.00;
      this.sale.totalLabourCosting = 0.00;
      this.sale.totalAmount = 0.00;
      this.selectedGood = null;
      this.selectedRetailer = null;
      this.seletedlabourCharge = null;
    } else if (type === 'Print') {
      this.printObj = purchaseObj;
      this.showPrintModal = true;
      setTimeout(()=>{
        window.print();
      }, 500);
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.sale = purchaseObj;
      this.selectedGood = purchaseObj.goodName;
      this.sale.goodID = this.goods.find(x=>x.value === purchaseObj.goodName)?.key;
      this.selectedRetailer = purchaseObj.goodRetailerName;
      this.sale.retailerID = this.retailers.find(x=>x.value === purchaseObj.goodRetailerName)?.key;
      this.seletedlabourCharge = purchaseObj.labourRate;
      this.sale.labourRateID = this.labourCharges.find(x=>x.value == purchaseObj.labourRate)?.key;
    }
  }
  closeModal() {
    this.showModal = false;
  }

  closePrintModal() {
    this.showPrintModal = false;
  }

  submitForm(action: string, saleObj: SaleInput): void {
    this.formSubmitted = true;
    if (this.saleForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(saleObj);
    }
    if (action === 'Update') {
      this.updateRecord(saleObj);
    }
  }
  createRecord(saleObj: SaleInput) {
    this.formSubmitted = true;
    if (this.saleForm.valid) {
      this.sale.quantity = parseFloat(this.sale.quantity);
      this.sale.rate = parseFloat(this.sale.rate);
      this.sale.totalLabourCosting = parseFloat(this.sale.totalLabourCosting);
      this.sale.totalAmount = parseFloat(this.sale.totalAmount);
      this.saleService.createSaleDetail(saleObj).subscribe(() => {
        this.toastrService.success("Record Created...!");
        setTimeout(() => {
          location.reload();
        }, 1000);
        this.showModal = false;
      });
    }
  }

  updateRecord(saleObj: SaleInput) {
    this.saleService.createSaleDetail(saleObj).subscribe(() => {
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
      this.saleService.deleteSale(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }
}
