import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { LoginViewModel } from '../_models';
import { UserService, AuthenticationService } from '../_services';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {

  constructor(private userService: UserService, public http: HttpClient) { }


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

  buttonClick2() {
    let name: string = 'asdasd';
    return this.http.get<any>('/home/getget').subscribe(
      data => {
        console.log(data);
      }
    );
  }

}
