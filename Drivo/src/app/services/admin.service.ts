import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { AdminEntity } from 'src/entities/AdminEntity';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private httpClient: HttpClient) { }

  public async getAdmins(): Promise<Array<AdminEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<AdminEntity>>("https://localhost:5001/Admin"));
  }

  public async getAdminByName(name: string): Promise<AdminEntity>
  {
    return await firstValueFrom(this.httpClient.get<AdminEntity>(`https://localhost:5001/Admin/${name}`));
  }

  public async searchAdmin(searchString: string): Promise<Array<string>>
  {
    return await firstValueFrom(this.httpClient.get<Array<string>>(`https://localhost:5001/Admin/Search/${searchString}`));
  }

  public async postAdmin(admin: AdminEntity): Promise<AdminEntity>
  {
    return await firstValueFrom(this.httpClient.post<AdminEntity>("https://localhost:5001/Admin", admin));
  }

  public async putAdmin(admin: AdminEntity): Promise<AdminEntity>
  {
    return await firstValueFrom(this.httpClient.put<AdminEntity>("https://localhost:5001/Admin", admin));
  }

  public async deleteAdmin(id: number): Promise<AdminEntity>
  {
    return await firstValueFrom(this.httpClient.delete<AdminEntity>(`https://localhost:5001/Admin/${id}`));
  }
}
