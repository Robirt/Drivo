import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { LectureEntity } from 'src/entities/LectureEntity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class LecturesService {
  
  constructor(private httpClient: HttpClient) {}

  public async getLecturesAsync(): Promise<Array<LectureEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<LectureEntity>>(`${environment.apiUri}/Lectures`));
  }

  public async addLectureAsync(lecture: LectureEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Lectures`, lecture));
  }

  public async updateLectureAsync(lecture: LectureEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/Lectures`, lecture));
  }

  public async removeLectureAsync(lectureId: number): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Lectures/${lectureId}`));
  }

}
