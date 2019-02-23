import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService, AuthenticationService } from '../_services';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    users: User[] = [];

  constructor(private userService: UserService, public http: HttpClient) { }

    ngOnInit() {
      
    }

  buttonClick() {
    return this.http.get<any>('/home/get').subscribe(
      data => {
        console.log(data);
      }
    );
  }

  buttonClick1() {
    let name: string = 'asdasd';
    return this.http.post<any>('/home/post', {name}).subscribe(
      data => {
        console.log(data);
      }
    );
  }

 
}
