import { Component, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CourseModulesService } from 'src/app/services/course-modules.service';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';

@Component({
  selector: 'study-study',
  templateUrl: './study.component.html',
  styleUrls: ['./study.component.css']
})
export class StudyComponent implements OnInit {

  constructor(private courseModul: CourseModulesService ) { }

  async ngOnInit(): Promise<void> {
    

  }
public studies: Array<CourseModulEntity> = new Array<CourseModulEntity>();
public study: CourseModulEntity;
public async getCourseModuls(): Promise<void>
{
 this.studies = await this.courseModul.getCourseModulesAsync();
}

public async getCourseModulByTitle(title: string): Promise<void>
{
  this.study = await this.courseModul.getCourseModuleByNameAsync(title);
}

public async searchCourseModulByTitle(searchString: string): Promise<void>
{
  this.studies= await this.courseModul.searchCourseModuleByNameAsync(searchString);
}

public async addCourseModul(courseModul: CourseModulEntity): Promise<void>
{
  await this.courseModul.addCourseModuleAsync(courseModul);
}

public async putCourseModul(courseModul: CourseModulEntity): Promise<void>
{
  await this.courseModul.updateCourseModuleAsync(courseModul);
}

public async deleteCourseModul(id: number): Promise<void>
{
  //await this.courseModul.removeCourseModuleAsync(id);
}
}
