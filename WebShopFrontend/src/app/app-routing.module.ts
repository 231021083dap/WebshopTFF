import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './Helpers/auth.guard';
import { Role } from './models';

import { HomeComponent } from './home/home.component';
import { ItemsComponent } from './items/items.component';
import { LoginComponent } from './Authentication/login/login.component';
import { RegisterComponent } from './Authentication/register/register.component';
import { MySiteComponent } from './User/my-site/my-site.component';
import { MyCartComponent } from './User/my-cart/my-cart.component';
import { AdministrationsSiteComponent } from './admin/administrations-site/administrations-site.component';
import { ItembyidComponent } from './itembyid/itembyid.component';
import { AdminUsersComponent } from './admin/admin-users/admin-users.component';
import { AdminSubCategoryComponent } from './admin/admin-sub-category/admin-sub-category.component';
import { AdminItemsComponent } from './admin/admin-items/admin-items.component';
import { AdminOrdersComponent } from './admin/admin-orders/admin-orders.component';


const routes: Routes = 
[
  { path : '', component: HomeComponent },
  { path : 'items', component: ItemsComponent },
  { path : 'authentication/login', component: LoginComponent },
  { path : 'authentication/register', component: RegisterComponent },
  { path : 'mysite', component: MySiteComponent  },
  { path : 'mycart', component: MyCartComponent },
  { path : 'item/:itemid', component: ItembyidComponent },
  { path : 'admin/adminsite', component: AdministrationsSiteComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.SuperUser] } },
  { path : 'admin/user', component: AdminUsersComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.SuperUser] }},
  { path : 'admin/subcategory', component: AdminSubCategoryComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.SuperUser] } },
  { path : 'admin/items', component: AdminItemsComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.SuperUser] }},
  { path : 'admin/orders', component: AdminOrdersComponent, canActivate: [AuthGuard], data: { roles: [Role.Admin, Role.SuperUser] }}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
