import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { LecturerEntity } from 'src/entities/LecturerEntity';

@Component({
  selector: 'app-lecturer-form',
  templateUrl: './lecturer-form.component.html',
  styleUrls: ['./lecturer-form.component.css']
})
export class LecturerFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  public lecturer: LecturerEntity = new LecturerEntity()
  @Output() onAdd: EventEmitter<LecturerEntity> = new EventEmitter<LecturerEntity>();
  public add(lecturer: LecturerEntity)
  {
    this.onAdd.emit(lecturer);
    lecturer = new LecturerEntity;
  }
}
