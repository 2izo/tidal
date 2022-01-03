import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../Entites/User';
import { map } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NetworkService {
  users: User[] = [];
  constructor(private http: HttpClient) {}
  getUsers(): Observable<User[]> {
    if (this.users.length > 0) return of(this.users);
    return this.http.get<User[]>('https://localhost:5001/api/users/').pipe(
      map((e) => {
        this.users = e;

        return e;
      })
    );
  }
  getUser(id: number) {
    var user = this.users.find((x) => x.id === id);
    if (user !== undefined) return of(user);

    return this.http.get<User>('https://localhost:5001/api/users/' + id);
  }
  addUser(user: any) {
    return this.http.post(`https://localhost:5001/api/users/register`, user);
  }
  deleteUser(id: number) {
    return this.http.delete(
      `https://localhost:5001/api/users/deleteUser/${id}`
    );
  }

  async getCountry(long: number, lat: number) {
    // results[2].address_components[1].short_name
    var country: any = await fetch(
      `https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${long}&key=AIzaSyD_N1k4WKCdiZqCIjjgO0aaKz1Y19JqYqw`
    );

    return await country.json();
  }
}
