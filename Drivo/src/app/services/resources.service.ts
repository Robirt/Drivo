import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { ResourceEntity } from 'src/entities/resource.entity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class ResourcesService {

  constructor(private httpClient: HttpClient) { }

  public async addResourceAsync(resource: ResourceEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/Resources`, resource));
  }
  
  public async updateResourceAsync(resource: ResourceEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/Resources`, resource));
  }

  public async removeResourceAsync(resource: ResourceEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/Resources/${resource.id}`));
  }

}

