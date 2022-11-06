import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalendarComponent } from './calendar/calendar.component';
import { CalendarHistoryComponent } from './calendar-history/calendar-history.component';
import { CalendarModule } from 'primeng/calendar';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    CalendarComponent,
    CalendarHistoryComponent
  ],
  imports: [
    CommonModule,
    CalendarModule,
    FormsModule
  ]
})
export class CalendarPageModule { }
