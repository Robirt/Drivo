import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';

@Injectable({
  providedIn: 'root'
})
export class CourseModulServiceService {

    
  constructor(private httpClient: HttpClient) { }

  public async getCourseModuls(): Promise<Array<CourseModulEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<CourseModulEntity>>("https://localhost:5001/CourseModul"));
  }

  public async getCourseModulByTitle(title: string): Promise<CourseModulEntity>
  {
    return await firstValueFrom(this.httpClient.get<CourseModulEntity>(`https://localhost:5001/CourseModul/${title}`));
  }

  public async searchCourseModulByTitle(searchString: string): Promise<Array<CourseModulEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<CourseModulEntity>>(`https://localhost:5001/CourseModul/Search/${searchString}`));
  }

  public async addCourseModul(courseModule: CourseModulEntity): Promise<CourseModulEntity>
  {
    return await firstValueFrom(this.httpClient.post<CourseModulEntity>("https://localhost:5001/CourseModul/",courseModule));
  }

  public async putCourseModul(courseModul: CourseModulEntity): Promise<CourseModulEntity>
  {
    return await firstValueFrom(this.httpClient.put<CourseModulEntity>("https://localhost:5001/CourseModul", courseModul));
  }

  public async deleteCourseModul(id: number): Promise<CourseModulEntity>
  {
    return await firstValueFrom(this.httpClient.delete<CourseModulEntity>(`https://localhost:5001/CourseModul/${id}`));
  }
}
