import { Component, OnInit } from '@angular/core';
import { DrivingEntity } from 'src/entities/DrivingEntity';
import { InternalExamEntity } from 'src/entities/InternalExamEntity';
import { LectureEntity } from 'src/entities/LectureEntity';

@Component({
  selector: 'calendar-form',
  templateUrl: './calendar-form.component.html',
  styleUrls: ['./calendar-form.component.css']
})
export class CalendarFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public formMode = "";

  public selectFormMode(formMode: string) {
    this.formMode = formMode;
  }

  public lecture: LectureEntity = new LectureEntity();
  public driving: DrivingEntity = new DrivingEntity();
  public internalExam: InternalExamEntity = new InternalExamEntity();

}
