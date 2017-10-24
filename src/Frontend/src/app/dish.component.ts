import { Component, OnInit } from '@angular/core';

import { Dish } from "./dish";
import { DishService } from "./dish.service";

@Component({
    selector: 'dishes',
    templateUrl: './dish.component.html',
    styleUrls: ['./dish.component.css']
})
export class DishComponent implements OnInit {
    dishes: Dish[];

    constructor(private dishService: DishService) { }

    listDishes(): void {
        this.dishService
            .listDishes()
            .then(dishes => this.dishes = dishes);
    }

    deleteDish(dish: Dish): void {
        this.dishService
            .deleteDish(dish.Id)
            .then(() => this.dishes = this.dishes.filter(d => d !== dish));
    }

    ngOnInit(): void {
        this.listDishes();
    }
}
