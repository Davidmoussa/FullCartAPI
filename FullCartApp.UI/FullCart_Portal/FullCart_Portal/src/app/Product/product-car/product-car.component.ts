import { ProductServiceService } from 'src/app/Product/product-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product-car',
  templateUrl: './product-car.component.html',

})
export class ProductCarComponent implements OnInit {

  constructor(
   private _Service:ProductServiceService

  ) { }

   Products: any []= [];

  ngOnInit(): void {

    this.getCarItem()
  }


  getCarItem(){
    var  CarItem =  localStorage.getItem('userCart')??"";

    CarItem.split(',').forEach(element => {
      console.log(element)
      this.getProductById(element)
    })

  }
  getProductById(id:any){
    this._Service.getProductById(id).subscribe(res=>{
      if(res.data){
        this.Products.push(res.data)
      }
    })
  }



}
