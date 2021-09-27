import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Item } from '../models';
import { ItemService } from '../Services/ItemService';
import { SubCategory } from '../models';
import { Category } from '../models';
import { CategoryService } from '../Services/CategoryService';

@Component({
  selector: 'app-itembyid',
  templateUrl: './itembyid.component.html',
  styleUrls: ['./itembyid.component.css']
})
export class ItembyidComponent implements OnInit {

  Item: Item =
    {
      ItemId: 0,
      ItemName: '',
      ItemDescription: '',
      SubCategoryId: 0,
      ItemPrice: 0,
      ItemDiscount: 0,
      ItemAmount: 0,
    }

  public itemid: any = 0;
  public catid: number = 0;

  constructor
    (
      private itemService: ItemService,
      private categoryService: CategoryService,
      private http: HttpClient,
      private route: ActivatedRoute
    ) { }

  ngOnInit(): void {
    this.itemid = this.route.snapshot.paramMap.get("itemid") || 0;

    this.getitembyid();

    console.log(this.route.snapshot.paramMap);
  }

  getitembyid(): void {
    this.itemService.GetItemById(this.itemid)
      .subscribe(a => {
        this.Item = a;
        console.log(this.Item)
      });

  }

  addtoCart() : void
  {
    
  }


}
