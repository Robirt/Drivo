import { Component, OnInit } from '@angular/core';
import { InstructorEntity } from 'src/entities/InstructorEntity';

@Component({
  selector: 'app-instructor',
  templateUrl: './instructor.component.html',
  styleUrls: ['./instructor.component.css']
})
export class InstructorComponent implements OnInit {

  constructor() { }

  async ngOnInit(): Promise<void> {
    let instructor = new InstructorEntity();
    instructor.firstName = "Alan";
    instructor.surname = "Wik";
    this.instructor.push(instructor);
  }
  public instructor: Array<InstructorEntity> = new Array<InstructorEntity>(); 
}
