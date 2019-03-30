import {
  Component,
  ChangeDetectionStrategy,
  ViewChild,
  TemplateRef,
  ChangeDetectorRef
} from '@angular/core';
import {
  startOfDay,
  endOfDay,
  subDays,
  addDays,
  endOfMonth,
  isSameDay,
  isSameMonth,
  addHours,
  addMinutes
} from 'date-fns';
import { Subject } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {
  CalendarEvent,
  CalendarEventAction,
  CalendarEventTimesChangedEvent,
  CalendarView,
  CalendarDayViewBeforeRenderEvent,
  CalendarWeekViewBeforeRenderEvent,
  CalendarMonthViewBeforeRenderEvent
} from 'angular-calendar';
import { DayViewHourSegment } from 'calendar-utils';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ReservationService } from '../../_services';
import { ReservationModel } from '../../_models';
import { first } from 'rxjs/operators';

const colors: any = {
  red: {
    primary: '#ad2121',
    secondary: '#FAE3E3'
  },
  blue: {
    primary: '#1e90ff',
    secondary: '#D1E8FF'
  },
  yellow: {
    primary: '#e3bc08',
    secondary: '#FDF1BA'
  }
};


@Component({
  selector: 'app-client-calendar',
  changeDetection: ChangeDetectionStrategy.OnPush,
  templateUrl: './client-calendar.component.html',
  styleUrls: ['./client-calendar.component.scss']
})
export class ClientCalendarComponent {
  @ViewChild('modalContent') modalContent: TemplateRef<any>;

  view: CalendarView = CalendarView.Month;

  CalendarView = CalendarView;

  viewDate: Date = new Date();

  locale = 'pl';

  modalData: {
    action: string;
    event: CalendarEvent;
  };

  actions: CalendarEventAction[] = [
    // {
    //   label: '<i class="fa fa-fw fa-pencil"></i>',
    //   onClick: ({ event }: { event: CalendarEvent }): void => {
    //     this.handleEvent('Edited', event);
    //   }
    // },
    // {
    //   label: '<i class="fa fa-fw fa-times"></i>',
    //   onClick: ({ event }: { event: CalendarEvent }): void => {
    //     this.events = this.events.filter(iEvent => iEvent !== event);
    //     this.handleEvent('Deleted', event);
    //   }
    // }
  ];

  refresh: Subject<any> = new Subject();

  events: CalendarEvent[] = [
    {
      start: subDays(startOfDay(new Date()), 1),
      end: addDays(new Date(), 1),
      title: 'A 3 day event',
      color: colors.red,
      actions: this.actions,
      allDay: true,
      resizable: {
        beforeStart: true,
        afterEnd: true
      },
      draggable: true
    },
    {
      start: startOfDay(new Date()),
      title: 'An event with no end date',
      color: colors.yellow,
      actions: this.actions
    },
    {
      start: subDays(endOfMonth(new Date()), 3),
      end: addDays(endOfMonth(new Date()), 3),
      title: 'A long event that spans 2 months',
      color: colors.blue,
      allDay: true
    },
    {
      start: addHours(startOfDay(new Date()), 2),
      end: new Date(),
      title: 'A draggable and resizable event',
      color: colors.yellow,
      actions: this.actions,
      resizable: {
        beforeStart: true,
        afterEnd: true
      },
      draggable: true
    }
  ];

  activeDayIsOpen = false;

  constructor(
    private modal: NgbModal,
    private formBuilder: FormBuilder,
    private reservationService: ReservationService
  ) {

  }

  dayClicked({ date, events }: { date: Date; events: CalendarEvent[] }): void {
     if (isSameMonth(date, this.viewDate)) {
       this.viewDate = date;
  //     if (
  //       (isSameDay(this.viewDate, date) && this.activeDayIsOpen === true) ||
  //       events.length === 0
  //     ) {
  //       this.activeDayIsOpen = false;
  //     } else {
  //       this.activeDayIsOpen = true;
  //     }
    }
  }

  // eventTimesChanged({
  //   event,
  //   newStart,
  //   newEnd
  // }: CalendarEventTimesChangedEvent): void {
  //   this.events = this.events.map(iEvent => {
  //     if (iEvent === event) {
  //       return {
  //         ...event,
  //         start: newStart,
  //         end: newEnd
  //       };
  //     }
  //     return iEvent;
  //   });
  //   this.handleEvent('Dropped or resized', event);
  // }

  // handleEvent(action: string, event: CalendarEvent): void {
  //   this.modalData = { event, action };
  //   this.modal.open(this.modalContent, { size: 'lg' });
  // }


  addEvent(startDate: Date, endDate: Date, title: string): void {

    this.events = [
      ...this.events,
      {
        title: title,
        start: startDate,
        end: endDate,
        color: colors.red,
        draggable: false,
        resizable: {
          beforeStart: true,
          afterEnd: true
        }
      }
    ];
  }

  // deleteEvent(eventToDelete: CalendarEvent) {
  //   this.events = this.events.filter(event => event !== eventToDelete);
  // }

  setView(view: CalendarView) {
    this.view = view;
  }

  closeOpenMonthViewDay() {
    // this.activeDayIsOpen = false;
  }

  beforeMonthViewRender(renderEvent: CalendarMonthViewBeforeRenderEvent): void {
    renderEvent.body.forEach(day => {
      // const dayOfMonth = day.date.getDate();
      // if (dayOfMonth > 5 && dayOfMonth < 10 && day.inMonth) {
      //   day.cssClass = 'cal-disabled';
      // }
      const newDate = new Date();
      if (day.date <= newDate  || day.date.getDay() === 6 || day.date.getDay() === 0) {
        day.cssClass = 'cal-disabled';
      }
    });
  }

  beforeWeekViewRender(renderEvent: CalendarWeekViewBeforeRenderEvent) {
    renderEvent.hourColumns.forEach(hourColumn => {
      hourColumn.hours.forEach(hour => {
        hour.segments.forEach(segment => {
          // if (
          //   segment.date.getHours() >= 2 &&
          //   segment.date.getHours() <= 5 &&
          //   segment.date.getDay() === 2
          // ) {
          //   segment.cssClass = 'cal-disabled';
          // }
          const newDate = addDays(startOfDay(new Date()), 1);
          if (
            segment.date <= newDate || segment.date.getDay() === 6 || segment.date.getDay() === 0
          ) {
            segment.cssClass = 'cal-disabled';
          }

        });
      });
    });
  }

  beforeDayViewRender(renderEvent: CalendarDayViewBeforeRenderEvent) {
    renderEvent.body.hourGrid.forEach(hour => {
      hour.segments.forEach((segment, index) => {
        // if (segment.date.getHours() >= 2 && segment.date.getHours() <= 5) {
        //   segment.cssClass = 'cal-disabled';
        // }
        const newDate = addDays(startOfDay(new Date()), 1);
        if (segment.date <= newDate || segment.date.getDay() === 6 || segment.date.getDay() === 0) {
          segment.cssClass = 'cal-disabled';
        }
      });
    });
  }



 

 


  //reservation

  staticSegment: DayViewHourSegment
  reservationForm: FormGroup;
  loading = false;
  submitted = false;
  errors: string[];


  clickHourSegmentToCreate(
    segment: DayViewHourSegment,
  ) {
    const newDate = addDays(startOfDay(new Date()), 1);
    if (segment.date >= newDate && segment.date.getDay() !== 6 && segment.date.getDay() !== 0) {
      this.handleEvent();
      this.staticSegment = segment;
    }
  }


  handleEvent(): void {
    this.createForm();
    this.modal.open(this.modalContent);
  }




  createForm(){
    this.reservationForm = this.formBuilder.group({
      username: ['', [Validators.required, Validators.pattern('^[A-Z-zęóąśłżźćńÓĄŚŁŻŹĆŃ][a-z-zóęąśłżźćńÓĄŚŁŻŹĆŃ]{2,30}')]],
      surname: ['', [Validators.required, Validators.pattern('^[A-Z-zęóąśłżźćńÓĄŚŁŻŹĆŃ][a-z-zóęąśłżźćńÓĄŚŁŻŹĆŃ]{2,30}')]],
      pesel: ['', [Validators.required, Validators.pattern('^[0-9]{11}')]]
    });
    this.errors = [];
  }

  // convenience getter for easy access to form fields
  get f() { return this.reservationForm.controls; }

  onSubmit() {

    this.submitted = true;

    this.errors = [];

    // stop here if form is invalid
    if (this.reservationForm.invalid) {
      return;
    }

    const reservation: ReservationModel = new ReservationModel();


    reservation.name = this.f.username.value;
    reservation.surname = this.f.surname.value;
    reservation.pesel = this.f.pesel.value;
    reservation.dateStart = this.staticSegment.date.getTime()+'';
    reservation.dateEnd = addMinutes(this.staticSegment.date, 15).getTime()+ '';


    this.loading = true;
    this.reservationService.createReservation(reservation)
      .pipe(first())
      .subscribe(
        data => {
          this.loading = false;
          this.submitted = false;
          this.addEvent(this.staticSegment.date, addMinutes(this.staticSegment.date, 15), reservation.name + ' ' + reservation.surname);
          this.modal.dismissAll();
        },
        error => {
          this.submitted = false;
          this.loading = false;
          this.errors = error[''];
        });


  }

}

