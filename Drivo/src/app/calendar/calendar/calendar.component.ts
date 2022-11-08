import { Component, OnInit } from '@angular/core';
import { EventEntity } from 'src/entities/EventEntity';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  public info: EventEntity
  public selectedDate: Date;
}
