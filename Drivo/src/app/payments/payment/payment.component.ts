import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PaymentEntity } from 'src/entities/PaymentEntity';
import { StudentEntity } from 'src/entities/StudentEntity';

@Component({
  selector: 'payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() payment: PaymentEntity;

  @Output() onUpdatePayment: EventEmitter<PaymentEntity> = new EventEmitter<PaymentEntity>();

  @Output() onRemovePayment: EventEmitter<PaymentEntity> = new EventEmitter<PaymentEntity>();

  public async updatePaymentAsync(): Promise<void> {
    this.onUpdatePayment.emit(this.payment);
  }

  public async removePaymentAsync(): Promise<void> {
    this.onRemovePayment.emit(this.payment);
  }

}
