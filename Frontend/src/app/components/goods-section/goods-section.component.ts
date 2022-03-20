import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
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
  displayedColumns = ['goodName', 'createdBy','action'];
  dataSource: MatTableDataSource<Good>;
  showModal: boolean = false;
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
  
  constructor(private goodService:GoodService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService) {
    this.paginator = this.goods;
    this.sort = this.goods;
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
  openDialog(x:any, y:any) {
    console.log(y);
    this.showModal = true;
    if(x === 'Edit') {
      this.good = y;
    } else if(x === 'Create') {
      this.good = {} as Good;
    }
  } 
  
  closeDialog() {
    this.showModal = false;
  }

  deleteRecord(id: string): void {
    var result = confirm("Are you sure you want to delete ?");
    if(result) {
      this.goodService.deleteGood(id).subscribe();
      this.toastrService.error("Record Deleted...!");
      location.reload();
    }
  }

  createRecord(userObj: Good) {
    userObj.createdBy="nitingodase";
    this.goodService.createGood(userObj).subscribe(()=> {
      this.toastrService.success("Record Created...!");
      this.showModal = false;
      location.reload();
    });
  }

  updateRecord(userObj: Good) {
    this.goodService.createGood(userObj).subscribe(()=> {
      this.toastrService.info("Record Updated...!");
      this.showModal = false;
      location.reload();
    });
  }
}
