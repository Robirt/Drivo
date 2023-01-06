import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LecturersComponent } from './lecturers/lecturers.component';
import { LecturerFormComponent } from './lecturer-form/lecturer-form.component';
import { LecturersTableComponent } from './lecturers-table/lecturers-table.component';
import { FormsModule } from '@angular/forms';
import { CalendarModule } from 'primeng/calendar';
import { LecturerComponent } from './lecturer/lecturer.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    LecturersComponent,
    LecturerFormComponent,
    LecturersTableComponent,
    LecturerComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    CalendarModule
  ]
})
export class LecturersModule { }
