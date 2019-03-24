import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'app-home-body',
  templateUrl: './home-body.component.html',
  styleUrls: ['./home-body.component.scss']
})
export class HomeBodyComponent implements OnInit {

  constructor(public http: HttpClient) { }

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

  buttonClick2() {
    let name: string = 'asdasd';
    return this.http.get<any>('/home/getget').subscribe(
      data => {
        console.log(data);
      }
    );
  }


}
