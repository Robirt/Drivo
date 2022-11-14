import { Component, Input, OnInit } from '@angular/core';
import { LecturerEntity } from 'src/entities/LecturerEntity';

@Component({
  selector: 'app-lecturer-table',
  templateUrl: './lecturer-table.component.html',
  styleUrls: ['./lecturer-table.component.css']
})
export class LecturerTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  @Input() lecturers: Array<LecturerEntity>;
}
