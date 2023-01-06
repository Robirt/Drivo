import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { DrivingEntity } from 'src/entities/DrivingEntity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class DrivingService {
  
  constructor(private httpClient: HttpClient) {}

  public async getDrivingsAsync(): Promise<Array<DrivingEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<DrivingEntity>>(`${environment.apiUri}/Drivings`));
  }

  public async addDrivingAsync(driving: DrivingEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Drivings`, driving));
  }

  public async updateDrivingAsync(driving: DrivingEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/Drivings`, driving));
  }

  public async removeDrivingAsync(drivingId: number): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Drivings/${drivingId}`));
  }

}
