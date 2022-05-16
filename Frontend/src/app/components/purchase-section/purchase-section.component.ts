import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Purchase, PurchaseInput } from "../../models/Purchase";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { PurchaseService } from "../../services/purchase.service";
import { DropdownService } from 'src/app/services/dropdown.service';
import { DropDown } from 'src/app/models/User';
import { map, Observable, startWith } from 'rxjs';

@Component({
  selector: 'app-purchase-section',
  templateUrl: './purchase-section.component.html',
  styleUrls: ['./purchase-section.component.less']
})
export class PurchaseSectionComponent implements OnInit {

  displayedColumns = ['goodName', 'goodSupplierName', 'grossGoodQuantity', 'goodRate', 'kadataQuantity', 'totalLabourCosting', 'totalAmount', 'action'];
  dataSource: MatTableDataSource<Purchase>;
  showModal: boolean = false;
  showPrintModal: boolean = false;
  printObj: any;
  users: any = [];
  purchases: any = [];

  goods: DropDown[] = [];
  filteredGood: Observable<DropDown[]> | undefined;
  goodCtrl = new FormControl();

  suppilers: DropDown[] = [];
  filteredSuppiler: Observable<DropDown[]> | undefined;
  supplierCtrl = new FormControl();

  kadatas: DropDown[] = [];
  filteredKadata: Observable<DropDown[]> | undefined;
  kadataCtrl = new FormControl();

  labourCharges: DropDown[] = [];
  filteredlabourCharge: Observable<DropDown[]> | undefined;
  labourChargeCtrl = new FormControl();

  selectedGood: any;
  selectedSupplier: any;
  selectedKadata:any;
  seletedlabourCharge:any;

  purchaseForm: FormGroup;
  formSubmitted: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  purchase: PurchaseInput = {
    id: '',
    goodID: '',
    goodSupplierID: '',
    grossGoodQuantity: 0.00,
    goodRate: 0.00,
    kadataID: '',
    kadtaTotal: 0.00,
    netGoodQuantity: 0.00,
    labourRateID: '',
    totalLabourCosting: 0.00,
    totalAmount: 0.00,
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private purchaseService: PurchaseService, private dropdownService: DropdownService, private ngxSpinnerService: NgxSpinnerService, private toastrService: ToastrService, private formBuilder: FormBuilder) {
    this.paginator = this.users;
    this.sort = this.users;
    this.dataSource = new MatTableDataSource(this.users);
    this.purchaseForm = new FormGroup({});
    setTimeout(() => {
      this.purchaseService.getAllPurchases().subscribe((purchases) => {
        this.purchases = purchases;
        this.dataSource = new MatTableDataSource(this.purchases);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000);

    this.dropdownService.getGoodList().subscribe((goods) => {
      this.goods = goods;
    });
    this.dropdownService.getSupplierList().subscribe((suppilers) => {
      this.suppilers = suppilers;
    });
    this.dropdownService.getKadataList().subscribe((kadatas) => {
      this.kadatas = kadatas;
    });
    this.dropdownService.getLabourRateList().subscribe((labourCharges) => {
      this.labourCharges = labourCharges;
    });
    this.filteredGood = this.goodCtrl.valueChanges
      .pipe(
        startWith(''),
        map(good => good ? this._filterGoods(good) : this.goods.slice())
      );

    this.filteredSuppiler = this.supplierCtrl.valueChanges
        .pipe(
          startWith(''),
          map(suppiler => suppiler ? this._filterSuppliers(suppiler) : this.suppilers.slice())
        );

    this.filteredKadata = this.kadataCtrl.valueChanges
        .pipe(
          startWith(''),
          map(kadata => kadata ? this._filterKadatas(kadata) : this.kadatas.slice())
        );
    this.filteredlabourCharge = this.labourChargeCtrl.valueChanges
        .pipe(
          startWith(''),
          map(labourCharge => labourCharge ? this._filterlabourCharges(labourCharge) : this.labourCharges.slice())
        );
  }
  private _filterGoods(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.goods.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  private _filterSuppliers(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.suppilers.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  private _filterKadatas(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.kadatas.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  private _filterlabourCharges(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.labourCharges.filter(x => x.value.toLowerCase().includes(filterValue));
  }
  SelectedGood(good: any) {
    this.purchase.goodID = good.key;
  }
  SelectedSupplier(suppiler: any) {
    this.purchase.goodSupplierID = suppiler.key;
  }
  SelectedKadata(kadata: any) {
    this.purchase.kadataID = kadata.key;
    this.purchase.kadtaTotal = (this.purchase.grossGoodQuantity/100)*kadata.value;
    this.purchase.netGoodQuantity = this.purchase.grossGoodQuantity - this.purchase.kadtaTotal;
    this.purchase.totalAmount = (this.purchase.netGoodQuantity * this.purchase.goodRate);
    if(this.purchase.totalLabourCosting){
      this.purchase.totalAmount = (this.purchase.netGoodQuantity*this.purchase.goodRate)-this.purchase.totalLabourCosting;
    }
  }
  SelectedLabourCharge(labourRate: any) {
    this.purchase.labourRateID = labourRate.key;
    this.purchase.totalLabourCosting = (this.purchase.grossGoodQuantity/100)*labourRate.value;
    this.purchase.totalAmount = (this.purchase.netGoodQuantity*this.purchase.goodRate)-this.purchase.totalLabourCosting;
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
      goodID: ['', [Validators.required]],
      goodSupplierID: ['', [Validators.required]],
      grossGoodQuantity: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      goodRate: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      kadataID: ['', [Validators.required]],
     // kadataID: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern("^[0-9]+\\.[0-9]{1,2}$")]],
      kadtaTotal: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      netGoodQuantity: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      //labourRateID: [''],
      totalLabourCosting: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]],
      totalAmount: ['', [Validators.required, Validators.pattern("^[0-9]*\.?[0-9]*$")]]
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
      this.purchase = {} as PurchaseInput;
      this.purchase.grossGoodQuantity = 0.00;
      this.purchase.goodRate = 0.00;
      this.purchase.kadtaTotal = 0.00;
      this.purchase.netGoodQuantity = 0.00;
      this.purchase.totalLabourCosting = 0.00;
      this.purchase.totalAmount = 0.00;
      this.selectedGood = null;
      this.selectedSupplier = null;
      this.selectedKadata = null;
      this.seletedlabourCharge = null;
    } /*else if (type === 'Print') {
      this.printObj = userObj;
      this.showPrintModal = true;
      setTimeout(()=>{
        window.print();
      }, 500);
    }*/ else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.purchase = purchaseObj;
      this.selectedGood = purchaseObj.goodName;
      this.selectedSupplier = purchaseObj.goodSupplierName;
      this.selectedKadata = purchaseObj.kadataQuantity;
      this.seletedlabourCharge = purchaseObj.labourRate;
    }
  }

  closeModal() {
    this.showModal = false;
  }
  /*closePrintModal() {
    this.showPrintModal = false;
  }*/

  submitForm(action: string, purchaseObj: PurchaseInput): void {
    console.log(purchaseObj);
    this.formSubmitted = true;
    if (this.purchaseForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(purchaseObj);
    }
    if (action === 'Update') {
      this.updateRecord(purchaseObj);
    }
  }

  appendZeros(event: any) {
    let currentValue = (event.target as HTMLInputElement).value;
    let currentItem = event.target.id;
    let regEx: any = "^[0-9]+\\.[0-9]{1,2}$";
    currentValue != undefined && currentValue != null && currentValue != "" ? currentValue.indexOf('.') !== -1 && regEx.test(currentValue) ? currentItem = currentValue : currentItem = parseFloat(currentValue + '.00') : currentItem = parseFloat('0.00');
    this.calculateTotalAmount();
  }

  calculateTotalAmount() {
    this.purchase.totalAmount = (this.purchase.netGoodQuantity * this.purchase.goodRate) - this.purchase.totalLabourCosting;
  }

  createRecord(purchaseObj: PurchaseInput) {
    this.formSubmitted = true;
    if (this.purchaseForm.valid) {
      purchaseObj.grossGoodQuantity = parseFloat(purchaseObj.grossGoodQuantity);
      purchaseObj.goodRate = parseFloat(purchaseObj.goodRate);
      purchaseObj.kadtaTotal = parseInt(purchaseObj.kadtaTotal);
      purchaseObj.netGoodQuantity = parseFloat(purchaseObj.netGoodQuantity);
      purchaseObj.totalLabourCosting = parseFloat(purchaseObj.totalLabourCosting);
      purchaseObj.totalAmount = parseFloat(purchaseObj.totalAmount);
      this.purchaseService.createPurchase(purchaseObj).subscribe(() => {
        this.toastrService.success("Record Created...!");
        setTimeout(() => {
          location.reload();
        }, 1000);
        this.showModal = false;
      });
    }
  }

  updateRecord(purchaseObj: PurchaseInput) {
    this.purchaseService.createPurchase(purchaseObj).subscribe(() => {
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
      this.purchaseService.deletePurchase(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }

}
