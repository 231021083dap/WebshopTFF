import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Item, CartItem } from '../models';
import { ItemService } from '../Services/ItemService';
import { CategoryService } from '../Services/CategoryService';
import { CartService } from '../Services/CartService';

@Component({
  selector: 'app-itembyid',
  templateUrl: './itembyid.component.html',
  styleUrls: ['./itembyid.component.css']
})
export class ItembyidComponent implements OnInit {

  Items: Item[] = [];
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

  CartItem: CartItem = 
  {
    ItemId: 0,
    ItemName: '',
    ItemPrice: 0,
    AmountInCart: 0,
  }

  public itemid: any = 0;
  public catid: number = 0;

  constructor
    (
      private itemService: ItemService,
      private categoryService: CategoryService,
      private cartService : CartService,      
      private route: ActivatedRoute
    ) { }


  ngOnInit(): void {
    this.itemid = this.route.snapshot.paramMap.get("itemid") || 0;

    this.getitembyid();
  }

  getitembyid(): void {
    this.itemService.GetItemById(this.itemid)
      .subscribe(a => {
        this.Item = a;
        console.log(this.Item)
      });

  }

  addtoCart()
  {
    this.cartService.additemtocart(this.CartItem);
  }
}
