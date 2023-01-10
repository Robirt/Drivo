import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { StudentsGroupEntity } from 'src/entities/StudentsGroupEntity';

@Component({
  selector: 'students-groups-grid',
  templateUrl: './students-groups-grid.component.html',
  styleUrls: ['./students-groups-grid.component.css']
})
export class StudentsGroupsGridComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() studentsGroups: Array<StudentsGroupEntity>;

  @Output() onAddStudentsGroup: EventEmitter<StudentsGroupEntity> = new EventEmitter<StudentsGroupEntity>();

  @Output() onRemoveStudentsGroup: EventEmitter<StudentsGroupEntity> = new EventEmitter<StudentsGroupEntity>();

  public async removeStudentsGroupAsync(studentsGroup: StudentsGroupEntity): Promise<void> {
    this.onRemoveStudentsGroup.emit(studentsGroup);
  }

  public async addStudentsGroupAsync(studentsGroup: StudentsGroupEntity): Promise<void> {
    this.onAddStudentsGroup.emit(studentsGroup);
  }

}
