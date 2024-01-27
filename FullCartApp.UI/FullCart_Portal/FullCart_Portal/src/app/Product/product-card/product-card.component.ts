
import { Component, Input } from '@angular/core';
import { ProductNameSpace } from '../Product.module';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',

})
export class ProductCardComponent {

  @Input() public productmodel!: ProductNameSpace.Product;
  constructor() { }

  ngOnInit(): void {
  }



  addToCart() {
    var  userCart =  localStorage.getItem('userCart')??"";
    userCart= `${userCart}${this.productmodel.id},`
    localStorage.setItem('userCart',userCart )
  }
}
