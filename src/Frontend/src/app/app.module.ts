import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";

import { AppComponent } from './app.component';
import { HomeComponent } from './home.component';
import { NavbarComponent } from "./navbar.component";
import { RestaurantComponent } from "./restaurant.component";
import { DishComponent } from "./dish.component";
import { RestaurantService } from "./restaurant.service";
import { DishService } from "./dish.service";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    RestaurantComponent,
    DishComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'restaurantes', component: RestaurantComponent },
      { path: 'pratos', component: DishComponent },
      { path: '**', redirectTo: 'home' }
    ]),
    FormsModule,
    HttpModule
  ],
  providers: [RestaurantService, DishService],
  bootstrap: [AppComponent]
})
export class AppModule { }
