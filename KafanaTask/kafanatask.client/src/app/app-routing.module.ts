import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
<<<<<<< HEAD
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
=======
import { SidebarComponent } from './Admin/sidebar/sidebar.component';
import { CustomerListComponent } from './Admin/customer-list/customer-list.component';
import { ProductListComponent } from './Admin/product-list/product-list.component';
import { OrderListComponent } from './Admin/order-list/order-list.component';


const routes: Routes = [
  {
    path: "admin",
    component: SidebarComponent,
    children: [
      { path: "", redirectTo: "customers", pathMatch: "full" }, 
      { path: "customers", component: CustomerListComponent },
      { path: "products", component: ProductListComponent },
      { path: "orders", component: OrderListComponent }
    ]
  },
  // ✅ هذا ضروري لتحويل الجذر "/" إلى /admin
  {
    path: '',
    redirectTo: 'admin',
    pathMatch: 'full'
  },
  // ✅ وهذا لمسارات غلط
  {
    path: '**',
    redirectTo: 'admin'
  }
];


>>>>>>> a2d9b71c87ae60516c30dcab90009942fa165fb0

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

  
}
