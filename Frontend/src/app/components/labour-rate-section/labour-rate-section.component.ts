import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { LabourRate } from 'src/app/models/LabourRate';
import { LabourRateService } from 'src/app/services/labour-rate.service';

@Component({
  selector: 'app-labour-rate-section',
  templateUrl: './labour-rate-section.component.html',
  styleUrls: ['./labour-rate-section.component.less']
})
export class LabourRateSectionComponent implements OnInit {
  labourRates: any = [];
  labourRateForm: FormGroup;
  displayedColumns = ['rate', 'createdBy','action'];
  dataSource: MatTableDataSource<LabourRate>;
  formSubmitted: boolean = false;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  labourRate: LabourRate = {
    id: '',
    rate: '',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private labourRateService:LabourRateService,
    private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private formBuilder: FormBuilder) {
   this.paginator = this.labourRates;
   this.sort = this.labourRates;
   this.labourRateForm = new FormGroup({});
   this.dataSource = new MatTableDataSource(this.labourRates);setTimeout(() => {
     this.labourRateService.getAllLabourRates().subscribe((labourRates) => {
       this.labourRates = labourRates;
       this.dataSource = new MatTableDataSource(this.labourRates);
       this.dataSource.paginator = this.paginator;
       this.dataSource.sort = this.sort;
     });
   }, 1000);
  }

  ngOnInit(): void {this.ngxSpinnerService.show();
    setTimeout(()=> {
      this.ngxSpinnerService.hide();
    }, 1000);
    this.labourRateForm = this.formBuilder.group({
      rate: ['', [Validators.required, Validators.pattern("^[0-9]*$")]]
    });
  }

  get formControl(): { [key: string]: AbstractControl } {
    return this.labourRateForm.controls
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

  openModal(type:any, labourRateObj:any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.labourRate = {} as LabourRate;
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.labourRate = labourRateObj;
    }
  }

  closeModal() {
    this.showModal = false;
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.labourRateService.deleteLabourRate(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }

  submitForm(action: string, labourRateObj: LabourRate): void {
    this.formSubmitted = true;
    if (this.labourRateForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(labourRateObj);
    }
    if (action === 'Update') {
      this.updateRecord(labourRateObj);
    }
  }

  appendZeros() {
    let currentValue = this.labourRate.rate;
    let regEx: any = "^[0-9]+\\.[0-9]{1,2}$";
    currentValue.indexOf('.') !== -1 && regEx.test(currentValue) ? this.labourRate.rate = currentValue : this.labourRate.rate = currentValue+'.00';
  }

  createRecord(labourRateObj: LabourRate) {
    labourRateObj.createdBy="nitingodase";
    this.labourRateService.createLabourRate(labourRateObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

  updateRecord(labourRateObj: LabourRate) {
    this.labourRateService.createLabourRate(labourRateObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }
}
