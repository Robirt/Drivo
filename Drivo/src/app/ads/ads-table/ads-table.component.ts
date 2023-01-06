import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AdEntity } from 'src/entities/AdEntity';

@Component({
  selector: 'app-ads-table',
  templateUrl: './ads-table.component.html',
  styleUrls: ['./ads-table.component.css']
})
export class AdsTableComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() public ads: Array<AdEntity>;

  @Output() onRemoveAdAsync: EventEmitter<AdEntity> = new EventEmitter<AdEntity>();

  public async removeAdAsync(ad: AdEntity): Promise<void> {
    this.onRemoveAdAsync.emit(ad);
  }

}
