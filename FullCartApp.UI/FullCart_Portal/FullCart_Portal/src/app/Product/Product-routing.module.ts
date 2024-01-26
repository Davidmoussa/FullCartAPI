import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductRoute } from './ProductRoute';
import { MatTableModule } from '@angular/material/table';
import { ProductServiceService } from './product-service.service';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { AgGridModule } from '@ag-grid-community/angular';
import { ProductAddOrUpdateComponent } from './product-add-or-update/product-add-or-update.component';





export const ProductRoutes: Routes = [
  {
      path: ``,
      children: [
          {
            path: `${ProductRoute.listRoute}`,
            component: ProductListComponent,
          }
      ],
  },

];


@NgModule({
  declarations: [
    ProductListComponent,
    ProductAddOrUpdateComponent
  ],
  imports: [
    BrowserModule,
    MatTableModule,
    CommonModule,
    FormsModule,
    RouterModule,
    HttpClientModule,
    AgGridModule,

  ],
  providers: [ProductServiceService],
  exports: [
    ProductListComponent,
    ProductAddOrUpdateComponent
 ]
})
export class ProductRoutingmodule { }
