import { Component, OnInit } from '@angular/core';
import { LecturerService } from 'src/app/services/lecturer.service';
import { LecturerEntity } from 'src/entities/LecturerEntity';

@Component({
  selector: 'app-lecturer',
  templateUrl: './lecturer.component.html',
  styleUrls: ['./lecturer.component.css']
})
export class LecturerComponent implements OnInit {

  constructor(private lecturerService: LecturerService) { }

  async ngOnInit(): Promise<void> {
    
  }
public lecturers: Array<LecturerEntity> = new Array<LecturerEntity>();
public lecturer: LecturerEntity;

public async getLecturers(): Promise<void>
{
  this.lecturers = await this.lecturerService.getLecturers();
}

public async getLecturersByName(name: string): Promise<void>
{
  this.lecturer = await this.lecturerService.getLecturersByName(name);
}

public async searchLecturer(searchString: string): Promise<void>
{
  this.lecturers =  await this.lecturerService.searchLecturer(searchString);
}

public async postLecturer(lecturer: LecturerEntity): Promise<void>
{
  this.lecturer = await this.lecturerService.postLecturer(lecturer);
}
public async putLecturer(lecturer: LecturerEntity): Promise<void>
{
  this.lecturer = await this.lecturerService.putLecturer(lecturer);
}

public async deleteLecturer(id: number): Promise<void>
{
  this.lecturer = await this.lecturerService.deleteLecturer(id);
}
}
