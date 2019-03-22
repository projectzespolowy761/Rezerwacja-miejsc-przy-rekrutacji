import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientHeaderComponent } from './client-header/client-header.component';
import { ClientFooterComponent } from './client-footer/client-footer.component';
import { HomeBodyComponent } from './home-body/home-body.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ClientCalendarViewModule } from '../client-calendar-view/client-calendar-view.module';

@NgModule({
  declarations: [ClientHeaderComponent, ClientFooterComponent, HomeBodyComponent],
  imports: [
    NgbModule,
    CommonModule,
    ClientCalendarViewModule
  ],
  exports: [ClientHeaderComponent, ClientFooterComponent, HomeBodyComponent]
})
export class ClientViewsModule { }
