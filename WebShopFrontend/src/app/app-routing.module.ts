import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ItemsComponent } from './items/items.component';
import { LoginComponent } from './Authentication/login/login.component';
import { RegisterComponent } from './Authentication/register/register.component';
import { OrdersComponent } from './orders/orders.component';
import { MySiteComponent } from './my-site/my-site.component';
import { MyCartComponent } from './my-cart/my-cart.component';
import { AdministrationsSiteComponent } from './admin/administrations-site/administrations-site.component';

const routes: Routes = 
[
  { path : '', component: HomeComponent },
  { path : 'items', component: ItemsComponent },
  { path : 'Authentication/Login', component: LoginComponent },
  { path : 'Authentication/Register', component: RegisterComponent },
  { path : 'MySite', component: MySiteComponent  },
  { path : 'MyCart', component: MyCartComponent },
  { path : 'Orders', component: OrdersComponent },
  { path : 'Admin/AdminSite', component: AdministrationsSiteComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
