import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { BambooCatalogComponent } from './bamboo-catalog/bamboo-catalog.component';
import { EllipsifyMeDirective } from './ellipsify-me.directive';
import { BambooAccountComponent } from './bamboo-account/bamboo-account.component';
import { BambooCartComponent } from './bamboo-cart/bamboo-cart.component';
import { BambooOrderDetailsComponent } from './bamboo-order-details/bamboo-order-details.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    BambooCatalogComponent,
    EllipsifyMeDirective,
    BambooAccountComponent,
    BambooCartComponent,
    BambooOrderDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'catalogs', component: BambooCatalogComponent },
      { path: 'accounts', component: BambooAccountComponent },
      { path: 'cart', component: BambooCartComponent },
      { path: 'orders', component: BambooOrderDetailsComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
