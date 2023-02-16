import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { StudentEntity } from 'src/entities/StudentEntity';
import { environment } from 'src/environments/environment';
import { CreateUserRequest } from 'src/requests/createUser.request';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(private httpClient: HttpClient) { }

  public async getStudentsAsync(): Promise<Array<StudentEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<StudentEntity>>(`${environment.apiUri}/Students`));
  }

  public async getStudentByUserNameAsync(userName: string): Promise<StudentEntity> {
    return await firstValueFrom(this.httpClient.get<StudentEntity>(`${environment.apiUri}/Students/${userName}`));
  }

  public async searchStudentsByFullNameAsync(searchString: string): Promise<Array<StudentEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<StudentEntity>>(`${environment.apiUri}/Students/Search/${searchString}`));
  }

  public async createStudentAsync(createUserRequest: CreateUserRequest): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Students`, createUserRequest));
  }

  public async updateStudentAsync(student: StudentEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/Students`, student));
  }

  public async deleteStudentAsync(studentUserName: string): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Students/${studentUserName}`));
  }

}