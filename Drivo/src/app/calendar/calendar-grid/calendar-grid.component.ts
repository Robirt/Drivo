import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DayModel } from 'src/models/day.model';

@Component({
  selector: 'calendar-grid',
  templateUrl: './calendar-grid.component.html',
  styleUrls: ['./calendar-grid.component.css']
})
export class CalendarGridComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

  }

  @Input() days: Array<DayModel> = new Array<DayModel>();

  @Input() selectedDay: DayModel = new DayModel();

  @Output() selectedDayChange: EventEmitter<DayModel> = new EventEmitter<DayModel>();

  public async selectDayAsync(day: DayModel): Promise<void> {
    this.selectedDayChange.emit(day);
  }

}
