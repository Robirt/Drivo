import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { InternalExamEntity } from 'src/entities/InternalExamEntity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class InternalExamsService {
  
  constructor(private httpClient: HttpClient) {}

  public async getInternalExamsAsync(): Promise<Array<InternalExamEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<InternalExamEntity>>(`${environment.apiUri}/InternalExams`));
  }

  public async addInternalExamAsync(internalExam: InternalExamEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/InternalExams`, internalExam));
  }

  public async updateInternalExamAsync(internalExam: InternalExamEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/InternalExams`, internalExam));
  }

  public async removeInternalExamAsync(internalExamId: number): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/InternalExams/${internalExamId}`));
  }

}
