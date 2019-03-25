import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientHeaderComponent } from './client-header/client-header.component';
import { ClientFooterComponent } from './client-footer/client-footer.component';
import { HomeBodyComponent } from './home-body/home-body.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClientCalendarViewModule } from '../client-calendar-view/client-calendar-view.module';
import { ContactFormComponent } from './contact-form/contact-form.component';
import { ReservationComponent } from './reservation/reservation.component';
import { AppRoutingModule } from '../app-routing.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [ClientHeaderComponent, ClientFooterComponent,
    HomeBodyComponent, ContactFormComponent, ReservationComponent,
    ],
  imports: [
    NgbModule,
    CommonModule,
    ClientCalendarViewModule,
    AppRoutingModule,RouterModule
  ],
  exports: [ClientHeaderComponent, ClientFooterComponent, HomeBodyComponent, ContactFormComponent, ReservationComponent]
})
export class ClientViewsModule { }
