
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductRoute } from './Product/ProductRoute';
import { ProductListComponent } from './Product/product-list/product-list.component';
import { ProductAddOrUpdateComponent } from './Product/product-add-or-update/product-add-or-update.component';
import { CategoryListComponent } from './Category/category-list/category-list.component';
import { CategoryAddOrUpdateComponent } from './Category/category-add-or-update/category-add-or-update.component';
import { LoginComponent } from './Account/login/login.component';
import { AuthGuard } from './Account/AuthGuard';
import { RegisterComponent } from './Account/register/register.component';
import { ProductShopComponent } from './Product/product-shop/product-shop.component';
import { ProductCarComponent } from './Product/product-car/product-car.component';

const routes: Routes = [
  {
    path: `${ProductRoute.baseRoute}`,
    children:[
      { path: ``, component:ProductShopComponent },
      { path: `car`, component:ProductCarComponent },
      { path: `${ProductRoute.listRoute}`, component:ProductListComponent ,canActivate: [AuthGuard]},
      { path: `${ProductRoute.addRoute}`, component:ProductAddOrUpdateComponent,canActivate: [AuthGuard] },
      { path: `${ProductRoute.editRoute}/:id`, component:ProductAddOrUpdateComponent ,canActivate: [AuthGuard]},
   ]

  },

  {
    path: `category`,
    children:[
      { path: ``, component: CategoryListComponent,canActivate: [AuthGuard]},
      { path: `${ProductRoute.listRoute}`, component:CategoryListComponent,canActivate: [AuthGuard] },
      { path: `${ProductRoute.addRoute}`, component:CategoryAddOrUpdateComponent,canActivate: [AuthGuard] },
      { path: `${ProductRoute.editRoute}/:id`, component:CategoryAddOrUpdateComponent,canActivate: [AuthGuard] },
   ]

  },

  {
    path: `account`,
    children:[
      { path: `login`, component: LoginComponent},
      { path: `register`, component: RegisterComponent},

   ]

  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes,{
    useHash: true, scrollPositionRestoration: 'top',
    onSameUrlNavigation: 'reload', relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
