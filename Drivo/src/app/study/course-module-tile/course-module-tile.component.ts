import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CourseModuleEntity } from 'src/entities/course-module.entity';

@Component({
  selector: 'course-module-tile',
  templateUrl: './course-module-tile.component.html',
  styleUrls: ['./course-module-tile.component.css']
})
export class CourseModuleTileComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  @Input() courseModule: CourseModuleEntity;

  @Output() onRemoveCourseModule: EventEmitter<CourseModuleEntity> = new EventEmitter<CourseModuleEntity>();

  public async removeCourseModuleAsync(): Promise<void> {
    this.onRemoveCourseModule.emit(this.courseModule);
  }
}
