import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { loginVM } from './loginvm';
import { ProductServiceService } from 'src/app/Product/product-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit {

  loginVM: any  = new  loginVM;


  constructor(
    private router: Router,
    private _service:ProductServiceService
  ) { }

  ngOnInit(): void {
  }



  login(): void {
    this._service.Login(this.loginVM).subscribe(res=>{
      if (res.data){
        console.log(res.date);
        localStorage.setItem('Profile',res.data );
        localStorage.setItem('isLoggedIn',"true");
        this.router.navigate(['/product'])
      }
    })
  }
}
