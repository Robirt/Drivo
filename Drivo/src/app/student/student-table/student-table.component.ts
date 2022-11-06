import { Component, Input, OnInit } from '@angular/core';
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
}
