import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ItemsComponent } from './items/items.component';
import { LoginComponent } from './Authentication/login/login.component';
import { RegisterComponent } from './Authentication/register/register.component';
const routes: Routes = 
[
  { path : '', component: HomeComponent },
  { path : 'items', component: ItemsComponent },
  { path : 'Authentication/Login', component: LoginComponent },
  { path : 'Authentication/Register', component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
