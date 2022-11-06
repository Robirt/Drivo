import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResourcesComponent } from './resources/resources.component';
import { ResourcesGridComponent } from './resources-grid/resources-grid.component';
import { ResourcesItemComponent } from './resources-item/resources-item.component';
import { ResourcesFormComponent } from './resources-form/resources-form.component';



@NgModule({
  declarations: [
    ResourcesComponent,
    ResourcesGridComponent,
    ResourcesItemComponent,
    ResourcesFormComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ResourcesModule { }
