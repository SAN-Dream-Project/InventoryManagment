import {AfterViewInit, Component, OnInit, ViewChild} from '@angular/core';
import { UserService } from "../../../services/user.service";
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { User } from '../../../models/User';
import {ToastrService} from "ngx-toastr";
import {NgxSpinnerService} from "ngx-spinner";

@Component({
  selector: 'app-data-table',
  templateUrl: './data-table.component.html',
  styleUrls: ['./data-table.component.less']
})

export class DataTableComponent implements OnInit, AfterViewInit {

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
    /*for (let i = 1; i <= 100; i++) { this.users.push(createNewUser(i)); }*/
    // Assign the data to the data source for the table to render
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
      this.user = data;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
    } else if(type === 'Create') {
      this.user = {} as User;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
    }
  }

  closeDialog() {
    this.showModal = false;
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

  convertToBoolean(status:any): boolean{
    return status === "true";
  }

  createRecord(userObj: User) {
    userObj.gender = parseInt(userObj.gender);
    userObj.status = this.convertToBoolean(userObj.status);
    this.userService.createUser(userObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      setTimeout(()=>{
        location.reload();
      }, 1000);
      this.showModal = false;
    });
  }

  updateRecord(userObj: User) {
    userObj.gender = parseInt(userObj.gender);
    userObj.status = this.convertToBoolean(userObj.status)
    this.userService.createUser(userObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      setTimeout(()=>{
        location.reload();
      }, 1000);
      this.showModal = false;
    });
  }

}

/** Builds and returns a new User.
function createNewUser(id: number): UserData {
  const name =
    NAMES[Math.round(Math.random() * (NAMES.length - 1))] + ' ' +
    NAMES[Math.round(Math.random() * (NAMES.length - 1))].charAt(0) + '.';

  return {
    id: id.toString(),
    name: name,
    progress: Math.round(Math.random() * 100).toString(),
    color: COLORS[Math.round(Math.random() * (COLORS.length - 1))]
  };
}*/
