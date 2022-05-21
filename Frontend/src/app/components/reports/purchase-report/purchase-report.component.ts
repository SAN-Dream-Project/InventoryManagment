import { Component, OnInit } from '@angular/core';
import {PurchaseReportInput} from "../../../models/Purchase";
import {map, Observable, startWith} from "rxjs";
import {DropDown} from "../../../models/User";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";
import {DropdownService} from "../../../services/dropdown.service";
import {PurchaseService} from "../../../services/purchase.service";

@Component({
  selector: 'app-purchase-report',
  templateUrl: './purchase-report.component.html',
  styleUrls: ['./purchase-report.component.less']
})
export class PurchaseReportComponent implements OnInit {

  selectedGood: any;
  goods: DropDown[] = [];
  filteredGoods: Observable<DropDown[]> | undefined;
  goodCtrl = new FormControl();
  goodIDGroup: FormGroup;
  purchaseReportDetails:any;
  hasReportData: boolean = false;
  purchaseReportInput: PurchaseReportInput = {
    goodID: '',
    fromDate: new Date(),
    toDate: new Date()
  }

  constructor( private dropdownService: DropdownService, private purchaseService: PurchaseService,  private formBuilder: FormBuilder) {
    this.goodIDGroup = new FormGroup({});
    this.dropdownService.getGoodList().subscribe((goods) => {
      this.goods = goods;
    });
    this.filteredGoods = this.goodCtrl.valueChanges
    .pipe(
      startWith(''),
      map(good => good ? this._filterGoods(good) : this.goods.slice())
    );
  }

  ngOnInit(): void {}

  private _filterGoods(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.goods.filter(x => x.value.toLowerCase().includes(filterValue));
  }

  goodSelected(good: any) {
    this.purchaseReportInput.goodID = good.key;
  }

  getPurchaseReportDetails() {
    this.purchaseReportInput.goodID == '' ? this.purchaseReportInput.goodID = null : this.purchaseReportInput.goodID;
    console.log(this.purchaseReportInput);
    this.purchaseService.getPurchaseReport(this.purchaseReportInput).subscribe(purchseReportDetails=>{
      this.purchaseReportDetails = purchseReportDetails;
      this.purchaseReportDetails.length > 0 ? this.hasReportData = true : this.hasReportData = false;
    });
  }

  printReport() {
    window.print();
  }

}
