import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StudyComponent } from './study/study.component';
import { CourseModulesGridComponent } from './course-modules-grid/course-modules-grid.component';
import { FormsModule } from '@angular/forms';
import { CourseModuleFormComponent } from './course-module-form/course-module-form.component';
import { CourseModuleTileComponent } from './course-module-tile/course-module-tile.component';
import { CourseModuleComponent } from './course-module/course-module.component';
import { RouterModule } from '@angular/router';
import { ResourceFormComponent } from './resource-form/resource-form.component';
import { ResourceTileComponent } from './resource-tile/resource-tile.component';
import { ResourcesGridComponent } from './resources-grid/resources-grid.component';



@NgModule({
  declarations: [
    StudyComponent,
    CourseModuleTileComponent,
    CourseModulesGridComponent,
    CourseModuleFormComponent,
    CourseModuleComponent,
    ResourceFormComponent,
    ResourceTileComponent,
    ResourcesGridComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule
  ]
})
export class StudyModule { }
