import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { ResourceEntity } from 'src/entities/ResourceEntity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class ResourceService {

  constructor(private httpClient: HttpClient) { }

  public async addResourceAsync(resource: ResourceEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Resources`, resource));
  }
  
  public async updateResourceAsync(resource: ResourceEntity): Promise<ResourceEntity>
  {
    return await firstValueFrom(this.httpClient.put<ResourceEntity>(`${environment.apiUri}/Resources`, resource));
  }

  public async removeResourceAsync(resourceId: number): Promise<ActionResponse>
  {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Resources/${resourceId}`));
  }

}

