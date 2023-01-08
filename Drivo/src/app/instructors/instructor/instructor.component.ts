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
  }

  public userName: string = "";

  public instructor: InstructorEntity = new InstructorEntity();

  public actionResponse: ActionResponse = new ActionResponse();

  public students: Array<StudentEntity> = new Array<StudentEntity>();
  public selectedStudent: StudentEntity = new StudentEntity();

  public async getInstructorByUserNameAsync(): Promise<void> {
    this.instructor = await this.instructorsService.getInstructorByUserNameAsync(this.userName);
  }

  public async updateInstructorAsync(): Promise<void> {
    this.actionResponse = await this.instructorsService.updateInstructorAsync(this.instructor);
  }

  public async getStudentsAsync(): Promise<void> {
    this.students = await this.studentsService.getStudentsAsync();

    this.students = this.students.filter(student => !this.instructor.students.includes(student));
  }

  public async removeStudentFromInstructorAsync(student: StudentEntity): Promise<void> {
    this.instructor.students.splice(this.instructor.students.findIndex(s => s == student), 1);

    await this.getStudentsAsync();
  }

  public async addStudentToInstructorAsync(): Promise<void> {
    this.instructor.students.push(this.selectedStudent);

    await this.getStudentsAsync();

    this.selectedStudent = this.students[0];
  }

}
