import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { EventEntity } from 'src/entities/EventEntity';

@Injectable({
  providedIn: 'root'
})
export class EventService {

  
  constructor(private httpClient: HttpClient) { }

  public async getEvents(): Promise<Array<EventEntity>>
  {
    return await firstValueFrom(this.httpClient.get<Array<EventEntity>>("https://localhost:5001/Event"));
  }

  public async getEventById(id: number): Promise<EventEntity>
  {
    return await firstValueFrom(this.httpClient.get<EventEntity>(`https://localhost:5001/Event/${id}`));
  }
  
  public async getEventByType(type: string): Promise<EventEntity>
  {
    return await firstValueFrom(this.httpClient.get<EventEntity>(`https://localhost:5001/Event/${type}`));
  }

  public async addEvent(event: EventEntity): Promise<void>
  {
    return await firstValueFrom(this.httpClient.post<void>("https://localhost:5001/Event", event));
  }

  public async putEvent(event: EventEntity): Promise<EventEntity>
  {
    return await firstValueFrom(this.httpClient.put<EventEntity>("https://localhost:5001/Event", event));
  }

  public async deleteEvent(id: number): Promise<EventEntity>
  {
    return await firstValueFrom(this.httpClient.delete<EventEntity>(`https://localhost:5001/Event/${id}`));
    
  }
}
