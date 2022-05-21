import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ToastrService } from "ngx-toastr";
import { NgxSpinnerService } from "ngx-spinner";
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";
import { Observable } from 'rxjs';
import { DropDown, User } from "../../models/User";
import { UserService } from "../../services/user.service";
import { CustomValidator } from "../demos/data-table/custom-validator";

@Component({
  selector: 'app-user-section',
  templateUrl: './user-section.component.html',
  styleUrls: ['./user-section.component.less']
})
export class UserSectionComponent implements OnInit {
  goodCtrl = new FormControl();
  filteredGood: Observable<DropDown[]> | undefined;

  goods: DropDown[] = [];

  users: any = [];
  displayedColumns = ['firstName', 'lastName', 'primaryMobNo', 'action'];
  dataSource: MatTableDataSource<User>;
  showModal: boolean = false;
  printObj: any;
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

  testForm: FormGroup;
  formSubmitted: boolean = false;

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private userService: UserService,
              private toastrService: ToastrService,
              private ngxSpinnerService: NgxSpinnerService,
              private formBuilder: FormBuilder) {
    this.paginator = this.users;
    this.sort = this.users;
    this.dataSource = new MatTableDataSource(this.users);
    this.testForm = new FormGroup({});
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
    this.validateForm();
    this.ngxSpinnerService.show();
    setTimeout(() => {
      this.ngxSpinnerService.hide();
    }, 1000);
  }

  validateForm() {
    this.testForm = this.formBuilder.group({
      userName: ['', [Validators.required, Validators.minLength(5)]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      firstName: ['', [Validators.required, CustomValidator]],
      lastName: ['', [Validators.required]],
      primaryMobNo: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(10)]],
      secondaryMobNo: ['', [Validators.minLength(10), Validators.maxLength(10)]],
      telephoneNo: ['', [Validators.minLength(10), Validators.maxLength(10)]],
      gender: ['', [Validators.required]]
    });
  }

  get formControl(): { [key: string]: AbstractControl } {
    return this.testForm.controls
  }
  /*get userName() { return this.testForm.get('userName'); }
  get password() { return this.testForm.get('password'); }
  get firstName() { return this.testForm.get('firstName'); }
  get lastName() { return this.testForm.get('lastName'); }
  get primaryMobNo() { return this.testForm.get('primaryMobNo'); }
  get secondaryMobNo() { return this.testForm.get('secondaryMobNo'); }
  get telephoneNo() { return this.testForm.get('telephoneNo'); }
  get gender() { return this.testForm.get('gender'); }*/

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

  openModal(type: any, userObj: any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.user = {} as User;
      this.user.gender = '';
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.user = userObj;
    }
  }

  closeModal() {
    this.showModal = false;
  }

  submitForm(action: string, userObj: User): void {
    this.formSubmitted = true;
    if (this.testForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(userObj);
    }
    if (action === 'Update') {
      this.updateRecord(userObj);
    }
  }

  createRecord(userObj: User) {
    userObj.gender = parseInt(userObj.gender);
    userObj.status = true;
    this.formSubmitted = true;
    if (this.testForm.valid) {
      this.userService.createUser(userObj).subscribe(() => {
        this.toastrService.success("Record Created...!");
        setTimeout(() => {
          location.reload();
        }, 1000);
        this.showModal = false;
      });
    }
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
    if (result) {
      this.userService.deleteUser(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }

}
