import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
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
  displayedColumns = ['firstName', 'middleName', 'lastName','mobileNo', 'emailId', 'address', 'action'];
  dataSource: MatTableDataSource<Employee>;
  showModal: boolean = false;
  employee: Employee = {
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
    modifiedDate: ''
  };

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;
  constructor(private employeeService: EmployeeService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService) { 
    this.paginator = this.employees;
    this.sort = this.employees;
    this.dataSource = new MatTableDataSource(this.employees);
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
  }
  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }applyFilter(event: KeyboardEvent) {
    let filterValue = (event.target as HTMLInputElement).value;
    filterValue = filterValue.trim(); // Remove whitespace
    filterValue = filterValue.toLowerCase(); // Datasource defaults to lowercase matches
    this.dataSource !== undefined ? this.dataSource.filter = filterValue : undefined;
  }

  openDialog(x:any, y:any) {
    console.log(y);
    this.showModal = true;
    if(x === 'Edit') {
      this.employee = y;
    } else if(x === 'Create') {
      this.employee = {} as Employee;
    }
  }

  closeDialog() {
    this.showModal = false;
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.employeeService.deleteEmployee(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      location.reload();
    }
  }

  convertToBoolean(status:any): boolean{
    return status === "true";
  }

  createRecord(userObj: Employee) {
    this.employeeService.createEmployee(userObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      location.reload();
    });
  }

  updateRecord(userObj: Employee) {
    this.employeeService.createEmployee(userObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      location.reload();
    });
  }

}
