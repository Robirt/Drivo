import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdsComponent } from './ads/ads.component';
import { FormsModule } from '@angular/forms';
import { AdFormComponent } from './ad-form/ad-form.component';
import { AdsTableComponent } from './ads-table/ads-table.component';

@NgModule({
  declarations: [
    AdsComponent,
    AdsTableComponent,
    AdFormComponent,
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class AdsModule { }
