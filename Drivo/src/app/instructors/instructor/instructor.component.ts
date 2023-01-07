import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { InstructorsService } from 'src/app/services/instructors.service';
import { StudentsService } from 'src/app/services/students.service';
import { InstructorEntity } from 'src/entities/InstructorEntity';
import { StudentEntity } from 'src/entities/StudentEntity';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'instructor',
  templateUrl: './instructor.component.html',
  styleUrls: ['./instructor.component.css']
})
export class InstructorComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private instructorsService: InstructorsService, private studentsService: StudentsService) {
    this.activatedRoute.params.subscribe((params) => { this.userName = params['userName']; });
   }

  async ngOnInit(): Promise<void> {
    await this.getInstructorByUserNameAsync();

    await this.getStudentsAsync();

    console.log(this.instructor);
  }

  public userName: string = "";

  public instructor: InstructorEntity = new InstructorEntity();

  public actionResponse: ActionResponse = new ActionResponse();

  public students: Array<StudentEntity> = new Array<StudentEntity>();
  public selectedStudent: StudentEntity = new StudentEntity();

  public async getInstructorByUserNameAsync(): Promise<void> {
    this.instructor = await this.instructorsService.getInstructorByUserNameAsync(this.userName);
  }

  public async getStudentsAsync(): Promise<void> {
    this.students = await this.studentsService.getStudentsAsync();
  }

}