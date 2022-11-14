import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { LectureEntity } from 'src/entities/LectureEntity';

@Injectable({
  providedIn: 'root'
})
export class LectureServiceService {

  
  constructor(private httpClient: HttpClient) { }

  public async getLecture(): Promise<Array<LectureEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<LectureEntity>>("https://localhost:5001/Lecture"));
  }

  public async getLectureByName(name: string): Promise<LectureEntity>
  {
    return await firstValueFrom(this.httpClient.get<LectureEntity>(`https://localhost:5001/Lecture/${name}`));
  }

  public async searchLecture(searchString: string): Promise<Array<string>>
  {
    return await firstValueFrom(this.httpClient.get<Array<string>>(`https://localhost:5001/Lecture/Search/${searchString}`));
  }

  public async postLecture(lecture: LectureEntity): Promise<LectureEntity>
  {
    return await firstValueFrom(this.httpClient.post<LectureEntity>("https://localhost:5001/Lecture", lecture));
  }

  public async putLecture(lecture: LectureEntity): Promise<LectureEntity>
  {
    return await firstValueFrom(this.httpClient.put<LectureEntity>("https://localhost:5001/Lecture", lecture));
  }
  
  public async deleteLecture(id: number): Promise<LectureEntity>
  {
    return await firstValueFrom(this.httpClient.delete<LectureEntity>(`https://localhost:5001/Lecture/${id}`));
  }
}
