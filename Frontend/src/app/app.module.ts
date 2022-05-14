import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { ToastrModule } from 'ngx-toastr';
import { HeaderComponent } from './components/header/header.component';
import { MainComponent } from './components/main/main.component';
import { FooterComponent } from './components/footer/footer.component';
import { UserSectionComponent } from './components/user-section/user-section.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { LoginComponent } from './components/login/login.component';
import { DataTableComponent } from './components/demos/data-table/data-table.component';
import {MaterialModule} from "./material/material.module";
import { GoodsSectionComponent } from './components/goods-section/goods-section.component';
import { KadataSectionComponent } from './components/kadata-section/kadata-section.component';
import { LabourSectionComponent } from './components/labour-section/labour-section.component';
import { RetailerSectionComponent } from './components/retailer-section/retailer-section.component';
import { GoodsSupplierSectionComponent } from './components/goods-supplier-section/goods-supplier-section.component';
import { EmployeeSectionComponent } from './components/employee-section/employee-section.component';
import { LabourRateSectionComponent } from './components/labour-rate-section/labour-rate-section.component';
import { StockSectionComponent } from './components/stock-section/stock-section.component';
import { PurchaseSectionComponent } from './components/purchase-section/purchase-section.component';
import { SaleSectionComponent } from './components/sale-section/sale-section.component';
import { BharadaRateSectionComponent } from './components/bharada-rate-section/bharada-rate-section.component';
import { BharadaSaleComponent } from './components/bharada-sale/bharada-sale.component';
import { BharadaCreditComponent } from './components/bharada-credit/bharada-credit.component';
import { LanguageTranslationComponent } from './components/demos/language-translation/language-translation.component';
import {LanguageInterceptor} from "./interceptors/language.interceptor";
import { GoodPurchaseAverageRateComponent } from './components/good-purchase-average-rate/good-purchase-average-rate.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MainComponent,
    FooterComponent,
    UserSectionComponent,
    PageNotFoundComponent,
    LoginComponent,
    DataTableComponent,
    GoodsSectionComponent,
    KadataSectionComponent,
    LabourSectionComponent,
    RetailerSectionComponent,
    GoodsSupplierSectionComponent,
    EmployeeSectionComponent,
    LabourRateSectionComponent,
    StockSectionComponent,
    PurchaseSectionComponent,
    SaleSectionComponent,
    BharadaRateSectionComponent,
    BharadaSaleComponent,
    BharadaCreditComponent,
    LanguageTranslationComponent,
    GoodPurchaseAverageRateComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    NgxSpinnerModule,
    HttpClientModule,
    ToastrModule.forRoot({
      timeOut: 3000,
      positionClass: 'toast-bottom-left',
      preventDuplicates: true
    }),
    FormsModule,
    ReactiveFormsModule,
    MaterialModule
  ],
  entryComponents: [DataTableComponent],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LanguageInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

platformBrowserDynamic().bootstrapModule(AppModule);
