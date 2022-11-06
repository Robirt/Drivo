import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdComponent } from './ad/ad.component';
import { NewAddComponent } from './ad/new-add/new-add.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AdComponent,
    NewAddComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class AdModule { }
