import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from "@angular/router";

import { Restaurant } from './restaurant';
import { RestaurantService } from "./restaurant.service";

@Component({
    selector: 'restaurant-update',
    templateUrl: './restaurant-update.component.html',
    styleUrls: ['./restaurant-update.component.css']
})
export class RestaurantUpdateComponent implements OnInit, OnDestroy {
    constructor(
        private restaurantService: RestaurantService,
        private router: Router,
        private route: ActivatedRoute) { }

    private sub: any;
    restaurant: Restaurant;

    updateRestaurant(): void {
        console.log('Updating restaurant');
        this.restaurantService
            .updateRestaurant(this.restaurant)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.router.navigate(['/restaurantes']);
    }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(params => {
            this.restaurantService
                .showRestaurant(+params['id'])
                .then(res => this.restaurant = res);
        })
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }
}
