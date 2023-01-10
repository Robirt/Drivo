import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DrivingEntity } from 'src/entities/DrivingEntity';
import { InternalExamEntity } from 'src/entities/InternalExamEntity';
import { LectureEntity } from 'src/entities/LectureEntity';
import { StudentEntity } from 'src/entities/StudentEntity';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';
import { UserEntity } from 'src/entities/user.entity';
import { UserModel } from 'src/models/user.model';

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

  @Input() role: string | undefined;

  public lecture: LectureEntity = new LectureEntity();
  public driving: DrivingEntity = new DrivingEntity();
  public internalExam: InternalExamEntity = new InternalExamEntity();

  @Output() onAddLecture: EventEmitter<LectureEntity> = new EventEmitter<LectureEntity>();
  @Output() onAddDriving: EventEmitter<DrivingEntity> = new EventEmitter<DrivingEntity>();
  @Output() onAddInternalExam: EventEmitter<InternalExamEntity> = new EventEmitter<InternalExamEntity>();

  @Input() studentsGroups: Array<StudentsGroupEntity>;
  @Input() students: Array<StudentEntity>;

  public async addLectureAsync(): Promise<void> {
    this.onAddLecture.emit(this.lecture);
  }

  public async addDrivingAsync(): Promise<void> {
    this.onAddDriving.emit(this.driving);
  }

  public async addInternalExamAsync(): Promise<void> {
    this.onAddInternalExam.emit(this.internalExam);
  }

}
