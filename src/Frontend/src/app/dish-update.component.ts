import { Component, OnInit, OnDestroy } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";

import { Dish } from "./dish";
import { DishService } from "./dish.service";

@Component({
    selector: 'dish-update',
    templateUrl: './dish-update.component.html',
    styleUrls: ['./dish-update.component.css']
})
export class DishUpdateComponent {
    constructor(
        private dishService: DishService,
        private router: Router,
        private route: ActivatedRoute
    ) {}

    private sub: any;
    dish: Dish;

    updateDish(): void {
        console.log('Updating dish');
        this.dishService
            .updateDish(this.dish)
            .then(() => this.goBack());
    }

    goBack(): void {
        this.router.navigate(['/pratos']);
    }

    ngOnInit(): void {
        this.sub = this.route.params.subscribe(params => {
            this.dishService
                .showDish(+params['id'])
                .then(res => this.dish = res);
        })
    }

    ngOnDestroy(): void {
        this.sub.unsubscribe();
    }
}
