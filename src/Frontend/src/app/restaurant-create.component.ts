import { Component } from '@angular/core';
import { Router } from "@angular/router";

import { Restaurant } from './restaurant';
import { RestaurantService } from "./restaurant.service";

@Component({
    selector: 'restaurant-create',
    templateUrl: './restaurant-create.component.html',
    styleUrls: ['./restaurant-create.component.css']
})
export class RestaurantCreateComponent {
    constructor(
        private restaurantService: RestaurantService,
        private router: Router) {}

    restaurant = new Restaurant();

    createRestaurant(): void {
        console.log('Creating new restaurant');
        this.restaurantService
            .createRestaurant(this.restaurant)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.router.navigate(['/restaurantes']);
    }
}
