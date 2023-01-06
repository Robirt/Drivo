import { Component, OnInit } from '@angular/core';
import { LecturersService } from 'src/app/services/lecturers.service';
import { LecturerEntity } from 'src/entities/LecturerEntity';
import { CreateUserRequest } from 'src/requests/createUser.request';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'lecturers',
  templateUrl: './lecturers.component.html',
  styleUrls: ['./lecturers.component.css']
})
export class LecturersComponent implements OnInit {

  constructor(private lecturersService: LecturersService) { }

  async ngOnInit(): Promise<void> {
    this.getLecturers();
  }
  
  public lecturers: Array<LecturerEntity> = new Array<LecturerEntity>();

  public actionResponse: ActionResponse = new ActionResponse();

  public async getLecturers(): Promise<void> {
    this.lecturers = await this.lecturersService.getLecturersAsync();
  }

  public async createLecturerAsync(createUserRequest: CreateUserRequest): Promise<void> {
    this.actionResponse = await this.lecturersService.createLecturerAsync(createUserRequest);

    await this.getLecturers();
  }

  public async deleteLecturerAsync(lecturer: LecturerEntity) {
    this.actionResponse = await this.lecturersService.deleteLecturerAsync(lecturer.userName);

    await this.getLecturers();
  }

}
