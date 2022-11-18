import { Component, OnInit } from '@angular/core';
import { InstructorService } from 'src/app/services/instructor.service';
import { InstructorEntity } from 'src/entities/InstructorEntity';

@Component({
  selector: 'app-instructor',
  templateUrl: './instructor.component.html',
  styleUrls: ['./instructor.component.css']
})
export class InstructorComponent implements OnInit {

  constructor(private instructorService: InstructorService) { }

  async ngOnInit(): Promise<void> {
  
  }
  public instructors: Array<InstructorEntity> = new Array<InstructorEntity>(); 
  public instructor: InstructorEntity;

  public async getInstructors(): Promise<void>
  {
    this.instructors = await this.instructorService.getInstructors();
  }

  public async getInstructorByName(name: string): Promise<void>
  {
    this.instructor = await this.instructorService.getInstructorByName(name);
  }

  public async searchInstructor(searchString: string): Promise<void>
  {
    this.instructors = await this.instructorService.searchInstructor(searchString);
  }

  public async postInstructor(instructor: InstructorEntity): Promise<void>
  {
    this.instructor = await this.instructorService.postInstructor(instructor);
  }

  public async putInstructor(instructor: InstructorEntity): Promise<void>
  {
    this.instructor = await this.instructorService.putInstructor(instructor);
  }

  public async deleteInstructor(id: number): Promise<void>
  {
    this.instructor = await this.instructorService.deleteInstructor(id);
  }
}
