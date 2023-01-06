import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentsTableComponent } from './students-table/students-table.component';
import { StudentsComponent } from './students/students.component';
import { StudentFormComponent } from './student-form/student-form.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    StudentsTableComponent,
    StudentsComponent,
    StudentFormComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class StudentsModule { }
