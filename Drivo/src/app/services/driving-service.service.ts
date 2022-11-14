import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { DrivingEntity } from 'src/entities/DrivingEntity';
import { HttpClient } from '@angular/common/http';
import { StudentEntity } from 'src/entities/StudentEntity';

@Injectable({
  providedIn: 'root'
})
export class DrivingServiceService {
  

  constructor(private httpClient: HttpClient)
  {}
  public async getDrivings(): Promise<Array<DrivingEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<DrivingEntity>>("https://localhost:5001/Driving"));
  }

  public async getDrivingByDate(date: string): Promise<DrivingEntity>
  {
    return await firstValueFrom(this.httpClient.get<DrivingEntity>(`https://localhost:5001/Driving/${date}`));
  }
 
  public async getDrivingByStudent(studentName: string): Promise<DrivingEntity>
  {
    return await firstValueFrom(this.httpClient.get<DrivingEntity>(`https://localhost:5001/Driving/${studentName}`));
  }

  public async getDrivingByInstructor(instructorName: string): Promise<DrivingEntity>
  {
    return await firstValueFrom(this.httpClient.get<DrivingEntity>(`https://localhost:5001/Driving/${instructorName}`));
  }

  public async addDrivingToStudent(studentName: string, driving: DrivingEntity): Promise<StudentEntity>
  {
    return await firstValueFrom(this.httpClient.post<StudentEntity>(`https://localhost:5001/Driving/${studentName}`, driving));
  }

  public async putDriving(driving: DrivingEntity): Promise<DrivingEntity>
  {
    return await firstValueFrom(this.httpClient.put<DrivingEntity>("https://localhost:5001/Driving", driving));
  }
  public async deleteDriving(id: number): Promise<DrivingEntity>
  {
    return await firstValueFrom(this.httpClient.delete<DrivingEntity>(`https://localhost:5001/Student/${id}`));
  }
}
