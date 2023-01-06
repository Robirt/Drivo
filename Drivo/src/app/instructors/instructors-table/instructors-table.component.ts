import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { InstructorEntity } from 'src/entities/InstructorEntity';

@Component({
  selector: 'app-instructors-table',
  templateUrl: './instructors-table.component.html',
  styleUrls: ['./instructors-table.component.css']
})
export class InstructorsTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() instructors: Array<InstructorEntity>;

  @Output() onDeleteInstructor: EventEmitter<InstructorEntity> = new EventEmitter<InstructorEntity>();

  public async deleteInstructorAsync(instructor: InstructorEntity): Promise<void> {
    this.onDeleteInstructor.emit(instructor);
  }

}
