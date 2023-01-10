import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { InstructorEntity } from 'src/entities/InstructorEntity';
import { environment } from 'src/environments/environment';
import { CreateUserRequest } from 'src/requests/createUser.request';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class InstructorsService {

  constructor(private httpClient: HttpClient) { }

  public async getInstructorsAsync(): Promise<Array<InstructorEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<InstructorEntity>>(`${environment.apiUri}/Instructors`));
  }

  public async getInstructorByUserNameAsync(userName: string): Promise<InstructorEntity> {
    return await firstValueFrom(this.httpClient.get<InstructorEntity>(`${environment.apiUri}/Instructors/${userName}`));
  }

  public async searchInstructorsByFullNameAsync(searchString: string): Promise<Array<InstructorEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<InstructorEntity>>(`${environment.apiUri}/Instructors/Search/${searchString}`));
  }

  public async createInstructorAsync(createUserRequest: CreateUserRequest): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Instructors`, createUserRequest));
  }

  public async updateInstructorAsync(instructor: InstructorEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/Instructors`, instructor));
  }

  public async deleteInstructor(instructorUserName: string): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Instructors/${instructorUserName}`));
  }

}
