import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CreateUserRequest } from 'src/requests/createUser.request';

@Component({
  selector: 'lecturers-form',
  templateUrl: './lecturer-form.component.html',
  styleUrls: ['./lecturer-form.component.css']
})
export class LecturerFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public createUserRequest: CreateUserRequest = new CreateUserRequest();

  @Output() onCreateLecturer: EventEmitter<CreateUserRequest> = new EventEmitter<CreateUserRequest>();

  public async createLecturerAsync(): Promise<void> {
    this.onCreateLecturer.emit(this.createUserRequest);

    this.createUserRequest = new CreateUserRequest();
  }
}
