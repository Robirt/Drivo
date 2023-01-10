import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LecturersService } from 'src/app/services/lecturers.service';
import { StudentsGroupsService } from 'src/app/services/students-groups.service';
import { LecturerEntity } from 'src/entities/LecturerEntity';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'lecturers-lecturer',
  templateUrl: './lecturer.component.html',
  styleUrls: ['./lecturer.component.css']
})
export class LecturerComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private lecturersService: LecturersService, private studentsGroupService: StudentsGroupsService) {
    this.activatedRoute.params.subscribe((params) => { this.userName = params['userName']; });
   }

  async ngOnInit(): Promise<void> {
    await this.getLecturerByUserNameAsync();

    await this.getStudentsGroupsAsync();
  }

  public userName: string = "";

  public lecturer: LecturerEntity = new LecturerEntity();

  public actionResponse: ActionResponse = new ActionResponse();

  public studentsGroups: Array<StudentsGroupEntity> = new Array<StudentsGroupEntity>();
  public selectedStudentsGroup: StudentsGroupEntity = new StudentsGroupEntity();

  public async getLecturerByUserNameAsync(): Promise<void> {
    this.lecturer = await this.lecturersService.getLecturerByUserNameAsync(this.userName);
  }

  public async updateLecturerAsync(): Promise<void> {
    this.actionResponse = await this.lecturersService.updateLecturerAsync(this.lecturer);
  }

  public async getStudentsGroupsAsync(): Promise<void> {
    this.studentsGroups = await this.studentsGroupService.getStudentsGroupsAsync();
  }

}
