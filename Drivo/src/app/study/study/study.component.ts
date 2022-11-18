import { Component, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { CourseModulService } from 'src/app/services/course-modul.service';
import { CourseModulEntity } from 'src/entities/CourseModulEntity';

@Component({
  selector: 'study-study',
  templateUrl: './study.component.html',
  styleUrls: ['./study.component.css']
})
export class StudyComponent implements OnInit {

  constructor(private courseModul: CourseModulService ) { }

  async ngOnInit(): Promise<void> {
    

  }
public studies: Array<CourseModulEntity> = new Array<CourseModulEntity>();
public study: CourseModulEntity;
public async getCourseModuls(): Promise<void>
{
 this.studies = await this.courseModul.getCourseModuls();
}

public async getCourseModulByTitle(title: string): Promise<void>
{
  this.study = await this.courseModul.getCourseModulByTitle(title);
}

public async searchCourseModulByTitle(searchString: string): Promise<void>
{
  this.studies= await this.courseModul.searchCourseModulByTitle(searchString);
}

public async addCourseModul(courseModul: CourseModulEntity): Promise<void>
{
  this.study = await this.courseModul.addCourseModul(courseModul);
}

public async putCourseModul(courseModul: CourseModulEntity): Promise<void>
{
  this.study = await this.courseModul.putCourseModul(courseModul);
}

public async deleteCourseModul(id: number): Promise<void>
{
  this.study = await this.courseModul.deleteCourseModul(id);
}
}
