import { Component, OnInit } from '@angular/core';


import { Category, SubCategory, Item } from '../models';
import { CategoryService } from '../Services/CategoryService';
import { ItemService } from '../Services/ItemService';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  Categories : Category[] = [];
  SubCategories : SubCategory[] = [];
  Items: Item[] = [];

  constructor
  (
    private categoryService:CategoryService,
    private itemService:ItemService
  ) { }

  ngOnInit(): void {
    this.categoryService.GetAllCategories()
    .subscribe(a => this.Categories = a);

    this.categoryService.GetAllSubCategories()
    .subscribe(b => this.SubCategories = b);

    this.itemService.GetAllItems()
    .subscribe(i => this.Items = i);
  }

}
