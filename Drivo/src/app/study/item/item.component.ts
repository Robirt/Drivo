import { Component, Input, OnInit } from '@angular/core';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';

@Component({
  selector: 'study-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
@Input() study: CourseModulEntity;
}
