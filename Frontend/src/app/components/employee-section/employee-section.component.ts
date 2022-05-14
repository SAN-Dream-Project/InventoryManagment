import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Employee } from 'src/app/models/Employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee-section',
  templateUrl: './employee-section.component.html',
  styleUrls: ['./employee-section.component.less']
})
export class EmployeeSectionComponent implements OnInit, AfterViewInit {
  employees:any = [];
  employeeForm: FormGroup;
  displayedColumns = ['firstName', 'middleName', 'lastName','mobileNo', 'emailId', 'address', 'action'];
  dataSource: MatTableDataSource<Employee>;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  formSubmitted: boolean = false;
  employee: Employee = {
    id: '',
    // firstName: '',
    // middleName: '',
    // lastName: '',
    fullName:'',
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

  constructor(private employeeService: EmployeeService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService,private formBuilder: FormBuilder) {
    this.paginator = this.employees;
    this.sort = this.employees;
    this.dataSource = new MatTableDataSource(this.employees);
    this.employeeForm = new FormGroup({});
    /*for (let i = 1; i <= 100; i++) { this.users.push(createNewUser(i)); }*/
    // Assign the data to the data source for the table to render
    setTimeout(() => {
      this.employeeService.getAllEmployees().subscribe((employees) => {
        this.employees = employees;
        this.dataSource = new MatTableDataSource(this.employees);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000);
  }

  ngOnInit(): void { this.ngxSpinnerService.show();
    setTimeout(()=> {
      this.ngxSpinnerService.hide();
    }, 1000);
    this.employeeForm = this.formBuilder.group({
      // firstName: ['', [Validators.required]],
      // middleName: ['', [Validators.required]],
      // lastName: ['', [Validators.required]],
      fullName: ['', [Validators.required]],
      mobileNo: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10), Validators.pattern("^[0-9]*$")]],
      emailID: ['', [Validators.email]],
      address: ['', [Validators.maxLength(100)]],
      gender: ['', [Validators.required]]
    });
  }

  get formControl(): { [key: string]: AbstractControl } {
    return this.employeeForm.controls
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

  openModal(type:any, userObj:any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.employee = {} as Employee;
      this.employee.gender = '';
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.employee = userObj;
    }
  }

  closeModal() {
    this.showModal = false;
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.employeeService.deleteEmployee(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }

  submitForm(action: string, employeeObj: Employee): void {
    this.formSubmitted = true;
    if (this.employeeForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(employeeObj);
    }
    if (action === 'Update') {
      this.updateRecord(employeeObj);
    }
  }

  createRecord(employeeObj: Employee) {
    employeeObj.gender = parseInt(employeeObj.gender);
    this.employeeService.createEmployee(employeeObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

  updateRecord(employeeObj: Employee) {
    employeeObj.gender = parseInt(employeeObj.gender);
    this.employeeService.createEmployee(employeeObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

}
