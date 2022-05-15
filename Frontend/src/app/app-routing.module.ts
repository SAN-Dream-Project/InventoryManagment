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
import { LabourRateSectionComponent } from './components/labour-rate-section/labour-rate-section.component';
import {PurchaseSectionComponent} from "./components/purchase-section/purchase-section.component";
import { SaleSectionComponent } from './components/sale-section/sale-section.component';
import { BharadaRateSectionComponent } from './components/bharada-rate-section/bharada-rate-section.component';
import { BharadaSaleComponent } from './components/bharada-sale/bharada-sale.component';
import { BharadaCreditComponent } from './components/bharada-credit/bharada-credit.component';
import {LanguageTranslationComponent} from "./components/demos/language-translation/language-translation.component";
import {
  GoodPurchaseAverageRateComponent
} from "./components/good-purchase-average-rate/good-purchase-average-rate.component";
import {AuthGuard} from "./services/auth.guard";

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home', component: MainComponent, canActivate: [AuthGuard] },
  { path: 'user-section', component: UserSectionComponent, canActivate: [AuthGuard] },
  { path: 'goods-section', component: GoodsSectionComponent, canActivate: [AuthGuard] },
  { path: 'employee-section', component: EmployeeSectionComponent, canActivate: [AuthGuard] },
  { path: 'goods-supplier-section', component: GoodsSupplierSectionComponent, canActivate: [AuthGuard] },
  { path: 'kadata-section', component: KadataSectionComponent, canActivate: [AuthGuard] },
  { path: 'labour-section', component: LabourSectionComponent, canActivate: [AuthGuard] },
  { path: 'retailer-section', component: RetailerSectionComponent, canActivate: [AuthGuard] },
  { path: 'stock-section', component: StockSectionComponent, canActivate: [AuthGuard] },
  { path: 'labour-rate-section', component: LabourRateSectionComponent, canActivate: [AuthGuard] },
  { path: 'purchase-section', component: PurchaseSectionComponent, canActivate: [AuthGuard] },
  { path: 'purchase-average-rate', component: GoodPurchaseAverageRateComponent, canActivate: [AuthGuard] },
  { path: 'sale-section', component: SaleSectionComponent, canActivate: [AuthGuard] },
  { path: 'bharada-rate-section', component: BharadaRateSectionComponent, canActivate: [AuthGuard] },
  { path: 'bharada-sale-section', component: BharadaSaleComponent, canActivate: [AuthGuard] },
  { path: 'bharada-credit-section', component: BharadaCreditComponent, canActivate: [AuthGuard] },
  { path: 'demos/table-data', component: DataTableComponent, canActivate: [AuthGuard] },
  { path: 'demos/language-translation', component: LanguageTranslationComponent, canActivate: [AuthGuard] },
  { path: '',   redirectTo: '/login', pathMatch: 'full' }, // redirect to `main-component`
  { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [AuthGuard]
})
export class AppRoutingModule { }
