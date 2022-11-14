import { Component, Input, OnInit } from '@angular/core';
import { InstructorEntity } from 'src/entities/InstructorEntity';

@Component({
  selector: 'app-instructor-table',
  templateUrl: './instructor-table.component.html',
  styleUrls: ['./instructor-table.component.css']
})
export class InstructorTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  @Input() instructors: Array<InstructorEntity>;
}
