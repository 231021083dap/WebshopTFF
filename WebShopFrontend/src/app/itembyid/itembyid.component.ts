import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { AuthenticationService } from '../Services/AuthenticationService';
import { Item, CartItem, User } from '../models';
import { ItemService } from '../Services/ItemService';
import { CartService } from '../Services/CartService';

@Component({
  selector: 'app-itembyid',
  templateUrl: './itembyid.component.html',
  styleUrls: ['./itembyid.component.css']
})
export class ItembyidComponent implements OnInit {

  currentUser: User = { UserId: 0, Email: '', Phone: '', FirstName: '', MiddleName: '', LastName: '', Address: '', PostalCode: '', Password: ''}

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
      private cartService : CartService,      
      private route: ActivatedRoute,
      private authenticationService: AuthenticationService
    ) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }


  ngOnInit(): void {
    this.itemid = this.route.snapshot.paramMap.get("itemid") || 0;

    this.getitembyid();
  }

  getitembyid(): void {
    this.itemService.GetItemById(this.itemid)
      .subscribe(a => 
      {
        this.Item = a
      });

  }

  addtoCart()
  {
    this.cartService.additemtocart(
      {ItemId : this.Item.ItemId,
      ItemName : this.Item.ItemName,
      ItemPrice : this.Item.ItemPrice,
      AmountInCart : 1});


      window.alert("Product added to cart");
  }
}
