import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { BharadaRate } from 'src/app/models/BharadaRate';
import { BharadaRateService } from 'src/app/services/bharada-rate.service';
@Component({
  selector: 'app-bharada-rate-section',
  templateUrl: './bharada-rate-section.component.html',
  styleUrls: ['./bharada-rate-section.component.less']
})

export class BharadaRateSectionComponent implements OnInit {
  bharadaRates: any = [];
  bharadaRateForm: FormGroup;
  displayedColumns = ['rateCriteria', 'rate','createdBy','action'];
  dataSource: MatTableDataSource<BharadaRate>;
  formSubmitted: boolean = false;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  bharadaRate: BharadaRate = {
    id: '',
    rateCriteriaID:'',
    rateCriteria:'',
    rate: '',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;
  constructor(private bharadaRateService:BharadaRateService,
    private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private formBuilder: FormBuilder) {
   this.paginator = this.bharadaRates;
   this.sort = this.bharadaRates;
   this.bharadaRateForm = new FormGroup({});
   this.dataSource = new MatTableDataSource(this.bharadaRates);setTimeout(() => {
     this.bharadaRateService.getAllBharadaRates().subscribe((bharadaRates) => {
       this.bharadaRates = bharadaRates;
       this.dataSource = new MatTableDataSource(this.bharadaRates);
       this.dataSource.paginator = this.paginator;
       this.dataSource.sort = this.sort;
     });
   }, 1000);
  }
  ngOnInit(): void {
    setTimeout(()=> {
      this.ngxSpinnerService.hide();
    }, 1000);
    this.bharadaRateForm = this.formBuilder.group({
      rateCriteriaID:['', [Validators.required]],
      rateCriteria:['', [Validators.required]],
      rate: ['', [Validators.required]]
      // rate: ['', [Validators.required, Validators.pattern("^[0-9]*$")]]
    });
  }
  get formControl(): { [key: string]: AbstractControl } {
    return this.bharadaRateForm.controls
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
  openModal(type:any, bharadaRateObj:any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.bharadaRate = {} as BharadaRate;
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.bharadaRate = bharadaRateObj;
    }
  }

  closeModal() {
    this.showModal = false;
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.bharadaRateService.deleteBharadaRate(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }

  submitForm(action: string, bharadaRateObj: BharadaRate): void {
    this.formSubmitted = true;
    if (this.bharadaRateForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(bharadaRateObj);
    }
    if (action === 'Update') {
      this.updateRecord(bharadaRateObj);
    }
  }

  appendZeros() {
    // let currentValue = this.bharadaRate.rate;
    // let regEx: any = "^[0-9]+\\.[0-9]{1,2}$";
    // currentValue.indexOf('.') !== -1 && regEx.test(currentValue) ? this.bharadaRate.rate = currentValue : this.bharadaRate.rate = currentValue+'.00';
  }

  createRecord(bharadaRateObj: BharadaRate) {
    bharadaRateObj.createdBy="nitingodase";
    this.bharadaRateService.createBharadaRate(bharadaRateObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

  updateRecord(bharadaRateObj: BharadaRate) {
    this.bharadaRateService.createBharadaRate(bharadaRateObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }
}
