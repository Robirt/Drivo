import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    this.days.push(1);
    this.days.push(2);
    this.days.push(3);
    this.days.push(4);
    this.days.push(5);
    this.days.push(6);
    this.days.push(7);
    this.days.push(8);
  }

  public days: number[] = new Array<number>();

}
