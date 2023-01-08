import { Component, Input, OnInit } from '@angular/core';
import { EventEntity } from 'src/entities/event.entity';

@Component({
  selector: 'calendar-table',
  templateUrl: './calendar-table.component.html',
  styleUrls: ['./calendar-table.component.css']
})
export class CalendarTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() events: Array<EventEntity>;

}
