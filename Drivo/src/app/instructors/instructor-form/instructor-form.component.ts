import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CreateUserRequest } from 'src/requests/createUser.request';

@Component({
  selector: 'app-instructor-form',
  templateUrl: './instructor-form.component.html',
  styleUrls: ['./instructor-form.component.css']
})
export class InstructorFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public createUserRequest: CreateUserRequest = new CreateUserRequest();
  
  @Output() onCreateInstructor: EventEmitter<CreateUserRequest> = new EventEmitter<CreateUserRequest>();

  public async createInstructorAsync(): Promise<void> {
    this.onCreateInstructor.emit(this.createUserRequest);

    this.createUserRequest = new CreateUserRequest();
  }
}
