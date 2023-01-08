import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CourseModuleEntity } from 'src/entities/course-module.entity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class CourseModulesService {

  constructor(private httpClient: HttpClient) { }

  public async getCourseModulesAsync(): Promise<Array<CourseModuleEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<CourseModuleEntity>>(`${environment.apiUri}/CourseModules`));
  }

  public async getCourseModuleByNameAsync(name: string): Promise<CourseModuleEntity> {
    return await firstValueFrom(this.httpClient.get<CourseModuleEntity>(`${environment.apiUri}/CourseModules/${name}`));
  }

  public async searchCourseModuleByNameAsync(searchString: string): Promise<Array<CourseModuleEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<CourseModuleEntity>>(`${environment.apiUri}/CourseModules/Search/${searchString}`));
  }

  public async addCourseModuleAsync(courseModule: CourseModuleEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/CourseModules`, courseModule));
  }

  public async updateCourseModuleAsync(courseModule: CourseModuleEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/CourseModules`, courseModule));
  }

  public async removeCourseModuleAsync(courseModule: CourseModuleEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/CourseModules/${courseModule.name}`));
  }
  
}
