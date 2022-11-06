import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { InstructorEntity } from 'src/entities/InstructorEntity';

@Component({
  selector: 'app-instructor-form',
  templateUrl: './instructor-form.component.html',
  styleUrls: ['./instructor-form.component.css']
})
export class InstructorFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  public instructor: InstructorEntity = new InstructorEntity()
  @Output() onAdd: EventEmitter<InstructorEntity> = new EventEmitter<InstructorEntity>();
  public add(instructor: InstructorEntity)
  {
    this.onAdd.emit(instructor);
    instructor = new InstructorEntity;
  }
}
