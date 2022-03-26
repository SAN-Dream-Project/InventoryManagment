import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Good } from 'src/app/models/Good';
import { GoodService } from 'src/app/services/good.service';

@Component({
  selector: 'app-goods-section',
  templateUrl: './goods-section.component.html',
  styleUrls: ['./goods-section.component.less']
})
export class GoodsSectionComponent implements OnInit, AfterViewInit {
  goods: any = [];
  goodForm: FormGroup;
  displayedColumns = ['goodName', 'createdBy','action'];
  dataSource: MatTableDataSource<Good>;
  formSubmitted: boolean = false;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  good: Good = {
    id: '',
    goodName: '',
    createdBy: '',
    createdDate: '',
    modifiedBy: '',
    modifiedDate: ''
  };

  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private goodService:GoodService,
     private toastrService: ToastrService,
     private ngxSpinnerService: NgxSpinnerService,
     private formBuilder: FormBuilder) {
    this.paginator = this.goods;
    this.sort = this.goods;
    this.goodForm = new FormGroup({});
    this.dataSource = new MatTableDataSource(this.goods);setTimeout(() => {
      this.goodService.getAllGoods().subscribe((goods) => {
        this.goods = goods;
        console.log(this.goods);
        this.dataSource = new MatTableDataSource(this.goods);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000);
   }

  ngOnInit(): void {this.ngxSpinnerService.show();
    setTimeout(()=> {
      this.ngxSpinnerService.hide();
    }, 1000);
    this.goodForm = this.formBuilder.group({
      goodName: ['', [Validators.required]]
    });
  }

  get formControl(): { [key: string]: AbstractControl } {
    return this.goodForm.controls
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

  openModal(type:any, goodObj:any) {
    this.formSubmitted = false;
    if (type === 'Create') {
      this.showModal = true;
      this.buttonStatus.saveButton = true;
      this.buttonStatus.updateButton = false;
      this.good = {} as Good;
    } else {
      this.showModal = true;
      this.buttonStatus.updateButton = true;
      this.buttonStatus.saveButton = false;
      this.good = goodObj;
    }
  }

  closeModal() {
    this.showModal = false;
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.goodService.deleteGood(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      setTimeout(() => {
        location.reload();
      }, 1000);
    }
  }

  submitForm(action: string, userObj: Good): void {
    this.formSubmitted = true;
    if (this.goodForm.invalid) {
      return;
    }
    if (action === 'Create') {
      this.createRecord(userObj);
    }
    if (action === 'Update') {
      this.updateRecord(userObj);
    }
  }

  hasError: boolean = false;

  checkIfProductDuplicate(goodName: any) {
    this.goods.map((goods: any) => {
      if(goods.goodName === goodName) {
        this.good.goodName = '';
        this.hasError = true;
      }
    });
  }

  createRecord(userObj: Good) {
    userObj.createdBy="nitingodase";
    this.goodService.createGood(userObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }

  updateRecord(userObj: Good) {
    this.goodService.createGood(userObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      setTimeout(() => {
        location.reload();
      }, 1000);
    });
  }
}
