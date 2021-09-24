import { Component, OnInit } from '@angular/core';
import { SubCategory } from 'src/app/models';
import { CategoryService } from 'src/app/Services/CategoryService';

@Component({
  selector: 'app-admin-sub-category',
  templateUrl: './admin-sub-category.component.html',
  styleUrls: ['./admin-sub-category.component.css']
})
export class AdminSubCategoryComponent implements OnInit {

  Subs : SubCategory[] = [];
  Sub : SubCategory = 
  {
    SubId: 0,
    SubName: '',
    CategoryId: 0
  }


  constructor(private categoryService:CategoryService) { }

  ngOnInit(): void 
  {
    this.getSubs();
  }


  getSubs() : void
  {
    this.categoryService.GetAllSubCategories()
    .subscribe(a => this.Subs = a);
  }

  editSub(sub : SubCategory) : void
  {
    this.Sub = sub;
  }

  deleteSub(sub : SubCategory) : void
  {
    if (confirm('Are you sure u want to delete this Subcategory permanently?'))
    {
      this.categoryService.DeleteSub(sub.SubId)
      .subscribe(() => { this.getSubs()});
    }
  }

  saveSub(): void 
  {
    
    if(this.Sub.SubId == 0){
      this.categoryService.RegisterSub(this.Sub)
        .subscribe(a => {
          this.Subs.push(a);
          this.cancel();
        });
    }else{
      this.categoryService.UpdateSub(this.Sub.SubId, this.Sub)
        .subscribe(() => {this.cancel()})
    }
  }


  cancel() : void
  {
    this.Sub = 
    {
      SubId: 0,
      SubName: '',
      CategoryId: 0
    }
  }
}
