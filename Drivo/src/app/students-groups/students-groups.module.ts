import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudentsGroupsComponent } from './students-groups/students-groups.component';
import { StudentsGroupComponent } from './students-group/students-group.component';
import { StudentsGroupFormComponent } from './students-group-form/students-group-form.component';
import { StudentsGroupsGridComponent } from './students-groups-grid/students-groups-grid.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    StudentsGroupsComponent,
    StudentsGroupComponent,
    StudentsGroupFormComponent,
    StudentsGroupsGridComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class StudentsGroupsModule { }
