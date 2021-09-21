import { Component, OnInit } from '@angular/core';

import { Category, SubCategory } from 'src/app/models';
import { CategoryService } from 'src/app/Services/CategoryService';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  Categories : Category[] = [];
  SubCategories : SubCategory[] = [];

  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void {
    this.categoryService.GetAllCategories()
    .subscribe(a => this.Categories = a);

    this.categoryService.GetAllSubCategories()
    .subscribe(a => this.SubCategories = a)
  }

}
