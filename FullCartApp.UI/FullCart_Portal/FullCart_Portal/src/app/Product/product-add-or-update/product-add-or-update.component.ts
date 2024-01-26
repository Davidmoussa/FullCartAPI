import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductNameSpace } from '../Product.module';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductServiceService } from '../product-service.service';
import { ProductRoute } from '../ProductRoute';


@Component({
  selector: 'app-product-add-or-update',
  templateUrl: './product-add-or-update.component.html',

})
export class ProductAddOrUpdateComponent   implements OnInit {

  public product: any = new ProductNameSpace.Product();
   productId :number =0 ;

   Categoryoptions:any[]=[]


  constructor(private route: ActivatedRoute,
    private  _productService: ProductServiceService,
    private router: Router)
    {

      this.productId = parseInt(this.route.snapshot.paramMap.get('id')??"0", 0);
      if (this.productId!=0){
        this.GetData();
      }

  }



  ngOnInit(): void {
    this.lookup()
  }


  onSubmit(): void {
    this._productService.AddOrUpdate(this.product).subscribe(res=>{
      if (res.data){
        this.router.navigate([`${ProductRoute.baseRoute}/${ProductRoute.listRoute}`]);
      }else{


      }
      })
    console.log(this.product);
  }

  GetData(){
    this._productService.getProductById(this.productId).subscribe(res=>{
    if (res.data){
      this.product=res.data;
    }
    })
  }


  lookup(){
    this._productService.getCategory().subscribe(res=>{
      if (res.data){
       this.Categoryoptions= res.data
      }
    });
  }

}
