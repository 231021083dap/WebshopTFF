import { Component, OnInit } from '@angular/core';
import { Item } from 'src/app/models';
import { ItemService } from 'src/app/Services/ItemService';

@Component({
  selector: 'app-admin-items',
  templateUrl: './admin-items.component.html',
  styleUrls: ['./admin-items.component.css']
})
export class AdminItemsComponent implements OnInit {

  Items: Item[] = [];

  Item: Item = 
  {
    ItemId: 0,
    ItemName: '',
    ItemDescription: '',
    ItemSubCategoryId: 0,
    ItemPrice: 0,    
    ItemDiscount: 0,    
    ItemAmount: 0,
  }

  constructor(private itemService:ItemService) { }

  ngOnInit(): void 
  {
    this.getAllItems();
  }

  getAllItems(): void
  {
    this.itemService.GetAllItems()
    .subscribe(a => this.Items = a);
  }

  editItem(item : Item) : void
  {
    this.Item = item;
  }

  saveItem(): void 
  {
    
    if(this.Item.ItemId == 0){
      this.itemService.RegisterItem(this.Item)
        .subscribe(a => {
          this.Items.push(a);
          this.cancel();
        });
    }else{
      this.itemService.UpdateItem(this.Item.ItemId, this.Item)
        .subscribe(() => {this.cancel()})
    }
  }


  cancel() : void
  {
    this.Item = 
    {
      ItemId: 0,
      ItemName: '',
      ItemDescription: '',
      ItemSubCategoryId: 0,
      ItemPrice: 0,    
      ItemDiscount: 0,    
      ItemAmount: 0,
    }
  }
}
