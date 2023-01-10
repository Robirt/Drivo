import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { DrivingService } from 'src/app/services/drivings.service';
import { InstructorsService } from 'src/app/services/instructors.service';
import { InternalExamsService } from 'src/app/services/internal-exams.service';
import { LecturersService } from 'src/app/services/lecturers.service';
import { LecturesService } from 'src/app/services/lectures.service';
import { UserService } from 'src/app/services/user.service';
import { DrivingEntity } from 'src/entities/DrivingEntity';
import { EventEntity } from 'src/entities/event.entity';
import { InstructorEntity } from 'src/entities/InstructorEntity';
import { InternalExamEntity } from 'src/entities/InternalExamEntity';
import { LectureEntity } from 'src/entities/LectureEntity';
import { LecturerEntity } from 'src/entities/LecturerEntity';
import { StudentEntity } from 'src/entities/StudentEntity';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';
import { UserEntity } from 'src/entities/user.entity';
import { DayModel } from 'src/models/day.model';
import { UserModel } from 'src/models/user.model';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {

  constructor(private userService: UserService, private lecturersService: LecturersService, private instructorsService: InstructorsService, private lecturesService: LecturesService, private drivingsService: DrivingService, private internalExamsService: InternalExamsService) { }

  async ngOnInit(): Promise<void> {
    await this.getUserAsync();
  }

  public days: Array<DayModel> = new Array<DayModel>();

  public selectedDay: DayModel = new DayModel();

  public user: UserEntity = new UserEntity();
  public userModel: UserModel | null = new UserModel();

  public actionResponse: ActionResponse = new ActionResponse();

  public events: Array<any> = new Array<EventEntity>();

  public studentsGroups: Array<StudentsGroupEntity> = new Array<StudentsGroupEntity>();
  public students: Array<StudentEntity> = new Array<StudentEntity>();

  public async getUserAsync(): Promise<void> {
    this.events = new Array<any>();
    this.days = new Array<DayModel>();

    this.studentsGroups = new Array<StudentsGroupEntity>();
    this.students = new Array<StudentEntity>();

    this.userModel = this.userService.getUser();

    if (this.userModel?.role == 'Lecturer') {
      this.user = await this.lecturersService.getLecturerByUserNameAsync(this.userModel.name);

      this.events = this.events.concat((this.user as LecturerEntity).lectures);

      this.studentsGroups = this.studentsGroups.concat((this.user as LecturerEntity).studentsGroups)
    }

    else if (this.userModel?.role == 'Instructor') {
      this.user = await this.instructorsService.getInstructorByUserNameAsync(this.userModel.name);
      
      this.events = this.events.concat((this.user as InstructorEntity).drivings).concat((this.user as InstructorEntity).internalExams);

      this.students = this.students.concat((this.user as InstructorEntity).students);
    }

    await this.initDays();
  }

  private async initDays(): Promise<void> {
    for (let iterator = 0; iterator < 14; iterator++) {
      let day: DayModel = new DayModel();

      let date = new Date();
      day.date = new Date(date.setDate(date.getDate() + iterator));
      day.events = day.events.concat(this.events.filter(event => new Date(event.startDate).toDateString() == new Date(day.date).toDateString()));

      this.days.push(day);
    }
  }

  public async onSelectedDayChangeAsync(selectedDay: DayModel): Promise<void> {
    await this.getUserAsync();

    this.events = this.events.filter(event => new Date(event.startDate).toDateString() == new Date(selectedDay.date).toDateString());
  }

  public async addLectureAsync(lecture: LectureEntity): Promise<void> {
    lecture.lecturerId = this.user.id;

    this.actionResponse = await this.lecturesService.addLectureAsync(lecture);

    await this.getUserAsync()
  }

  public async addDrivingAsync(driving: DrivingEntity): Promise<void> {
    driving.instructorId = this.user.id;

    this.actionResponse = await this.drivingsService.addDrivingAsync(driving);

    await this.getUserAsync();
  }

  public async addInternalExamAsync(internalExam: InternalExamEntity): Promise<void> {
    internalExam.instructorId = this.user.id;

    this.actionResponse = await this.internalExamsService.addInternalExamAsync(internalExam);

    await this.getUserAsync();
  }

  public async removeEventAsync(removeData: any) {
    
  }

}
