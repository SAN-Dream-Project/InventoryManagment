import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Labour } from 'src/app/models/Labour';
import { LabourService } from 'src/app/services/labour.service';

@Component({
  selector: 'app-labour-section',
  templateUrl: './labour-section.component.html',
  styleUrls: ['./labour-section.component.less']
})
export class LabourSectionComponent implements OnInit {
  labours:any = [];
  labourForm: FormGroup;
  displayedColumns = ['firstName', 'middleName', 'lastName','mobileNo', 'emailId', 'address', 'action'];
  dataSource: MatTableDataSource<Labour>;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  formSubmitted: boolean = false;
  labour: Labour = {
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

  constructor(private labourService: LabourService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService,private formBuilder: FormBuilder) {
    this.paginator = this.labours;
    this.sort = this.labours;
    this.dataSource = new MatTableDataSource(this.labours);
    this.labourForm = new FormGroup({});
    /*for (let i = 1; i <= 100; i++) { this.users.push(createNewUser(i)); }*/
    // Assign the data to the data source for the table to render
    setTimeout(() => {
      this.labourService.getAllLabours().subscribe((labours) => {
        this.labours = labours;
        this.dataSource = new MatTableDataSource(this.labours);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000);
  }

  ngOnInit(): void { this.ngxSpinnerService.show();
    setTimeout(()=> {
      this.ngxSpinnerService.hide();
    }, 1000);
    this.labourForm = this.formBuilder.group({
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
    return this.labourForm.controls
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

  openModal(type:any, labourObj:any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.labour = {} as Labour;
      this.labour.gender = '';
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.labour= labourObj;
    }
  }

  closeModal() {
    this.showModal = false;
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.labourService.deleteLabour(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }

  submitForm(action: string, labourObj: Labour): void {
    this.formSubmitted = true;
    if (this.labourForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(labourObj);
    }
    if (action === 'Update') {
      this.updateRecord(labourObj);
    }
  }

  createRecord(labourObj: Labour) {
    labourObj.gender = parseInt(labourObj.gender);
    this.labourService.createLabour(labourObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

  updateRecord(labourObj: Labour) {
    labourObj.gender = parseInt(labourObj.gender);
    this.labourService.createLabour(labourObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

}
