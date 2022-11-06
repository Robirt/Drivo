import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LecturerComponent } from './lecturer/lecturer.component';
import { LecturerFormComponent } from './lecturer-form/lecturer-form.component';
import { LecturerTableComponent } from './lecturer-table/lecturer-table.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    LecturerComponent,
    LecturerFormComponent,
    LecturerTableComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class LecturerModule { }
