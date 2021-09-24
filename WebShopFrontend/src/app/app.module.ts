import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './Helpers/jwt.interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ItemsComponent } from './items/items.component';
import { FooterComponent } from './general/footer/footer.component';
import { HeaderComponent } from './general/header/header.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './Authentication/login/login.component';
import { RegisterComponent } from './Authentication/register/register.component';
import { AdministrationsSiteComponent } from './admin/administrations-site/administrations-site.component';
import { MySiteComponent } from './User/my-site/my-site.component';
import { MyCartComponent } from './User/my-cart/my-cart.component';
import { FormsModule } from '@angular/forms';
import { AdminSubCategoryComponent } from './admin/admin-sub-category/admin-sub-category.component';
import { AdminOrdersComponent } from './admin/admin-orders/admin-orders.component';
import { AdminUsersComponent } from './admin/admin-users/admin-users.component';
import { AdminItemsComponent } from './admin/admin-items/admin-items.component';
import { ItembyidComponent } from './itembyid/itembyid.component';


@NgModule({
  declarations: [
    AppComponent,
    ItemsComponent,
    FooterComponent,
    HeaderComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    AdministrationsSiteComponent,
    MySiteComponent,
    MyCartComponent,
    AdminSubCategoryComponent,
    AdminOrdersComponent,
    AdminUsersComponent,
    AdminItemsComponent,
    ItembyidComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
