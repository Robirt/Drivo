import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { TypeEntity } from 'src/entities/TypeEntity';

@Injectable({
  providedIn: 'root'
})
export class TypeServiceService {

  constructor(private httpClient: HttpClient) { }
  public async getTypes(): Promise<Array<TypeEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<TypeEntity>>("https://localhost:5001/Type"));
  }

  public async postType(type: TypeEntity): Promise<TypeEntity>
  {
    return await firstValueFrom(this.httpClient.post<TypeEntity>("https://localhost:5001/Type", type));
  }

  public async putType(type: TypeEntity): Promise<TypeEntity>
  {
    return await firstValueFrom(this.httpClient.put<TypeEntity>("https://localhost:5001/Type", type));
  }

  public async deleteType(id: number): Promise<TypeEntity>
  {
    return await firstValueFrom(this.httpClient.delete<TypeEntity>(`https://localhost:5001/Type/${id}`));
  }
}
