import { Component, OnInit } from '@angular/core';
import { StudentsService } from 'src/app/services/students.service';
import { StudentEntity } from 'src/entities/StudentEntity';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  constructor(private studentsService: StudentsService) { }

  async ngOnInit(): Promise<void> {
   
  }
public students: Array<StudentEntity> = new Array<StudentEntity>(); 
public student: StudentEntity
public async getStudents(): Promise<void>
{
  this.students = await this.studentsService.getStudents();
}
public async getStudentByName(name: string): Promise<void>
{
  this.student =await this.studentsService.getStudentByName(name);
}

public async searchStudent(searchString: string): Promise<void>
{
  this.students = await this.studentsService.searchStudent(searchString);
}

public async postStudent(student:StudentEntity): Promise<void>
{
  this.student = await this.studentsService.postStudent(student);
}

public async putStudent(student:StudentEntity): Promise<void>
{
  this.student = await this.studentsService.putStudent(student);
}

public async deleteStudent(id: number): Promise<void>
{
  this.student = await this.studentsService.deleteStudent(id);
}
}
