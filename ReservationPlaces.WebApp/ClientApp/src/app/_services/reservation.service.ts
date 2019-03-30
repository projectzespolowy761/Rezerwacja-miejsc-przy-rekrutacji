import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ReservationModel } from '../../app/_models';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {

  constructor(private http: HttpClient) { }

  createReservation(resevation:ReservationModel)
  {
    return this.http.post(`/home/AddReservation`, resevation); 
  }

}
