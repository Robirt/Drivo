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
    let student= new StudentEntity();
    student.firstName = "Kazimierz";
    student.surname = "Wielki";
    student.birthDate = new Date('02-02-1998');
    student
    this.student.push(student);
    this.student.push(student);
    this.student.push(student);
    this.student.push(student);
    this.getStudents();
  }
public student: Array<StudentEntity> = new Array<StudentEntity>(); 

public async getStudents()
{
  await this.studentsService.getStudents();
}
public async getStudent(id: number)
{
  await this.studentsService.getStudent(id);
}

public async postStudent(student:StudentEntity)
{
  await this.studentsService.postStudent(student);
}

public async putStudent(student:StudentEntity)
{
  await this.studentsService.putStudent(student);
}

public async deleteStudent(id: number)
{
  await this.studentsService.deleteStudent(id);
}
}
