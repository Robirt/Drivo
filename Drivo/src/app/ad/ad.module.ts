import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdComponent } from './ad/ad.component';

import { FormsModule } from '@angular/forms';
import { NewAddComponent } from './new-add/new-add.component';



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
