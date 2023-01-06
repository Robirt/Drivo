import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StudentEntity } from 'src/entities/StudentEntity';

@Component({
  selector: 'app-student-table',
  templateUrl: './students-table.component.html',
  styleUrls: ['./students-table.component.css']
})
export class StudentsTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() students: Array<StudentEntity>;

  @Output() onDeleteStudent: EventEmitter<StudentEntity> = new EventEmitter<StudentEntity>();

  public async deleteStudentAsync(student: StudentEntity) {
    this.onDeleteStudent.emit(student);
  }
}
