import { Injectable } from '@angular/core';
import { ProductServiceService } from '../Product/product-service.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

    private loggedIn = false;


    constructor(


    ) { }






    logout(): void {
      this.loggedIn = false;
      localStorage.removeItem('isLoggedIn');
      localStorage.removeItem('Profile');
    }

    isLoggedIn(): boolean {
      return this.loggedIn || localStorage.getItem('isLoggedIn') === 'true';
    }
  }
