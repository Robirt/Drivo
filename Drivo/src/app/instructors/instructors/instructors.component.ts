import { Component, OnInit } from '@angular/core';
import { InstructorsService } from 'src/app/services/instructors.service';
import { InstructorEntity } from 'src/entities/InstructorEntity';
import { CreateUserRequest } from 'src/requests/createUser.request';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'app-instructors',
  templateUrl: './instructors.component.html',
  styleUrls: ['./instructors.component.css']
})
export class InstructorsComponent implements OnInit {

  constructor(private instructorService: InstructorsService) { }

  async ngOnInit(): Promise<void> {
  }

  public instructors: Array<InstructorEntity> = new Array<InstructorEntity>(); 

  public actionResponse: ActionResponse = new ActionResponse();

  public async getInstructors(): Promise<void> {
    this.instructors = await this.instructorService.getInstructorsAsync();
  }

  public async createInstructorAsync(createUserRequest: CreateUserRequest): Promise<void> {
    this.actionResponse = await this.instructorService.createInstructorAsync(createUserRequest);

    await this.getInstructors();
  }

  public async deleteInstructorAsync(instructor: InstructorEntity): Promise<void> {
    this.actionResponse = await this.instructorService.deleteInstructor(instructor.userName);

    await this.getInstructors();
  }

}
