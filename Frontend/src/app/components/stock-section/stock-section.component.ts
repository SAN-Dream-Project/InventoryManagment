import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Stock } from 'src/app/models/Stock';
import { StockService } from 'src/app/services/stock.service';

@Component({
  selector: 'app-stock-section',
  templateUrl: './stock-section.component.html',
  styleUrls: ['./stock-section.component.less']
})
export class StockSectionComponent implements OnInit {
  stocks:any = [];
  displayedColumns = ['goodName', 'quantity'];
  dataSource: MatTableDataSource<Stock>;
  showModal: boolean = false;
  buttonStatus: any = {
    saveButton: false,
    updateButton: false
  };
  @ViewChild(MatPaginator) paginator: MatPaginator | null;
  @ViewChild(MatSort) sort: MatSort | null;

  constructor(private stockService: StockService, private toastrService: ToastrService, private ngxSpinnerService: NgxSpinnerService) {
    this.paginator = this.stocks;
    this.sort = this.stocks;
    this.dataSource = new MatTableDataSource(this.stocks);
    /*for (let i = 1; i <= 100; i++) { this.users.push(createNewUser(i)); }*/
    // Assign the data to the data source for the table to render
    setTimeout(() => {
      this.stockService.getAllStocks().subscribe((stocks) => {
        this.stocks = stocks;
        this.dataSource = new MatTableDataSource(this.stocks);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      });
    }, 1000);
  }

  ngOnInit(): void {
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

}
