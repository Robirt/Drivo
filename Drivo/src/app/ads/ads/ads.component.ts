import { Component, OnInit } from '@angular/core';
import { AdsService } from 'src/app/services/ads.service';
import { AdEntity } from 'src/entities/AdEntity';
import { ActionResponse } from 'src/responses/action.response';

@Component({
  selector: 'app-ads',
  templateUrl: './ads.component.html',
  styleUrls: ['./ads.component.css']
})
export class AdsComponent implements OnInit {

  constructor(private adService: AdsService) { }

  async ngOnInit(): Promise<void> {
    await this.getAdsAsync();
  }
  
  public ads: Array<AdEntity> = new Array<AdEntity>();

  public actionResponse: ActionResponse = new ActionResponse();

  public async getAdsAsync(): Promise<void> {
    this.ads = await this.adService.getAdsAsync();
  }

  public async addAdAsync(ad: AdEntity): Promise<void> {
    this.actionResponse = await this.adService.addAdAsync(ad);

    await this.getAdsAsync();
  }
  
  public async removeAdAsync(ad: AdEntity): Promise<void> {
    this.actionResponse = await this.adService.removeAdAsync(ad.id);

    await this.getAdsAsync();
  }
}
