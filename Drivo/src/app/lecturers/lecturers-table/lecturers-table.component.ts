import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { LecturerEntity } from 'src/entities/LecturerEntity';

@Component({
  selector: 'app-lecturers-table',
  templateUrl: './lecturers-table.component.html',
  styleUrls: ['./lecturers-table.component.css']
})
export class LecturersTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() lecturers: Array<LecturerEntity>;

  @Output() onDeleteLecturer: EventEmitter<LecturerEntity> = new EventEmitter<LecturerEntity>();

  public async deleteLecturerAsync(lecturer: LecturerEntity) {
    this.onDeleteLecturer.emit(lecturer);
  }

}
