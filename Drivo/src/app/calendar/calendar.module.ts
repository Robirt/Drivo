import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CalendarComponent } from './calendar/calendar.component';
import { CalendarModule } from 'primeng/calendar';
import { FormsModule } from '@angular/forms';
import { CalendarFormComponent } from './calendar-form/calendar-form.component';
import { CalendarTableComponent } from './calendar-table/calendar-table.component';
import { CalendarGridComponent } from './calendar-grid/calendar-grid.component';



@NgModule({
  declarations: [
    CalendarComponent,
    CalendarFormComponent,
    CalendarTableComponent,
    CalendarGridComponent,
  ],
  imports: [
    CommonModule,
    CalendarModule,
    FormsModule
  ]
})
export class CalendarPageModule { }
