import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, forwardRef } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {


 private productUrl = environment.apiUrl+"/product";
 private CategoryURL = environment.apiUrl+"/category";
 private AccountURL = environment.apiUrl+"/Account";
  constructor(private http: HttpClient ) {


   }

  getCategory(): Observable<any> {
    return this.http.get<any[]>(`${this.CategoryURL}/GetAll`);
  }

  getCategoryById(id: number): Observable<any> {
    return this.http.get<any>(`${this.CategoryURL}/GetById/?Id=${id}`);
  }

  AddOrUpdateCategory(product: any): Observable<any> {
    return this.http.post<any>(`${this.CategoryURL}/AddOrUpdate`, product);
  }

  deleteCategory(id: number): Observable<any> {
    return this.http.delete<any>(`${this.CategoryURL}/Delete/?Id=${id}`);
  }



  ////// Products

  getProducts(): Observable<any> {
    return this.http.get<any[]>(`${this.productUrl}/GetAll`);
  }

  getProductById(id: number): Observable<any> {
    return this.http.get<any>(`${this.productUrl}/GetById/?Id=${id}`);
  }

  AddOrUpdate(product: any): Observable<any> {
    return this.http.post<any>(`${this.productUrl}/AddOrUpdate`, product);
  }

  deleteProduct(id: number): Observable<any> {
    return this.http.delete<any>(`${this.productUrl}/Delete/?Id=${id}`);
  }


  Login(modle : any): Observable<any> {
    return this.http.post<any>(`${this.AccountURL}/login`,modle);
  }

  Register(modle : any): Observable<any> {
    return this.http.post<any>(`${this.AccountURL}/Register`,modle);
  }
}
