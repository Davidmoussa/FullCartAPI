import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductRoutingmodule } from './Product/Product-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { ModuleRegistry } from '@ag-grid-community/core';
import { ProductListComponent } from './Product/product-list/product-list.component';
import { FormsModule } from '@angular/forms';

import { CategoryListComponent } from './Category/category-list/category-list.component';
import { CategoryAddOrUpdateComponent } from './Category/category-add-or-update/category-add-or-update.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './Account/register/register.component';
import { ProductCardComponent } from './Product/product-card/product-card.component';
@NgModule({
  declarations: [
    AppComponent,
    CategoryListComponent,

    CategoryAddOrUpdateComponent,
     LoginComponent,
     RegisterComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ProductRoutingmodule,
    MatTableModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
