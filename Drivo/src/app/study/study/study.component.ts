import { Component, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CourseModulesService } from 'src/app/services/course-modules.service';
import { CourseModuleEntity } from 'src/entities/course-module.entity';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'study',
  templateUrl: './study.component.html',
  styleUrls: ['./study.component.css']
})
export class StudyComponent implements OnInit {

  constructor(private courseModuleService: CourseModulesService ) { }

  async ngOnInit(): Promise<void> {
    await this.getCourseModulesAsync();
  }
  
  public courseModules: Array<CourseModuleEntity> = new Array<CourseModuleEntity>();

  public actionResponse: ActionResponse = new ActionResponse();

  public async getCourseModulesAsync(): Promise<void> {
    this.courseModules = await this.courseModuleService.getCourseModulesAsync();
  }

  public async addCourseModuleAsync(courseModule: CourseModuleEntity): Promise<void> {
    this.actionResponse = await this.courseModuleService.addCourseModuleAsync(courseModule);

    await this.getCourseModulesAsync();
  }
  
  public async updateCourseModuleAsync(courseModule: CourseModuleEntity): Promise<void> {
    this.actionResponse = await this.courseModuleService.updateCourseModuleAsync(courseModule);

    await this.getCourseModulesAsync();
  }

  public async removeCourseModuleAsync(courseModule: CourseModuleEntity): Promise<void> {
    this.actionResponse = await this.courseModuleService.removeCourseModuleAsync(courseModule);

    await this.getCourseModulesAsync();
  }
}
