import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
public study: CourseModulEntity = new CourseModulEntity()
@Output() onAdd: EventEmitter<CourseModulEntity> = new EventEmitter<CourseModulEntity>();
public add()
{
  this.onAdd.emit(this.study);
  this.study = new CourseModulEntity;
}
}
