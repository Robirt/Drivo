import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaymentsComponent } from './payments/payments.component';
import { PaymentFormComponent } from './payment-form/payment-form.component';
import { FormsModule } from '@angular/forms';
import { PaymentsGridComponent } from './payments-grid/payments-grid.component';
import { PaymentComponent } from './payment/payment.component';



@NgModule({
  declarations: [
    PaymentsComponent,
    PaymentFormComponent,
    PaymentsGridComponent,
    PaymentComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class PaymentsModule { }
