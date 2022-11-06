import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AdEntity } from 'src/entities/AdEntity';
import { InstructorEntity } from 'src/entities/InstructorEntity';

@Component({
  selector: 'app-new-add',
  templateUrl: './new-add.component.html',
  styleUrls: ['./new-add.component.css']
})
export class NewAddComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

public ad: AdEntity = new AdEntity()
@Output() onAdd: EventEmitter<AdEntity> = new EventEmitter<AdEntity>();
public add(ad: AdEntity)
{
  this.onAdd.emit(ad);
  ad = new AdEntity;
}

}