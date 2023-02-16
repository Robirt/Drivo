import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ResourceEntity } from 'src/entities/resource.entity';

@Component({
  selector: 'resources-grid',
  templateUrl: './resources-grid.component.html',
  styleUrls: ['./resources-grid.component.css']
})
export class ResourcesGridComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  @Input() resources: Array<ResourceEntity>;

  @Output() onAddResource: EventEmitter<ResourceEntity> = new EventEmitter<ResourceEntity>();

  @Output() onUpdateResource: EventEmitter<ResourceEntity> = new EventEmitter<ResourceEntity>();

  @Output() onRemoveResource: EventEmitter<ResourceEntity> = new EventEmitter<ResourceEntity>();

  public async addResourceAsync(resource: ResourceEntity): Promise<void> {
    this.onAddResource.emit(resource);
  }

  public async updateResourceAsync(resource: ResourceEntity): Promise<void> {
    this.onUpdateResource.emit(resource);
  }

  public async removeResourceAsync(resource: ResourceEntity): Promise<void> {
    this.onRemoveResource.emit(resource);
  }

}
