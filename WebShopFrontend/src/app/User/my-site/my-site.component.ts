import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/Services/AuthenticationService';
import { Component, OnInit } from '@angular/core';
import { Role, User } from 'src/app/models';
import { UserService } from 'src/app/Services/UserService';

@Component({
  selector: 'app-my-site',
  templateUrl: './my-site.component.html',
  styleUrls: ['./my-site.component.css']
})
export class MySiteComponent implements OnInit {


  currentUser: User = { UserId: 0, Email: '', Phone: '', FirstName: '', MiddleName: '', LastName: '', Address: '', PostalCode: '', Password: ''}

  Users: User[] = [];

  User: User = 
  { 
    UserId: 0,    
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
    private userService: UserService,
    private authenticationService: AuthenticationService
  ) {  
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  ngOnInit(): void {
    console.log(this.currentUser);
    this.userService.GetUserById(this.currentUser.UserId)
    .subscribe(a => this.User = a);
    console.log(this.User);
    console.log(this.currentUser.UserId);
  }

  
  UpdateUser(): void
  {
    this.userService.UpdateUser(this.currentUser.UserId, this.currentUser)
        .subscribe(() => {this.cancel()})
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
  cancel() : void
  {
    this.currentUser = 
    { 
      UserId: 0,      
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
