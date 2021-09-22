import { Component, OnInit } from '@angular/core';

import { User } from 'src/app/models';
import { UserService } from 'src/app/Services/UserService';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css']
})
export class AdminUsersComponent implements OnInit {

  Users: User[] = [];

  User: User = 
  { 
    UserId: 0,
    UserRoleId: 0,
    Email: '',
    Phone: '',
    Password: '',
    FirstName: '',
    LastName: '',
    MiddleName: '',
    Address: '',
    PostalCode: ''
  }

  constructor(private userService:UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }


  getUsers() : void
  {
    this.userService.GetAllUsers()
    .subscribe(a => this.Users = a);
  }

  editUser(user : User) : void
  {
    this.User = user;
  }

  deleteUser(user : User) : void
  {
    if (confirm('Are you sure u want to delete this user permanently?'))
    {
      this.userService.DeleteUser(user.UserId)
      .subscribe(() => { this.getUsers()});
    }
  }

  saveUser(): void 
  {
    
    if(this.User.UserId == 0){
      this.userService.RegisterUser(this.User)
        .subscribe(a => {
          this.Users.push(a);
          this.cancel();
        });
    }else{
      this.userService.UpdateUser(this.User.UserId, this.User)
        .subscribe(() => {this.cancel()})
    }
  }


  cancel() : void
  {
    this.User = 
    { 
      UserId: 0,
      UserRoleId: 0,
      Email: '',
      Phone: '',
      Password: '',
      FirstName: '',
      LastName: '',
      MiddleName: '',
      Address: '',
      PostalCode: ''
    }
  }
}
