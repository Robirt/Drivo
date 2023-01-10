import { Component, OnInit } from '@angular/core';
import { StudentsGroupsService } from 'src/app/services/students-groups.service';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'students-groups',
  templateUrl: './students-groups.component.html',
  styleUrls: ['./students-groups.component.css']
})
export class StudentsGroupsComponent implements OnInit {

  constructor(private studentsGroupsService: StudentsGroupsService) { }

  async ngOnInit(): Promise<void> {
    await this.getStudentsGroupsAsync();
  }

  public studentsGroups: Array<StudentsGroupEntity> = new Array<StudentsGroupEntity>();

  public actionResponse: ActionResponse = new ActionResponse();

  public async getStudentsGroupsAsync(): Promise<void> {
    this.studentsGroups = await this.studentsGroupsService.getStudentsGroupsAsync();
  }

  public async addStudentsGroupAsync(studentsGroup: StudentsGroupEntity): Promise<void> {
    this.actionResponse = await this.studentsGroupsService.addStudentsGroupAsync(studentsGroup);

    await this.getStudentsGroupsAsync();
  }

  public async removeStudentsGroupAsync(studentsGroup: StudentsGroupEntity): Promise<void> {
    this.actionResponse = await this.studentsGroupsService.removeStudentsGroupAsync(studentsGroup.id);

    await this.getStudentsGroupsAsync();
  }

}
