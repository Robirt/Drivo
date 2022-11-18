import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaymentsComponent } from './payments/payments.component';
import { LectureComponent } from './lecture/lecture.component';



@NgModule({
  declarations: [
    PaymentsComponent,
    LectureComponent
  ],
  imports: [
    CommonModule
  ]
})
export class PaymentsModule { }
