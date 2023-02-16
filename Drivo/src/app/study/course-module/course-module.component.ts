import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseModulesService } from 'src/app/services/course-modules.service';
import { ResourcesService } from 'src/app/services/resources.service';
import { CourseModuleEntity } from 'src/entities/course-module.entity';
import { ResourceEntity } from 'src/entities/resource.entity';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'course-module',
  templateUrl: './course-module.component.html',
  styleUrls: ['./course-module.component.css']
})
export class CourseModuleComponent implements OnInit {

  constructor(private activatedRoute: ActivatedRoute, private courseModulesService: CourseModulesService, private resourcesService: ResourcesService) {
    this.activatedRoute.params.subscribe((params) => { this.courseModuleName = params['courseModuleName']; });
  }

  async ngOnInit(): Promise<void> {
    await this.getCourseModuleByNameAsync();
  }

  public courseModuleName: string = "";

  public courseModule: CourseModuleEntity = new CourseModuleEntity();

  public actionResponse: ActionResponse = new ActionResponse();

  public async getCourseModuleByNameAsync(): Promise<void> {
    this.courseModule = await this.courseModulesService.getCourseModuleByNameAsync(this.courseModuleName);
  }

  public async addResourceAsync(resource: ResourceEntity): Promise<void> {
    resource.courseModuleId = this.courseModule.id;

    this.actionResponse = await this.resourcesService.addResourceAsync(resource);

    await this.getCourseModuleByNameAsync();
  }

  public async updateResourceAsync(resource: ResourceEntity): Promise<void> {
    this.actionResponse = await this.resourcesService.updateResourceAsync(resource);

    await this.getCourseModuleByNameAsync();
  }


  public async removeResourceAsync(resource: ResourceEntity): Promise<void> {
    this.actionResponse = await this.resourcesService.removeResourceAsync(resource);

    await this.getCourseModuleByNameAsync();
  }

}
