import { Component, OnInit } from '@angular/core';
import { firstValueFrom } from 'rxjs';
import { ResourceService } from 'src/app/services/resource.service';
import { ResourceEntity } from 'src/entities/ResourceEntity';

@Component({
  selector: 'app-resources',
  templateUrl: './resources.component.html',
  styleUrls: ['./resources.component.css']
})
export class ResourcesComponent implements OnInit {

  constructor(private resourceService: ResourceService) { }

  ngOnInit(): void {
  }
public resource: ResourceEntity
public resources: Array<ResourceEntity> = new Array<ResourceEntity>();

public async getResourceByTitle(title: string): Promise<void>
{
  //this.resource = await this.resourceService.(title);
}

public async putResource(resource: ResourceEntity): Promise<void>
{
  this.resource = await this.resourceService.updateResourceAsync(resource);
}

public async deleteResource(title: string): Promise<void>
{
  //await this.resourceService.removeResourceAsync(title);
} 
}
