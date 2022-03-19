import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from "./components/main/main.component";
import { UserSectionComponent } from "./components/user-section/user-section.component";
import { PageNotFoundComponent } from "./components/page-not-found/page-not-found.component";
import { LoginComponent } from "./components/login/login.component";
import { DataTableComponent } from "./components/demos/data-table/data-table.component";

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home', component: MainComponent },
  { path: 'user-section', component: UserSectionComponent },
  { path: 'demos/table-data', component: DataTableComponent },
  { path: '',   redirectTo: '/login', pathMatch: 'full' }, // redirect to `main-component`
  { path: '**', component: PageNotFoundComponent },  // Wildcard route for a 404 page
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
