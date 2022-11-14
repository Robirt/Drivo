import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { StudentEntity } from 'src/entities/StudentEntity';

@Component({
  selector: 'app-student-form',
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  public student: StudentEntity = new StudentEntity()
  @Output() onAdd: EventEmitter<StudentEntity> = new EventEmitter<StudentEntity>();
  public add(student: StudentEntity)
  {
    this.onAdd.emit(student);
    student = new StudentEntity;
  }
}
