import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StudentEntity } from 'src/entities/StudentEntity';

@Component({
  selector: 'app-student-table',
  templateUrl: './student-table.component.html',
  styleUrls: ['./student-table.component.css']
})
export class StudentTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
@Input() students: Array<StudentEntity>;

@Output() onEdit: EventEmitter<StudentEntity> = new EventEmitter<StudentEntity>();

@Output() onDelete: EventEmitter<StudentEntity> = new EventEmitter<StudentEntity>();

public edit(student: StudentEntity): void {
  this.onEdit.emit(student);
}

public delete(student: StudentEntity): void {
  this.onDelete.emit(student);
}
}
