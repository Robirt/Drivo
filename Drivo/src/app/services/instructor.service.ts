import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { InstructorEntity } from 'src/entities/InstructorEntity';

@Injectable({
  providedIn: 'root'
})
export class InstructorService {

  constructor(private httpClient: HttpClient) { }

  public async getInstructors(): Promise<Array<InstructorEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<InstructorEntity>>("https://localhost:5001/Instructor"));
  }

  public async getInstructorByName(name: string): Promise<InstructorEntity>
  {
    return await firstValueFrom(this.httpClient.get<InstructorEntity>(`https://localhost:5001/Instructor/${name}`));
  }

  public async searchInstructor(searchString: string): Promise<Array<InstructorEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<InstructorEntity>>(`https://localhost:5001/Instructor/Search/${searchString}`));
  }

  public async postInstructor(instructor: InstructorEntity): Promise<InstructorEntity>
  {
    return await firstValueFrom(this.httpClient.post<InstructorEntity>("https://localhost:5001/Instructor", instructor));
  }

  public async putInstructor(instructor: InstructorEntity): Promise<InstructorEntity>
  {
    return await firstValueFrom(this.httpClient.put<InstructorEntity>("https://localhost:5001/Instructor", instructor));
  }

  public async deleteInstructor(id: number): Promise<InstructorEntity>
  {
    return await firstValueFrom(this.httpClient.delete<InstructorEntity>(`https://localhost:5001/Instructor/${id}`));
  }
}
