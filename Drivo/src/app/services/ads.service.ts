import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { AdEntity } from 'src/entities/AdEntity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class AdsService {

  constructor(private httpClient: HttpClient) { }

  public async getAdsAsync(): Promise<Array<AdEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<AdEntity>>(`${environment.apiUri}/Ads`));
  }

  public async getAdByIdAsync(adId: number): Promise<AdEntity> {
    return await firstValueFrom(this.httpClient.get<AdEntity>(`${environment.apiUri}/Ads/${adId}`))
  }

  public async addAdAsync(ad: AdEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Ads`, ad));
  }

  public async updateAdAsync(ad: AdEntity): Promise<ActionResponse>
  {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/Ads`, ad));
  }

  public async removeAdAsync(adId: number): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Ads/${adId}`));
  }

}
