import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from "../../../services/user.service";
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { User } from '../../../models/User';
import { ToastrService } from "ngx-toastr";
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.less']
})

export class DataTableComponent implements OnInit {

  users: any = [];
  displayedColumns = ['firstName', 'lastName', 'primaryMobNo', 'action'];
  dataSource: MatTableDataSource<User>;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  user: User = {
    id: '',
    userName: '',
    password: '',
    status: false,
    firstName: '',
    lastName: '',
    primaryMobNo: '',
    secondaryMobNo: '',
    telephoneNo: '',
    gender: '',
    CreatedBy: '',
    CreatedDate: '',
    ModifiedBy: '',
    ModifiedDate: ''
  };

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private userService: UserService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService) {
    this.paginator = this.users;
    this.sort = this.users;
    this.dataSource = new MatTableDataSource(this.users);
    setTimeout(() => {
      this.userService.getAllUsers().subscribe((users) => {
        this.users = users;
        this.dataSource = new MatTableDataSource(this.users);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000);
  }

  ngOnInit(): void {
    this.ngxSpinnerService.show();
    setTimeout(()=> {
      this.ngxSpinnerService.hide();
    }, 1000);
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

  openDialog(type:any, data:any) {
    this.showModal = true;
    if(type === 'Edit') {
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.user = data;
    } else if(type === 'Create') {
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.user = {} as User;
      this.user.gender = -1;
    }
  }

  closeDialog() {
    this.showModal = false;
  }

  createRecord(userObj: User) {
    userObj.gender = parseInt(userObj.gender);
    userObj.status = true;
    this.userService.createUser(userObj).subscribe(() => {
      this.toastrService.success("Record Created...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
      this.showModal = false;
    });
  }

  updateRecord(userObj: User) {
    userObj.gender = parseInt(userObj.gender);
    userObj.status = true;
    this.userService.createUser(userObj).subscribe(() => {
      this.toastrService.info("Record Updated...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
      this.showModal = false;
    });
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.userService.deleteUser(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(()=>{
        location.reload();
      }, 1000);
    }
  }

}
