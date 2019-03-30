import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../_services';

@Component({
  selector: 'app-client-header',
  templateUrl: './client-header.component.html',
  styleUrls: ['./client-header.component.scss']
})
export class ClientHeaderComponent implements OnInit {

  statusUser : any;

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.statusUser =this.authenticationService.currentUserValue;
  }



}
