import { Component, OnInit } from '@angular/core';
import { AdService } from 'src/app/services/ad.service';
import { AdEntity } from 'src/entities/AdEntity';

@Component({
  selector: 'app-ad',
  templateUrl: './ad.component.html',
  styleUrls: ['./ad.component.css']
})
export class AdComponent implements OnInit {

  constructor(private adService: AdService) { }

  ngOnInit(): void {
  }
public ads: Array<AdEntity> = new Array<AdEntity>();
public ad: AdEntity

public async getAds(): Promise<void>
{
  this.ads= await this.adService.getAds();
}

public async postAd(ad: AdEntity): Promise<void>
{
  this.ad= await this.adService.postAd(ad);
}

public async putAd(ad: AdEntity): Promise<void>
{
  this.ad = await this.adService.putAd(ad);
}

public async deleteAd(id: number): Promise<void>
{
  this.ad = await this.adService.deleteAd(id);
}
}
