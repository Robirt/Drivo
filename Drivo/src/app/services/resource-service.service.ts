import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';
import { ResourceEntity } from 'src/entities/ResourceEntity';

@Injectable({
  providedIn: 'root'
})
export class ResourceServiceService {

  
  constructor(private httpClient: HttpClient) { }

  public async getResources(): Promise<Array<ResourceEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<ResourceEntity>>("https://localhost:5001/Resource"));
  }

  public async getResourceByTitle(title: string): Promise<ResourceEntity>
  {
    return await firstValueFrom(this.httpClient.get<ResourceEntity>(`https://localhost:5001/Resource/${title}`));
  }

  public async searchResourceInModuleByTitle(courseModuleName: string, searchString: string): Promise<Array<ResourceEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<ResourceEntity>>(`https://localhost:5001/Resource/Search/${courseModuleName}/${searchString}`));
  }

  public async addResourceToModule(courseModuleName: string, resource: ResourceEntity): Promise<CourseModulEntity>
  {
    return await firstValueFrom(this.httpClient.post<CourseModulEntity>(`https://localhost:5001/CourseModul/${courseModuleName}`, resource));
  }

  public async putResource(resource: ResourceEntity): Promise<ResourceEntity>
  {
    return await firstValueFrom(this.httpClient.put<ResourceEntity>("https://localhost:5001/Resource", resource));
  }

  public async deleteResource(title: string): Promise<ResourceEntity>
  {
    return await firstValueFrom(this.httpClient.delete<ResourceEntity>(`https://localhost:5001/Student/${title}`));
  }
}

