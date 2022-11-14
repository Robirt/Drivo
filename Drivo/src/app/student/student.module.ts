import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentTableComponent } from './student-table/student-table.component';
import { StudentComponent } from './student/student.component';
import { StudentGroupsComponent } from './student-groups/student-groups.component';
import { StudentFormComponent } from './student-form/student-form.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    StudentTableComponent,
    StudentComponent,
    StudentGroupsComponent,
    StudentFormComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class StudentModule { }
