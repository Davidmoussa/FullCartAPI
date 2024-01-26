import { ProductNameSpace } from '../Product.module';

import { Component, OnInit } from '@angular/core';
import { ProductServiceService } from '../product-service.service';
import { Router } from '@angular/router';
import { combineLatest } from 'rxjs';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',

})
export class ProductListComponent implements OnInit {

 public  dataSource : any[] = [];
 expandedElement: any =  ProductNameSpace.Product  ;
 Categoryoptions: any [] = [] ;

 EditRouterURL : any  = "/product/edit"

  constructor(
         private  _productService: ProductServiceService,
         private router: Router
      ) {
        this.loadLookups ();
      }





  ngOnInit(): void {
    this.setDate();

  }


  setDate(){
    this._productService.getProducts().subscribe(res => {
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





  getcategoryName (id:any):string{
    return this.Categoryoptions.find(i=>i.id==id)?.name??"-"
  }


  loadLookups() {
    let sources = [
      this._productService.getCategory(),
    ];
    combineLatest(sources).subscribe(response => {
      this.Categoryoptions= response[0].data
    },
      err => console.log('Error:', err),
      () => console.log('Completed'));
  }


  Deleteitem(item:any ){
    this._productService.deleteProduct(item.id).subscribe(res => {
      if (res.data) {
        this.setDate()
      }

    });
  }

}
