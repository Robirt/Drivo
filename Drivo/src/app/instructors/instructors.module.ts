import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstructorsComponent } from './instructors/instructors.component';
import { InstructorFormComponent } from './instructor-form/instructor-form.component';
import { InstructorsTableComponent } from './instructors-table/instructors-table.component';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { InstructorComponent } from './instructor/instructor.component';



@NgModule({
  declarations: [
    InstructorsComponent,
    InstructorFormComponent,
    InstructorsTableComponent,
    InstructorComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ]
})
export class InstructorsModule { }
