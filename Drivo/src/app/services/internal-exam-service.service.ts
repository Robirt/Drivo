import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { InternalExamEntity } from 'src/entities/InternalExamEntity';

@Injectable({
  providedIn: 'root'
})
export class InternalExamServiceService {

  constructor(private httpClient: HttpClient) { }

  public async getInternalExams(): Promise<Array<InternalExamEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<InternalExamEntity>>("https://localhost:5001/InternalExam"));
  }

  public async getInternalExamById(id: number): Promise<InternalExamEntity>
  {
    return await firstValueFrom(this.httpClient.get<InternalExamEntity>(`https://localhost:5001/InternalExam/${id}`));
  }

  public async addInternalExamToStudent(studentName: string, internalExam: InternalExamEntity): Promise<void>
  {
    return await firstValueFrom(this.httpClient.post<void>("https://localhost:5001/InternalExam", studentName));
  }

  public async putInternalExam(internalExam: InternalExamEntity): Promise<InternalExamEntity>
  {
    return await firstValueFrom(this.httpClient.put<InternalExamEntity>("https://localhost:5001/InternalExam", internalExam));
  }

  public async deleteInternalExam(id: number): Promise<InternalExamEntity>
  {
    return await firstValueFrom(this.httpClient.delete<InternalExamEntity>(`https://localhost:5001/InternalExam/${id}`));
  }
}
