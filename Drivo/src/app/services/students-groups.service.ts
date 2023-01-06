import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class StudentsGroupsService {

  constructor(private httpClient: HttpClient) { }

  public async getStudentsGroupsAsync(): Promise<Array<StudentsGroupEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<StudentsGroupEntity>>(`${environment.apiUri}/StudentsGroups`));
  }

  public async getStudentsGroupByIdAsync(studentsGroupId: number): Promise<StudentsGroupEntity> {
    return await firstValueFrom(this.httpClient.get<StudentsGroupEntity>(`${environment.apiUri}/StudentsGroups/${studentsGroupId}`));
  }

  public async addStudentsGroupAsync(studentsGroup: StudentsGroupEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/StudentsGroups`, studentsGroup));
  }

  public async updateStudentsGroupAsync(studentgroup: StudentsGroupEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/StudentsGroups`, studentgroup));
  }

  public async removeStudentsGroupAsync(studentsGroupId: number): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/StudentsGrous/${studentsGroupId}`));
  }

}
