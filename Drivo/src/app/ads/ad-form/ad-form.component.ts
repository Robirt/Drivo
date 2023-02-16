import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AdEntity } from 'src/entities/AdEntity';

@Component({
  selector: 'app-ad-form',
  templateUrl: './ad-form.component.html',
  styleUrls: ['./ad-form.component.css']
})
export class AdFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  public ad: AdEntity = new AdEntity()
  
  @Output() onAdd: EventEmitter<AdEntity> = new EventEmitter<AdEntity>();
  
  public async addAdAsync() {
    this.onAdd.emit(this.ad);

    this.ad = new AdEntity();
  }

}