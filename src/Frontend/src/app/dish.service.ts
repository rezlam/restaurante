import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import { Dish } from "./dish";

@Injectable()
export class DishService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private baseUrl = 'http://localhost:63979/dishes';

    constructor(private http: Http) {
    }

    listDishes(): Promise<Dish[]> {
        return this.http
                   .get(this.baseUrl, { headers: this.headers })
                   .toPromise()
                   .then(res => res.json() as Dish[])
                   .catch(this.handlesError);
    }

    createDish(dto: Dish): Promise<Dish> {
        return this.http
                   .post(this.baseUrl, JSON.stringify(dto), { headers: this.headers })
                   .toPromise()
                   .then(res => res.json() as Dish)
                   .catch(this.handlesError);
    }

    showDish(id: number): Promise<Dish> {
        const endpoint = `${this.baseUrl}/${id}`;
        return this.http
                   .get(endpoint, { headers: this.headers })
                   .toPromise()
                   .then(res => res.json() as Dish)
                   .catch(this.handlesError);
    }

    updateDish(id: number, dto: Dish): Promise<void> {
        const endpoint = `${this.baseUrl}/${id}`;
        return this.http
                   .put(endpoint, JSON.stringify(dto), { headers: this.headers })
                   .toPromise()
                   .then(() => null)
                   .catch(this.handlesError);
    }

    deleteDish(id: number): Promise<void> {
        const endpoint = `${this.baseUrl}/${id}`;
        return this.http
                   .delete(endpoint, { headers: this.headers })
                   .toPromise()
                   .then(() => null)
                   .catch(this.handlesError);
    }

    private handlesError(error: any): Promise<any> {
        console.error("Error: ", error);
        return Promise.reject(error.message || error);
    }
}
