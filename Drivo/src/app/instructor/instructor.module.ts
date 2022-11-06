import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InstructorComponent } from './instructor/instructor.component';
import { InstructorFormComponent } from './instructor-form/instructor-form.component';
import { InstructorTableComponent } from './instructor-table/instructor-table.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    InstructorComponent,
    InstructorFormComponent,
    InstructorTableComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class InstructorModule { }
