import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // أضف هذا الاستيراد

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
<<<<<<< HEAD
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import { ShowOrdersComponent } from './show-orders/show-orders.component';
=======
import { SidebarComponent } from './Admin/sidebar/sidebar.component';
import { ProductListComponent } from './Admin/product-list/product-list.component';
import { CustomerListComponent } from './Admin/customer-list/customer-list.component';
import { OrderListComponent } from './Admin/order-list/order-list.component';
import { FormsModule } from '@angular/forms';
import { AddProductComponent } from './Admin/add-product/add-product.component';
import { CreateOrdersComponent } from './create-orders/create-orders.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
>>>>>>> a2d9b71c87ae60516c30dcab90009942fa165fb0

@NgModule({
  declarations: [
    AppComponent,
<<<<<<< HEAD
    RegisterComponent,
    LoginComponent,
    ProductsComponent,
    ShowOrdersComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule
=======
    SidebarComponent,
    CustomerListComponent,
    ProductListComponent,
    OrderListComponent,
    AddProductComponent,
    CreateOrdersComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot()
>>>>>>> a2d9b71c87ae60516c30dcab90009942fa165fb0
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
