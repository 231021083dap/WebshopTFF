import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';


import { Category, SubCategory, User } from 'src/app/models';
import { CategoryService } from 'src/app/Services/CategoryService';
import { AuthenticationService } from 'src/app/Services/AuthenticationService';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  currentUser: User = { UserId: 0, Email: '', Phone: '', FirstName: '', MiddleName: '', LastName: '', Address: '', PostalCode: '', Password: ''}
  Categories : Category[] = [];
  SubCategories : SubCategory[] = [];

  constructor(
    private categoryService:CategoryService,
    private router: Router,
    private authenticationService: AuthenticationService
    ) {
      this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }

  ngOnInit(): void {
    this.categoryService.GetAllCategories()
    .subscribe(a => this.Categories = a);

    this.categoryService.GetAllSubCategories()
    .subscribe(a => this.SubCategories = a)

  }
  LogOut() {
    if (confirm('Er du sikker på du vil logge ud')) {
      // ask authentication service to perform logout
      this.authenticationService.logout();

      // subscribe to the changes in currentUser, and load Home component
      this.authenticationService.currentUser.subscribe(x => {
        this.currentUser = x
        this.router.navigate(['/']);
      });
    }
  }
}
