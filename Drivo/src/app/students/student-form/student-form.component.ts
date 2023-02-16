import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { StudentEntity } from 'src/entities/StudentEntity';
import { CreateUserRequest } from 'src/requests/createUser.request';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public createUserRequest: CreateUserRequest = new CreateUserRequest();

  @Output() onCreateStudent: EventEmitter<CreateUserRequest> = new EventEmitter<CreateUserRequest>();

  public async createStudentAsync(): Promise<void> {
    this.onCreateStudent.emit(this.createUserRequest);

    this.createUserRequest = new CreateUserRequest();
  }
}
