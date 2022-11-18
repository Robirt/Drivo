import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { PaymentEntity } from 'src/entities/PaymentEntity';
import { StudentEntity } from 'src/entities/StudentEntity';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private httpClient: HttpClient) { }

  public async getPayments(): Promise<Array<PaymentEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<PaymentEntity>>("https://localhost:5001/Payment"));
  }

  public async getPaymentByStudent(id: number, name: string): Promise<Array<PaymentEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<PaymentEntity>>(`https://localhost:5001/Payment/${id}/${name}`));
  }

  public async getPaymentsRealized(): Promise<Array<PaymentEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<PaymentEntity>>("https://localhost:5001/Payment/Realized"));
  }

  public async getPaymentsUnrealized(): Promise<Array<PaymentEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<PaymentEntity>>("https://localhost:5001/Payment/Unrealized"));
  }

  public async addPaymentToStudent(payment: PaymentEntity, student: StudentEntity): Promise<PaymentEntity>
  {
    return await firstValueFrom(this.httpClient.post<PaymentEntity>(`https://localhost:5001/Payment/${payment}`, student));
  }

  public async putPayment(payment: PaymentEntity): Promise<PaymentEntity>
  {
    return await firstValueFrom(this.httpClient.put<PaymentEntity>("https://localhost:5001/Payment", payment));
  }

  public async deletePayment(id: number): Promise<PaymentEntity>
  {
    return await firstValueFrom(this.httpClient.delete<PaymentEntity>(`https://localhost:5001/Payment/${id}`));
  }
}
