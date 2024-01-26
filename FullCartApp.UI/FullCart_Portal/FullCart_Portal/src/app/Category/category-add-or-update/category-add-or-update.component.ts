import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductNameSpace } from 'src/app/Product/Product.module';
import { ProductRoute } from 'src/app/Product/ProductRoute';
import { ProductServiceService } from 'src/app/Product/product-service.service';

@Component({
  selector: 'app-category-add-or-update',
  templateUrl: './category-add-or-update.component.html',

})
export class CategoryAddOrUpdateComponent implements OnInit {

  public category: any = new ProductNameSpace.Category();
  categoryId :number =0 ;




  constructor(private route: ActivatedRoute,
    private  _productService: ProductServiceService,
    private router: Router)
    {

      this.categoryId = parseInt(this.route.snapshot.paramMap.get('id')??"0", 0);
      if (this.categoryId!=0){
        this.GetData();
      }

  }



  ngOnInit(): void {

  }


  onSubmit(): void {
    this._productService.AddOrUpdateCategory(this.category).subscribe(res=>{
      if (res.data){
        this.router.navigate([`category/${ProductRoute.listRoute}`]);
      }else{


      }
      })
    console.log(this.category);
  }

  GetData(){
    this._productService.getCategoryById(this.categoryId).subscribe(res=>{
    if (res.data){
      this.category=res.data;
    }
    })
  }

}
