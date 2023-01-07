import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { StudentsGroupsService } from 'src/app/services/students-groups.service';
import { StudentsService } from 'src/app/services/students.service';
import { StudentEntity } from 'src/entities/StudentEntity';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private studentsService: StudentsService, private studentsGroupService: StudentsGroupsService) {
    this.activatedRoute.params.subscribe((params) => { this.userName = params['userName']; });
   }

  async ngOnInit(): Promise<void> {
    await this.getStudentByUserNameAsync();

    await this.getStudentsGroupsAsync();

    console.log(this.student);
  }

  public userName: string = "";

  public student: StudentEntity = new StudentEntity();

  public actionResponse: ActionResponse = new ActionResponse();

  public studentsGroups: Array<StudentsGroupEntity> = new Array<StudentsGroupEntity>();
  public selectedStudentsGroup: StudentsGroupEntity = new StudentsGroupEntity();

  public async getStudentByUserNameAsync(): Promise<void> {
    this.student = await this.studentsService.getStudentByUserNameAsync(this.userName);
  }

  public async getStudentsGroupsAsync(): Promise<void> {
    this.studentsGroups = await this.studentsGroupService.getStudentsGroupsAsync();
  }

}
