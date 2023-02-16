import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PaymentEntity } from 'src/entities/PaymentEntity';
import { StudentEntity } from 'src/entities/StudentEntity';

@Component({
  selector: 'payment-form',
  templateUrl: './payment-form.component.html',
  styleUrls: ['./payment-form.component.css']
})
export class PaymentFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public payment: PaymentEntity = new PaymentEntity();

  @Input() students: Array<StudentEntity> = new Array<StudentEntity>();

  @Output() onAddPayment: EventEmitter<PaymentEntity> = new EventEmitter<PaymentEntity>();

  public async addPaymentAsync(): Promise<void> {
    this.onAddPayment.emit(this.payment);
  }

}
