import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { AdEntity } from 'src/entities/AdEntity';

@Injectable({
  providedIn: 'root'
})
export class AdService {

  constructor(private httpClient: HttpClient) { }

  public async getAds(): Promise<Array<AdEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<AdEntity>>("https://localhost:5001/Ad"));
  }

  public async postAd(ad: AdEntity): Promise<AdEntity>
  {
    return await firstValueFrom(this.httpClient.post<AdEntity>("https://localhost:5001/Ad", ad));
  }

  public async putAd(ad: AdEntity): Promise<AdEntity>
  {
    return await firstValueFrom(this.httpClient.put<AdEntity>("https://localhost:5001/Ad", ad));
  }

  public async deleteAd(id: number): Promise<AdEntity>
  {
    return await firstValueFrom(this.httpClient.delete<AdEntity>(`https://localhost:5001/Ad/${id}`));
  }
}
