import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CourseModuleEntity } from 'src/entities/course-module.entity';

@Component({
  selector: 'course-module-form',
  templateUrl: './course-module-form.component.html',
  styleUrls: ['./course-module-form.component.css']
})
export class CourseModuleFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public courseModule: CourseModuleEntity = new CourseModuleEntity();
  
  @Output() onAddCourseModule: EventEmitter<CourseModuleEntity> = new EventEmitter<CourseModuleEntity>();

  public async addCourseModuleAsync(): Promise<void> {
    this.onAddCourseModule.emit(this.courseModule);

    this.courseModule = new CourseModuleEntity();
  }

  public async changeCourseModuleImageAsync(event: any): Promise<void> {
    let fileReader = new FileReader();
    fileReader.readAsDataURL(event.target.files[0]);
    fileReader.onload = () => {
      console.log(fileReader.result?.toString());
      console.log(fileReader.result?.toString().split(',')[1]);
      this.courseModule.image = String(fileReader.result?.toString().split(',')[1]);
    };
  }

}
