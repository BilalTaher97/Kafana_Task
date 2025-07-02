import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
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



@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
