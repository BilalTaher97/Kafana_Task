import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { ProductsComponent } from './products/products.component';
import { ShowOrdersComponent } from './show-orders/show-orders.component';

const routes: Routes = [
  { path: '', redirectTo: '/Login', pathMatch: 'full' },
  { path: "Login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "products", component: ProductsComponent },
  { path: 'ShowOrders/:id', component: ShowOrdersComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

  
}
