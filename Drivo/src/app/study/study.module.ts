import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudyComponent } from './study/study.component';
import { ItemComponent } from './item/item.component';
import { GridComponent } from './grid/grid.component';
import { FormComponent } from './form/form.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    StudyComponent,
    ItemComponent,
    GridComponent,
    FormComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class StudyModule { }
