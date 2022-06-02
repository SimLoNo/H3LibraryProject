import { LoanerTypeComponent } from './admin/loaner-type/loaner-type.component';
import { GenreComponent } from './admin/genre/genre.component';
import { NationalityComponent } from './admin/nationality/nationality.component';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LanguageComponent } from './admin/language/language.component';

const routes: Routes = [
  {path:"", component:NationalityComponent},
  {path: "admin", component:AdminLayoutComponent},
  {path: "admin/nationality", component:NationalityComponent},
  {path: "admin/genre", component:GenreComponent},
  {path: "admin/language", component:LanguageComponent},
  {path: "admin/loanertype", component:LoanerTypeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
