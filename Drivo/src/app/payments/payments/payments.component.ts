import { Component, OnInit } from '@angular/core';
import { PaymentService } from 'src/app/services/payment.service';
import { PaymentEntity } from 'src/entities/PaymentEntity';
import { StudentEntity } from 'src/entities/StudentEntity';

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css']
})
export class PaymentsComponent implements OnInit {

  constructor(private paymentService: PaymentService) { }

  ngOnInit(): void {
  }
  public payment: PaymentEntity
  public payments: Array<PaymentEntity> = new Array<PaymentEntity>();
public async getPayments(): Promise<void>
{
  this.payments = await this.paymentService.getPayments();
}

public async getPaymentByStudent(id: number, name: string): Promise<void>
{
  this.payments = await this.paymentService.getPaymentByStudent(id, name);
}

public  async getPaymentsRealized(): Promise<void>
{
  this.payments = await this.paymentService.getPaymentsRealized();
}

public  async getPaymentsUnrealized(): Promise<void>
{
  this.payments = await this.paymentService.getPaymentsUnrealized();
}

public  async addPaymentToStudent(payment: PaymentEntity, student: StudentEntity): Promise<void>
{
  this.payment = await this.paymentService.addPaymentToStudent(payment, student);
}

public async putPayment(payment: PaymentEntity): Promise<void>
{
  this.payment = await this.paymentService.putPayment(payment);
}

public async deletePayment(id: number): Promise<void>
{
  this.payment = await this.paymentService.deletePayment(id);
}
}
