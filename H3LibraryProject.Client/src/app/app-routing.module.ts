import { AccountPageComponent } from './user/account-page/account-page.component';
import { MaterialDisplayComponent } from './user/material-display/material-display.component';
import { SearchMaterialComponent } from './user/search-material/search-material.component';
import { FrontpageComponent } from './user/frontpage/frontpage.component';
import { LoanComponent } from './admin/loan/loan.component';
import { MaterialComponent } from './admin/material/material.component';
import { TitleComponent } from './admin/title/title.component';
import { AuthorComponent } from './admin/author/author.component';
import { LoanerComponent } from './admin/loaner/loaner.component';
import { LocationComponent } from './admin/location/location.component';
import { PublisherComponent } from './admin/publisher/publisher.component';
import { LoanerTypeComponent } from './admin/loaner-type/loaner-type.component';
import { GenreComponent } from './admin/genre/genre.component';
import { NationalityComponent } from './admin/nationality/nationality.component';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LanguageComponent } from './admin/language/language.component';

const routes: Routes = [
  {path:"", component:FrontpageComponent},
  {path: "admin", component:AdminLayoutComponent},
  {path: "admin/nationality", component:NationalityComponent},
  {path: "admin/genre", component:GenreComponent},
  {path: "admin/language", component:LanguageComponent},
  {path: "admin/loanertype", component:LoanerTypeComponent},
  {path: "admin/publisher", component:PublisherComponent},
  {path: "admin/location", component:LocationComponent},
  {path: "admin/loaner", component:LoanerComponent},
  {path: "admin/author", component:AuthorComponent},
  {path: "admin/title", component:TitleComponent},
  {path: "admin/material", component:MaterialComponent},
  {path: "admin/loan", component:LoanComponent},
  {path: "material", component:SearchMaterialComponent},
  {path: "material/:id", component:MaterialDisplayComponent},
  {path: "account", component:AccountPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
