import { Component, OnInit } from '@angular/core';
import { Options, LabelType } from 'ng5-slider';


import { Category, SubCategory, Item } from '../models';
import { CategoryService } from '../Services/CategoryService';
import { ItemService } from '../Services/ItemService';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css']
})
export class ItemsComponent implements OnInit {

  minPrice: number = 100;
  maxPrice: number = 25000;

  options: Options = 
  {
    floor: 100,
    ceil: 25000,
    translate: (value: number, label: LabelType): string => {
      switch (label) {
        case LabelType.Low:
          return '<b>Min:</b>' + value;
        case LabelType.High:
          return '<b>Max:</b>' + value;
        default:
          return '' + value;
      }
  }};


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

  adjustSearch()
  {
    
  }

}
