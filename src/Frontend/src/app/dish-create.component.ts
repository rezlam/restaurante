import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { Dish } from "./dish";
import { DishService } from "./dish.service";
import { Restaurant } from "./restaurant";
import { RestaurantService } from "./restaurant.service";

@Component({
    selector: 'dish-create',
    templateUrl: './dish-create.component.html',
    styleUrls: ['./dish-create.component.css']
})
export class DishCreateComponent implements OnInit {
    constructor(
        private dishService: DishService,
        private restaurantService: RestaurantService,
        private router: Router
    ) {}

    dish = new Dish();
    restaurants: Restaurant[];
    selectedRestaurantId: number;

    setSelectedRestaurant(id: number): void {
        this.dish.RestaurantId = id;
    }

    createDish(): void {
        console.log('Creating new dish');
        console.log('dish.RestaurantId: ' + this.dish.RestaurantId);
        this.dishService
            .createDish(this.dish)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.router.navigate(['/pratos']);
    }

    ngOnInit(): void {
        this.restaurantService
            .listRestaurants(null)
            .then(res => this.restaurants = res);
    }
}
