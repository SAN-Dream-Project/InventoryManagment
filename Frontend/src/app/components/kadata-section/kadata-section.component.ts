import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Kadata } from 'src/app/models/Kadata';
import { KadataService } from 'src/app/services/kadata.service';

@Component({
  selector: 'app-kadata-section',
  templateUrl: './kadata-section.component.html',
  styleUrls: ['./kadata-section.component.less']
})
export class KadataSectionComponent implements OnInit {
  kadatas: any = [];  
  kadataForm: FormGroup;
  displayedColumns = ['kadtaQuantity', 'createdBy','action'];
  dataSource: MatTableDataSource<Kadata>;
  formSubmitted: boolean = false;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  kadata: Kadata = {
    id: '',
    kadtaQuantity: '',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };
  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;
  constructor(private kadataService:KadataService,
    private toastrService: ToastrService,
    private ngxSpinnerService: NgxSpinnerService,
    private formBuilder: FormBuilder) {
   this.paginator = this.kadatas;
   this.sort = this.kadatas;
   this.kadataForm = new FormGroup({});
   this.dataSource = new MatTableDataSource(this.kadatas);setTimeout(() => {
     this.kadataService.getAllKadatas().subscribe((kadatas) => {
       this.kadatas = kadatas;
       console.log(this.kadatas);
       this.dataSource = new MatTableDataSource(this.kadatas);
       this.dataSource.paginator = this.paginator;
       this.dataSource.sort = this.sort;
     });
   }, 1000);
  }

  ngOnInit(): void { setTimeout(()=> {
    this.ngxSpinnerService.hide();
  }, 1000);
  this.kadataForm = this.formBuilder.group({
    kadtaQuantity: ['', [Validators.required]],
  });
  }
  get formControl(): { [key: string]: AbstractControl } {
    return this.kadataForm.controls
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
  openModal(type:any, kadataObj:any) {
    this.formSubmitted = true;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.kadata = {} as Kadata;
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.kadata = kadataObj;
    }
  }
  closeModal() {
    this.showModal = false;
  }
  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.kadataService.deleteKadata(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      location.reload();
    }
  }
  submitForm(action: string, kadataObj: Kadata): void {
    this.formSubmitted = true;
    if (this.kadataForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(kadataObj);
    }
    if (action === 'Update') {
      this.updateRecord(kadataObj);
    }
  }
  createRecord(kadataObj: Kadata) {
    kadataObj.createdBy="nitingodase";
    this.kadataService.createKadata(kadataObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      location.reload();
    });
  }

  updateRecord(kadataObj: Kadata) {
    this.kadataService.createKadata(kadataObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      location.reload();
    });
  }
}
