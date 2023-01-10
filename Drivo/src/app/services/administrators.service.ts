import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { AdministratorEntity } from 'src/entities/AdministratorEntity';
import { environment } from 'src/environments/environment';
import { CreateUserRequest } from 'src/requests/createUser.request';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class AdministratorsService {

  constructor(private httpClient: HttpClient) { }

  public async getAdministratorsAsync(): Promise<Array<AdministratorEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<AdministratorEntity>>(`${environment.apiUri}/Administrators`));
  }

  public async getAdministratorByUserNameAsync(userName: string): Promise<AdministratorEntity> {
    return await firstValueFrom(this.httpClient.get<AdministratorEntity>(`${environment.apiUri}/Administrators/${userName}`));
  }

  public async searchAdministratorByFullNameAsync(searchString: string): Promise<Array<AdministratorEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<AdministratorEntity>>(`${environment.apiUri}/Administrators/Search/${searchString}`));
  }

  public async createAdministratorAsync(createUserRequest: CreateUserRequest): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Administrators`, createUserRequest));
  }

  public async updateAdministratorAsync(administrator: AdministratorEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/Administrators`, administrator));
  }

  public async deleteAdministratorAsync(administratorUserName: string): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Administrators/${administratorUserName}`));
  }
  
}
