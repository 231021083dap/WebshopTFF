import { Component, OnInit } from '@angular/core';

import { Item } from '../models';
import { ItemService } from '../Services/ItemService'
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: [`
    .hero
    {
      background-image: url('../../assets/Pics/WebsitePics/GrayPattern.jpg') !important;
      background-size: cover;
      background-position: center center;
    }
    `
  ]
})
export class HomeComponent implements OnInit {

  Items: Item[] = [];

  constructor(private itemService:ItemService) { }



  ngOnInit(): void {
    this.itemService.GetAllOnSale()
    .subscribe(a => this.Items = a);
  }


}
