import { Component, OnInit } from '@angular/core';
import { StudentsService } from 'src/app/services/students.service';
import { StudentEntity } from 'src/entities/StudentEntity';
import { CreateUserRequest } from 'src/requests/createUser.request';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'app-student',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  constructor(private studentsService: StudentsService) { }

  async ngOnInit(): Promise<void> {
    await this.getStudentsAsync();
  }

  public students: Array<StudentEntity> = new Array<StudentEntity>(); 

  public actionResponse: ActionResponse = new ActionResponse();

  public async getStudentsAsync(): Promise<void> {
    this.students = await this.studentsService.getStudentsAsync();
  }

  public async createStudentAsync(createUserRequest: CreateUserRequest): Promise<void> {
    this.actionResponse = await this.studentsService.createStudentAsync(createUserRequest);

    await this.getStudentsAsync();
  }

  public async deleteStudentAsync(student: StudentEntity): Promise<void> {
    this.actionResponse = await this.studentsService.deleteStudentAsync(student.userName);

    await this.getStudentsAsync();
  }

}
