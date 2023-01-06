import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';
import { environment } from 'src/environments/environment';
import { ActionResponse } from 'src/responses/action.response';

@Injectable({
  providedIn: 'root'
})
export class CourseModulesService {

  constructor(private httpClient: HttpClient) { }

  public async getCourseModulesAsync(): Promise<Array<CourseModulEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<CourseModulEntity>>(`${environment.apiUri}/CourseModules`));
  }

  public async getCourseModuleByNameAsync(name: string): Promise<CourseModulEntity> {
    return await firstValueFrom(this.httpClient.get<CourseModulEntity>(`${environment.apiUri}/CourseModules/${name}`));
  }

  public async searchCourseModuleByNameAsync(searchString: string): Promise<Array<CourseModulEntity>> {
    return await firstValueFrom(this.httpClient.get<Array<CourseModulEntity>>(`${environment.apiUri}/CourseModules/Search/${searchString}`));
  }

  public async addCourseModuleAsync(courseModule: CourseModulEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.post<ActionResponse>(`${environment.apiUri}/CourseModules`, courseModule));
  }

  public async updateCourseModuleAsync(courseModule: CourseModulEntity): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.put<ActionResponse>(`${environment.apiUri}/CourseModules`, courseModule));
  }

  public async removeCourseModuleAsync(courseModuleName: string): Promise<ActionResponse> {
    return await firstValueFrom(this.httpClient.delete<ActionResponse>(`${environment.apiUri}/CourseModules/${courseModuleName}`));
  }
  
}
