import { Component, OnInit } from '@angular/core';
import { ProductServiceService } from '../product-service.service';
import { ProductNameSpace } from '../Product.module';

@Component({
  selector: 'app-product-shop',
  templateUrl: './product-shop.component.html',

})
export class ProductShopComponent implements OnInit {

  public  dataSource : ProductNameSpace.Product[] = [];

  constructor(
    private _productService : ProductServiceService
  ) { }

  ngOnInit(): void {
    this.setDate()
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


}
