import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ResourceEntity } from 'src/entities/resource.entity';

@Component({
  selector: 'resource-tile',
  templateUrl: './resource-tile.component.html',
  styleUrls: ['./resource-tile.component.css']
})
export class ResourceTileComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() resource: ResourceEntity;

  @Output() onUpdateResource: EventEmitter<ResourceEntity> = new EventEmitter<ResourceEntity>();

  @Output() onRemoveResource: EventEmitter<ResourceEntity> = new EventEmitter<ResourceEntity>();

  public async changeResourceImageAsync(event: any): Promise<void> {
    let fileReader = new FileReader();
    fileReader.readAsDataURL(event.target.files[0]);
    fileReader.onload = () => {
      this.resource.image = String(fileReader.result?.toString().split(',')[1]);
    };
  }

  public async updateResourceAsync(): Promise<void> {
    this.onUpdateResource.emit(this.resource);
  }

  public async removeResourceAsync(): Promise<void> {
    this.onRemoveResource.emit(this.resource);
  }

}
