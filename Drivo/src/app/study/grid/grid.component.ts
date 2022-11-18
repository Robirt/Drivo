import { Component, Input, OnInit } from '@angular/core';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';


@Component({
  selector: 'study-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.css']
})
export class GridComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
@Input() studies: Array<CourseModulEntity> = new Array<CourseModulEntity>();
}
