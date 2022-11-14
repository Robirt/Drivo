import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { StudentEntity } from 'src/entities/StudentEntity';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';

@Injectable({
  providedIn: 'root'
})
export class StudentGroupsServiceService {

  constructor(private httpClient: HttpClient) { }

  public async addStudentToGroup(name: string, student: StudentEntity): Promise<StudentsGroupEntity>
  {
    return await firstValueFrom(this.httpClient.post<StudentsGroupEntity>(`https://localhost::5001/StudentsGroup/${name}`, student));
  }

  public async addGroup(studentgroup: StudentsGroupEntity): Promise<StudentsGroupEntity>
  {
    return await firstValueFrom(this.httpClient.post<StudentsGroupEntity>("https://localhost:5001/StudentsGroup", studentgroup));
  }

  public async searchStudentInGroup(groupName: string, searchString: string): Promise<Array<StudentEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<StudentEntity>>(`https://localhost:5001/StudentsGroup/${groupName}/Search/${searchString}`));
  }

  public async putStudentGroup(studentgroup: StudentsGroupEntity): Promise<StudentsGroupEntity>
  {
    return await firstValueFrom(this.httpClient.put<StudentsGroupEntity>("https://localhost:5001/StudentsGroup", studentgroup));
  }

  public async deleteStudentFromGroup(studentgroup: string, studentname: string): Promise<void>
  {
    await firstValueFrom(this.httpClient.delete<void>(`https://localhost:5001/StudentsGroup/${studentgroup}/${studentname}`));
  }

  public async deleteGroup(groupname: string): Promise<void>
  {
    await firstValueFrom(this.httpClient.delete<void>(`https://localhost:5001/StudentsGroup/${groupname}`));
  }
}
