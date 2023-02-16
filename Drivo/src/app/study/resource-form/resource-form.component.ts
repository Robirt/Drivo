import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ResourceEntity } from 'src/entities/resource.entity';

@Component({
  selector: 'resource-form',
  templateUrl: './resource-form.component.html',
  styleUrls: ['./resource-form.component.css']
})
export class ResourceFormComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  public resource: ResourceEntity = new ResourceEntity();
  
  @Output() onAddResource: EventEmitter<ResourceEntity> = new EventEmitter<ResourceEntity>();

  public async addResourceAsync(): Promise<void> 
  {
    this.onAddResource.emit(this.resource);

    this.resource = new ResourceEntity();
  }

  public async changeResourceImageAsync(event: any): Promise<void> {
    let fileReader = new FileReader();
    fileReader.readAsDataURL(event.target.files[0]);
    fileReader.onload = () => {
      this.resource.image = String(fileReader.result?.toString().split(',')[1]);
    };
  }
}
