import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ResourcesComponent } from './resources/resources.component';
import { ResourcesItemComponent } from './resources-item/resources-item.component';
import { ResourcesFormComponent } from './resources-form/resources-form.component';
import { CarouselModule } from 'primeng/carousel';
import { ResourcesCarouselComponent } from './resources-carousel/resources-carousel.component';



@NgModule({
  declarations: [
    ResourcesComponent,
    ResourcesItemComponent,
    ResourcesFormComponent,
    ResourcesCarouselComponent
  ],
  imports: [
    CommonModule,
    CarouselModule
  ]
})
export class ResourcesModule { }
