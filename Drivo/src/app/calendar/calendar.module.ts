import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalendarComponent } from './calendar/calendar.component';
import { CalendarModule } from 'primeng/calendar';
import { FormsModule } from '@angular/forms';
import { CalendarFormComponent } from './calendar-form/calendar-form.component';
import { CalendarTableComponent } from './calendar-table/calendar-table.component';



@NgModule({
  declarations: [
    CalendarComponent,
    CalendarFormComponent,
    CalendarTableComponent,
  ],
  imports: [
    CommonModule,
    CalendarModule,
    FormsModule
  ]
})
export class CalendarPageModule { }
