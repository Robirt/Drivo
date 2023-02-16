import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { PaymentEntity } from 'src/entities/PaymentEntity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class PaymentsService {

  constructor(private httpClient: HttpClient) { }

  public async getPaymentsAsync(): Promise<Array<PaymentEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<PaymentEntity>>(`${environment.apiUri}/Payments`));
  }

  public async addPaymentAsync(payment: PaymentEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Payments`, payment));
  }

  public async updatePaymentAsync(payment: PaymentEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/Payments`, payment));
  }

  public async deletePaymentAsync(paymentId: number): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Payments/${paymentId}`));
  }
  
}
