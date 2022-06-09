import { NgModule, Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormControl } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './admin/admin-layout/admin-layout.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
//import { SelectBound}
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { NationalityComponent } from './admin/nationality/nationality.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GenreComponent } from './admin/genre/genre.component';
import { LanguageComponent } from './admin/language/language.component';
import { LoanerTypeComponent } from './admin/loaner-type/loaner-type.component';
import { PublisherComponent } from './admin/publisher/publisher.component';
import { LocationComponent } from './admin/location/location.component';
import { LoanerComponent } from './admin/loaner/loaner.component';
import { AuthorComponent } from './admin/author/author.component';
import { MatListModule} from '@angular/material/list';
import { TitleComponent } from './admin/title/title.component';
import { MaterialComponent } from './admin/material/material.component'
import { MatCheckboxModule} from '@angular/material/checkbox';
import { LoanComponent } from './admin/loan/loan.component';
import { FrontpageComponent } from './user/frontpage/frontpage.component';
import { SearchMaterialComponent } from './user/search-material/search-material.component';
import { MaterialDisplayComponent } from './user/material-display/material-display.component';
import { AccountPageComponent } from './user/account-page/account-page.component';


@NgModule({
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    NationalityComponent,
    GenreComponent,
    LanguageComponent,
    LoanerTypeComponent,
    PublisherComponent,
    LocationComponent,
    LoanerComponent,
    AuthorComponent,
    TitleComponent,
    MaterialComponent,
    LoanComponent,
    FrontpageComponent,
    SearchMaterialComponent,
    MaterialDisplayComponent,
    AccountPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatSelectModule,
    MatListModule,
    MatCheckboxModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
