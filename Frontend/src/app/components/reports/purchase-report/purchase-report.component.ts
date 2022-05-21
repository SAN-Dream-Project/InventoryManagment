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
  purchaseReportForm: FormGroup;

  purchaseReportInput: PurchaseReportInput = {
    goodID: '',
    fromDate: new Date(),
    toDate: new Date()
  }

  constructor( private dropdownService: DropdownService, private purchaseService: PurchaseService,  private formBuilder: FormBuilder) {
    this.purchaseReportForm = new FormGroup({});
    this.dropdownService.getGoodList().subscribe((goods) => {
      this.goods = goods;
    });
    this.filteredGoods = this.goodCtrl.valueChanges
    .pipe(
      startWith(''),
      map(good => good ? this._filterGoods(good) : this.goods.slice())
    );
  }

  ngOnInit(): void {
  }

  validateForm() {
    this.purchaseReportForm = this.formBuilder.group({
      goodID: ['', [Validators.required]]
    });
  }

  private _filterGoods(value: string): DropDown[] {
    const filterValue = value.toLowerCase();
    return this.goods.filter(x => x.value.toLowerCase().includes(filterValue));
  }

  SelectedGood(good: any) {
    this.purchaseReportInput.goodID = good.key;
  }

  getPurchaseReportDetails() {
    console.table(this.purchaseReportInput);
    this.purchaseService.getPurchaseReport(this.purchaseReportInput).subscribe();
  }

}
