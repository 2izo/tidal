import { AfterViewInit, Component, OnInit } from '@angular/core';

import { User } from './Entites/User';
import { NetworkService } from './services/network.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(private networkService: NetworkService) {}

  ngOnInit() {
    this.networkService.getUsers().subscribe((e) => {
      this.Users = e;
    });
  }
  delete(user: User) {
    this.Users = this.Users.filter((e) => e.id !== user.id);
    this.networkService.deleteUser(user.id).subscribe();
  }
  addUser(username: string) {
    var user: User = {
      id: -1,
      username: username,
      lat: Math.round(this.lat),
      lang: Math.round(this.lng),
    };
    this.Users.push(user);
    this.networkService.addUser(user).subscribe();
  }
  src(i: number) {
    // return this.networkService.getCountry(
    //   this.Users[i].lang,
    //   this.Users[i].lat
    // );
    // console.log(this.flags);
    // return this.flags[i].body;
  }
  markPosition(event: any) {
    this.lat = event.coords.lat;
    this.lng = event.coords.lng;
  }
  Users!: User[];
  title = 'mapClient';
  lat = 26.820553;
  lng = 30.809007;
  flags: any[] = [];
}
