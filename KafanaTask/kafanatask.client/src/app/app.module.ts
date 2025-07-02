import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SidebarComponent } from './Admin/sidebar/sidebar.component';
import { ProductListComponent } from './Admin/product-list/product-list.component';
import { CustomerListComponent } from './Admin/customer-list/customer-list.component';
import { OrderListComponent } from './Admin/order-list/order-list.component';
import { FormsModule } from '@angular/forms';
import { AddProductComponent } from './Admin/add-product/add-product.component';

@NgModule({
  declarations: [
    AppComponent,
    SidebarComponent,
    CustomerListComponent,
    ProductListComponent,
    OrderListComponent,
    AddProductComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule 
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
