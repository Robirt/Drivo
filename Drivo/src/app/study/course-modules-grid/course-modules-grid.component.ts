import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CourseModuleEntity } from 'src/entities/course-module.entity';


@Component({
  selector: 'course-modules-grid',
  templateUrl: './course-modules-grid.component.html',
  styleUrls: ['./course-modules-grid.component.css']
})
export class CourseModulesGridComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  @Input() courseModules: Array<CourseModuleEntity>;

  @Output() onAddCourseModule: EventEmitter<CourseModuleEntity> = new EventEmitter<CourseModuleEntity>();

  @Output() onRemoveCourseModule: EventEmitter<CourseModuleEntity> = new EventEmitter<CourseModuleEntity>();

  public async addCourseModuleAsync(courseModule: CourseModuleEntity): Promise<void> {
    this.onAddCourseModule.emit(courseModule);
  }

  public async removeCourseModuleAsync(courseModule: CourseModuleEntity): Promise<void> {
    this.onRemoveCourseModule.emit(courseModule);
  }

}
