import { Component, OnInit } from '@angular/core';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';

@Component({
  selector: 'study-study',
  templateUrl: './study.component.html',
  styleUrls: ['./study.component.css']
})
export class StudyComponent implements OnInit {

  constructor() { }

  async ngOnInit(): Promise<void> {
    let study= new CourseModulEntity();
    study.category = "Znaki nakazu";
    this.study.push(study);
    this.study.push(study);
    this.study.push(study);
    this.study.push(study);
    this.study.push(study);
    this.study.push(study);
    this.study.push(study);
    this.study.push(study);
    this.study.push(study);

  }
public study: Array<CourseModulEntity> = new Array<CourseModulEntity>();
}
