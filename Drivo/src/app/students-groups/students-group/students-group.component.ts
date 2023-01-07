import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';

@Component({
  selector: 'students-group',
  templateUrl: './students-group.component.html',
  styleUrls: ['./students-group.component.css']
})
export class StudentsGroupComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() studentsGroup: StudentsGroupEntity;

  @Output() onAddStudentsGroup: EventEmitter<StudentsGroupEntity> = new EventEmitter<StudentsGroupEntity>();

  @Output() onRemoveStudentsGroup: EventEmitter<StudentsGroupEntity> = new EventEmitter<StudentsGroupEntity>();

  public async removeStudentsGroupAsync(): Promise<void> {
    await this.onRemoveStudentsGroup.emit(this.studentsGroup);
  }

}
