import { Component, OnInit } from '@angular/core';
import { LecturerEntity } from 'src/entities/LecturerEntity';

@Component({
  selector: 'app-lecturer',
  templateUrl: './lecturer.component.html',
  styleUrls: ['./lecturer.component.css']
})
export class LecturerComponent implements OnInit {

  constructor() { }

  async ngOnInit(): Promise<void> {
    let lecturer = new LecturerEntity();
    lecturer.firstName = "Alan";
    lecturer.surname = "Wik";
    this.lecturer.push(lecturer);
  }
public lecturer: Array<LecturerEntity> = new Array<LecturerEntity>();
}
