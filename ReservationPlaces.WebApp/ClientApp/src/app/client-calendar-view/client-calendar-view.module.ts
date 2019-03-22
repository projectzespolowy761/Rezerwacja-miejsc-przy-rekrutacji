import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientCalendarComponent } from './client-calendar/client-calendar.component';
import { FormsModule } from '@angular/forms';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { FlatpickrModule } from 'angularx-flatpickr';
import { CalendarModule, DateAdapter, CalendarDateFormatter, DateFormatterParams, CalendarNativeDateFormatter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';

class CustomDateFormatter extends CalendarNativeDateFormatter {

  public dayViewHour({date, locale}: DateFormatterParams): string {
    return new Intl.DateTimeFormat('ca', {
      hour: 'numeric',
      minute: 'numeric'
    }).format(date);
  }

  public weekViewHour({date, locale}: DateFormatterParams): string {
    return new Intl.DateTimeFormat('ca', {
      hour: 'numeric',
      minute: 'numeric'
    }).format(date);
  }
}


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    NgbModalModule,
    FlatpickrModule.forRoot(),
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
      }, {
      dateFormatter: {
      provide: CalendarDateFormatter,
      useClass: CustomDateFormatter
      }
      })
  ],
  declarations: [ClientCalendarComponent],
  exports: [ClientCalendarComponent]
})
export class ClientCalendarViewModule { }
