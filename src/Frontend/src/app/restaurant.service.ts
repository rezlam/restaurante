import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";

import { Restaurant } from "./restaurant";

@Injectable()
export class RestaurantService {
    private headers = new Headers({'Content-Type': 'application/json'});
    private baseUrl = 'http://localhost:63979/restaurants';

    constructor(private http: Http) {
    }

    listRestaurants(query: string): Promise<Restaurant[]> {
        let endpoint = this.baseUrl;
        if (query && query.length > 0) {
            endpoint += `?filter=${encodeURIComponent(query)}`;
        }
        return this.http
                   .get(endpoint, { headers: this.headers })
                   .toPromise()
                   .then(res => res.json() as Restaurant[])
                   .catch(this.handlesError);
    }

    createRestaurant(dto: Restaurant): Promise<Restaurant> {
        return this.http
                   .post(this.baseUrl, JSON.stringify(dto), { headers: this.headers })
                   .toPromise()
                   .then(res => res.json() as Restaurant)
                   .catch(this.handlesError);
    }

    showRestaurant(id: number): Promise<Restaurant> {
        const endpoint = `${this.baseUrl}/${id}`;
        return this.http
                   .get(endpoint, { headers: this.headers })
                   .toPromise()
                   .then(res => res.json() as Restaurant)
                   .catch(this.handlesError);
    }

    updateRestaurant(dto: Restaurant): Promise<void> {
        const endpoint = `${this.baseUrl}/${dto.Id}`;
        return this.http
                   .put(endpoint, JSON.stringify(dto), { headers: this.headers })
                   .toPromise()
                   .then(() => null)
                   .catch(this.handlesError);
    }

    deleteRestaurant(id: number): Promise<void> {
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
