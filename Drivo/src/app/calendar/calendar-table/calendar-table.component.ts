import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DayModel } from 'src/models/day.model';

@Component({
  selector: 'calendar-table',
  templateUrl: './calendar-table.component.html',
  styleUrls: ['./calendar-table.component.css']
})
export class CalendarTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() events: Array<any>;

  @Input() selectedDay: DayModel;

  @Output() onRemoveEvent: EventEmitter<any> = new EventEmitter<any>();

  public async removeEventAsync(event: any): Promise<void> {
    
  }
}
