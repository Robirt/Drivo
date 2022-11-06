import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { StudentEntity } from 'src/entities/StudentEntity';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {

  constructor(private httpClient: HttpClient) { }

  public async getStudents(): Promise<Array<StudentEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<StudentEntity>>("https://localhost:5001/Student"));
  }
  public async getStudent(id: number): Promise<StudentEntity>
  {
    return await firstValueFrom(this.httpClient.get<StudentEntity>(`https://localhost::5001/Student/${id}`));
  }
  public async searchStudents(searchString: string): Promise<Array<string>>
  {
    return await firstValueFrom(this.httpClient.get<Array<string>>(`https://localhost::5001/Student/Search/${searchString}`));
  }
  public async postStudent(student: StudentEntity): Promise<StudentEntity>
  {
    return await firstValueFrom(this.httpClient.post<StudentEntity>("https://localhost::5001/Student", student));
  }
  public async putStudent(student: StudentEntity): Promise<StudentEntity>
  {
    return await firstValueFrom(this.httpClient.put<StudentEntity>("https://localhost::5001/Student", student));
  }
  public async deleteStudent(id: number): Promise<StudentEntity>
  {
    return await firstValueFrom(this.httpClient.delete<StudentEntity>(`https://localhost:5001/Student/${id}`));
  }
}