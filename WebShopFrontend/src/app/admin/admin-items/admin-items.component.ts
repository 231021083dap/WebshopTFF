import { Component, OnInit } from '@angular/core';
import { Item, SubCategory } from 'src/app/models';
import { CategoryService } from 'src/app/Services/CategoryService';
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
    SubCategoryId: 0,
    ItemPrice: 0,    
    ItemDiscount: 0,    
    ItemAmount: 0,
  }

  Sub: SubCategory = 
  {
    SubId: 0,
    SubName: '',
    CategoryId: 0
  }

  constructor
  (
    private itemService:ItemService,
    private categoryService: CategoryService  
  ) { }

  ngOnInit(): void 
  {
    this.getAllItems();

    //this.getSubById(this.Item.SubCategoryId);
  }

  getAllItems(): void
  {
    this.itemService.GetAllItems()
    .subscribe(a => this.Items = a);
  }

  getSubById(subid : any) : void
  {
    this.categoryService.GetSubById(subid)
    .subscribe(b => 
      {
        this.Sub = b;
      });
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
          console.log(this.Item);
          this.cancel();
        });
    }else{
      this.itemService.UpdateItem(this.Item.ItemId, this.Item)
        .subscribe(() => {
          console.log(this.Item);
          this.cancel();
        })
    }
  }


  cancel() : void
  {
    this.Item = 
    {
      ItemId: 0,
      ItemName: '',
      ItemDescription: '',
      SubCategoryId: 0,
      ItemPrice: 0,    
      ItemDiscount: 0,    
      ItemAmount: 0,
    }
  }
}
