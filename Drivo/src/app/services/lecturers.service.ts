import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { LecturerEntity } from 'src/entities/LecturerEntity';
import { environment } from 'src/environments/environment';
import { CreateUserRequest } from 'src/requests/createUser.request';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class LecturersService {

  constructor(private httpClient: HttpClient) { }

  public async getLecturersAsync(): Promise<Array<LecturerEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<LecturerEntity>>(`${environment.apiUri}/Lecturers`));
  }

  public async getLecturerByUserNameAsync(userName: string): Promise<LecturerEntity> {
    return await firstValueFrom(this.httpClient.get<LecturerEntity>(`${environment.apiUri}/Lecturers/${userName}`));
  }

  public async searchLecturersByFullNameAsync(searchString: string): Promise<Array<LecturerEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<LecturerEntity>>(`${environment.apiUri}/Lecturers/Search/${searchString}`));
  }

  public async createLecturerAsync(createUserRequest: CreateUserRequest): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Lecturers`, createUserRequest));
  }

  public async deleteLecturerAsync(lecturerUserName: string): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Lecturers/${lecturerUserName}`));
  }
  
}
