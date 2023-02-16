import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';

@Component({
  selector: 'students-group-form',
  templateUrl: './students-group-form.component.html',
  styleUrls: ['./students-group-form.component.css']
})
export class StudentsGroupFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public studentsGroup: StudentsGroupEntity = new StudentsGroupEntity();

  @Output() onAddStudentsGroup: EventEmitter<StudentsGroupEntity> = new EventEmitter<StudentsGroupEntity>();

  public async addStudentsGroupAsync(): Promise<void> {
    this.onAddStudentsGroup.emit(this.studentsGroup);

    this.studentsGroup = new StudentsGroupEntity();
  }
}
