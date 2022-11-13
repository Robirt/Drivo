import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { LecturerEntity } from 'src/entities/LecturerEntity';

@Injectable({
  providedIn: 'root'
})
export class LecturerServiceService {


  constructor(private httpClient: HttpClient) { }

  public async getLecturers(): Promise<Array<LecturerEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<LecturerEntity>>("https://localhost:5001/Lecturer"));
  }

  public async getLecturersByName(name: string): Promise<LecturerEntity>
  {
    return await firstValueFrom(this.httpClient.get<LecturerEntity>(`https://localhost:5001/Lecturer/${name}`));
  }

  public async searchLecturer(searchString: string): Promise<Array<string>>
  {
    return await firstValueFrom(this.httpClient.get<Array<string>>(`https://localhost:5001/Lecturer/Search/${searchString}`));
  }

  public async postLecturer(lecturer: LecturerEntity): Promise<LecturerEntity>
  {
    return await firstValueFrom(this.httpClient.post<LecturerEntity>("https://localhost:5001/Lecturer", lecturer));
  }

  public async putLecturer(lecturer: LecturerEntity): Promise<LecturerEntity>
  {
    return await firstValueFrom(this.httpClient.put<LecturerEntity>("https://localhost:5001/Lecturer", lecturer));
  }

  public async deleteLecturer(id: number): Promise<LecturerEntity>
  {
    return await firstValueFrom(this.httpClient.delete<LecturerEntity>(`https://localhost:5001/Lecturer/${id}`));
  }
}
