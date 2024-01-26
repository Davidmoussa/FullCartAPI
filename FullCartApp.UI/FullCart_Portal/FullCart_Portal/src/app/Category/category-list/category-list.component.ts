import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductNameSpace } from 'src/app/Product/Product.module';
import { ProductServiceService } from 'src/app/Product/product-service.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',

})
export class CategoryListComponent implements OnInit {


  public  dataSource : any[] = [];
  expandedElement: any =  ProductNameSpace.Product  ;


  EditRouterURL : any  = "/category/edit"

   constructor(
          private  _productService: ProductServiceService,
          private router: Router
       ) { }
   ngOnInit(): void {
     this.setDate();
   }

   setDate(){
     this._productService.getCategory().subscribe(res => {
       if (res.data) {
         this.dataSource =[];
         this.dataSource = res.data;
         console.log(this.dataSource );
       }

     });
   }


   openModal(item:any ){
     this.router.navigate([`${this.EditRouterURL}/${item.id}`]);
   }



   Deleteitem(item:any ){
    this._productService.deleteCategory(item.id).subscribe(res => {
      if (res.data) {
        this.setDate()
      }

    });
  }


  }


