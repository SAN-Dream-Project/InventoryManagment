import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from "./components/main/main.component";
import { UserSectionComponent } from "./components/user-section/user-section.component";
import { PageNotFoundComponent } from "./components/page-not-found/page-not-found.component";
import { LoginComponent } from "./components/login/login.component";
import { DataTableComponent } from "./components/demos/data-table/data-table.component";
import { GoodsSectionComponent } from './components/goods-section/goods-section.component';
import { EmployeeSectionComponent } from './components/employee-section/employee-section.component';
import { GoodsSupplierSectionComponent } from './components/goods-supplier-section/goods-supplier-section.component';
import { KadataSectionComponent } from './components/kadata-section/kadata-section.component';
import { LabourSectionComponent } from './components/labour-section/labour-section.component';
import { RetailerSectionComponent } from './components/retailer-section/retailer-section.component';
import { StockSectionComponent } from './components/stock-section/stock-section.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home', component: MainComponent },
  { path: 'user-section', component: UserSectionComponent },
  { path: 'demos/table-data', component: DataTableComponent },
  { path: 'goods-section', component: GoodsSectionComponent },
  { path: 'employee-section', component: EmployeeSectionComponent },
  { path: 'goods-supplier-section', component: GoodsSupplierSectionComponent },
  { path: 'kadata-section', component: KadataSectionComponent },
  { path: 'labour-section', component: LabourSectionComponent },
  { path: 'retailer-section', component: RetailerSectionComponent },
  { path: 'stock-section', component: StockSectionComponent },
  { path: '',   redirectTo: '/login', pathMatch: 'full' }, // redirect to `main-component`
  { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
