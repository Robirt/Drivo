import { Component, OnInit } from '@angular/core';
import { PaymentsService } from 'src/app/services/payments.service';
import { StudentsService } from 'src/app/services/students.service';
import { PaymentEntity } from 'src/entities/PaymentEntity';
import { StudentEntity } from 'src/entities/StudentEntity';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'app-payments',
  templateUrl: './payments.component.html',
  styleUrls: ['./payments.component.css']
})
export class PaymentsComponent implements OnInit {

  constructor(private paymentsService: PaymentsService, private studentsService: StudentsService) { }

  async ngOnInit(): Promise<void> {
    await this.getPaymentsAsync();

    await this.getStudentsAsync();
  }

  public payments: Array<PaymentEntity> = new Array<PaymentEntity>();

  public actionResponse = new ActionResponse();

  public students: Array<StudentEntity> = new Array<StudentEntity>();

  public async getPaymentsAsync(): Promise<void> {
    this.payments = await this.paymentsService.getPaymentsAsync()
  }

  public async addPaymentAsync(payment: PaymentEntity): Promise<void> {
    this.actionResponse = await this.paymentsService.addPaymentAsync(payment);

    await this.getPaymentsAsync();
  }

  public async updatePaymentAsync(payment: PaymentEntity): Promise<void> {
    this.actionResponse = await this.paymentsService.updatePaymentAsync(payment);

    console.log(payment);

    await this.getPaymentsAsync();
  }

  public async removePaymentAsync(payment: PaymentEntity): Promise<void> {
    this.actionResponse = await this.paymentsService.deletePaymentAsync(payment.id);

    await this.getPaymentsAsync();
  }

  public async getStudentsAsync(): Promise<void> {
    this.students = await this.studentsService.getStudentsAsync();
  }
}
