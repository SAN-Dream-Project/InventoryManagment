import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Sale, SaleInput } from 'src/app/models/Sale';
import { DropdownService } from 'src/app/services/dropdown.service';
import { SaleService } from 'src/app/services/sale.service';

@Component({
  selector: 'app-sale-section',
  templateUrl: './sale-section.component.html',
  styleUrls: ['./sale-section.component.less']
})
export class SaleSectionComponent implements OnInit {
  displayedColumns = ['goodName', 'goodSupplierName', 'quntity', 'rate', 'labourRate', 'totalLabourCosting', 'totalAmount', 'action'];
  dataSource: MatTableDataSource<Sale>;
  showModal: boolean = false;
  users: any = [];
  sales: any = [];
  formSubmitted: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  }; 
  sale: SaleInput = {
    id: '',
    goodID: '',
    goodSupplierID: '',
    quantity: '',
    rate: '',
    labourRateID: '',
    totalLabourCosting: '',
    discount:'',
    totalAmout: '',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };
  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private saleService: SaleService, private dropdownService: DropdownService, private ngxSpinnerService: NgxSpinnerService, private toastrService: ToastrService, private formBuilder: FormBuilder) {
    this.paginator = this.users;
    this.sort = this.users;
    this.dataSource = new MatTableDataSource(this.users);
    setTimeout(() => {
      this.saleService.GetAllSaleDetails().subscribe((sales) => {
        this.sales = sales;
        this.dataSource = new MatTableDataSource(this.sales);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000); }

  ngOnInit(): void {
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
      // this.selectedGood = null;
      // this.selectedSupplier = null;
      // this.selectedKadata = null;
      // this.seletedlabourCharge = null;
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      // this.purchase = purchaseObj;
      // this.selectedGood = purchaseObj.goodName;
      // this.selectedSupplier = purchaseObj.goodSupplierName;
      // this.selectedKadata = purchaseObj.kadataQuantity;
      // this.seletedlabourCharge = purchaseObj.labourRate;
    }
  }
  closeModal() {
    this.showModal = false;
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
