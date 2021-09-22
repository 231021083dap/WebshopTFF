import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models';
import { UserService } from 'src/app/Services/UserService';

@Component({
  selector: 'app-my-site',
  templateUrl: './my-site.component.html',
  styleUrls: ['./my-site.component.css']
})
export class MySiteComponent implements OnInit {

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

  constructor
  (
    private userService: UserService
  ) { }

  ngOnInit(): void {
  }

  
  UpdateUser(User : User): void
  {
    this.User = User;
  }

  DeleteUser(user : User) : void
  {
    if(confirm('Er du sikker på at du vil slette denne bruger?'))
    {
      this.userService.DeleteUser(user.UserId)
      
    }
  }

  GetAllMyOrders()
  {

  }

}
