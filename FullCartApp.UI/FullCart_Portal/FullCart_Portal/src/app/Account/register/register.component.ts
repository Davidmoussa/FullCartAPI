import { ProductServiceService } from 'src/app/Product/product-service.service';
import { Component, OnInit } from '@angular/core';
import { RegisterVM } from './RegisterVM';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',

})
export class RegisterComponent implements OnInit {

  Registervm :any = new RegisterVM();
  constructor(
    private _Service :ProductServiceService,
    private router:Router
  ) { }

  ngOnInit(): void {
  }
  register(): void {

    this._Service.Register(this.Registervm).subscribe(res=>{
      if(res.data){
        localStorage.setItem('Profile',res.data );
        localStorage.setItem('isLoggedIn',"true");
        this.router.navigate(['/product'])
      }

    })

  }
}
