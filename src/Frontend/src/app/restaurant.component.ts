import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { Restaurant } from './restaurant';
import { RestaurantService } from "./restaurant.service";

@Component({
    selector: 'restaurants',
    templateUrl: './restaurant.component.html',
    styleUrls: ['./restaurant.component.css']
})
export class RestaurantComponent {
    restaurants: Restaurant[];
    searchQuery: string;

    constructor(
        private restaurantService: RestaurantService,
        private router: Router) {}

    listRestaurants(): void {
        this.restaurantService
            .listRestaurants(this.searchQuery)
            .then(restaurants => this.restaurants = restaurants);
    }

    deleteRestaurant(restaurant: Restaurant): void {
        this.restaurantService
            .deleteRestaurant(restaurant.Id)
            .then(() => this.restaurants = this.restaurants.filter(r => r !== restaurant));
    }
}
