import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PaymentEntity } from 'src/entities/PaymentEntity';
import { StudentEntity } from 'src/entities/StudentEntity';

@Component({
  selector: 'payments-grid',
  templateUrl: './payments-grid.component.html',
  styleUrls: ['./payments-grid.component.css']
})
export class PaymentsGridComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() payments: Array<PaymentEntity> = new Array<PaymentEntity>();

  @Input() students: Array<StudentEntity> = new Array<StudentEntity>();

  @Output() onAddPayment: EventEmitter<PaymentEntity> = new EventEmitter<PaymentEntity>();

  @Output() onUpdatePayment: EventEmitter<PaymentEntity> = new EventEmitter<PaymentEntity>();

  @Output() onRemovePayment: EventEmitter<PaymentEntity> = new EventEmitter<PaymentEntity>();

  public async addPaymentAsync(payment: PaymentEntity): Promise<void> {
    this.onAddPayment.emit(payment);
  }

  public async updatePaymentAsync(payment: PaymentEntity): Promise<void> {
    this.onUpdatePayment.emit(payment);
  }

  public async removePaymentAsync(payment: PaymentEntity): Promise<void> {
    this.onRemovePayment.emit(payment);
  }

}
