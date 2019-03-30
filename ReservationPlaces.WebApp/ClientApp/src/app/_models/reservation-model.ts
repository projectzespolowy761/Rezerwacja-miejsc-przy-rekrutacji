import {IReservationModel } from '../_interfaces';

export class ReservationModel implements IReservationModel {
    name: string;
    surname: string;
  pesel: string;
  dateStart: string;
  dateEnd: string;
}
