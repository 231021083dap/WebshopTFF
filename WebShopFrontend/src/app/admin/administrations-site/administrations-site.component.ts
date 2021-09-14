import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models';
import { UserService } from 'src/app/Services/UserService';

@Component({
  selector: 'app-administrations-site',
  templateUrl: './administrations-site.component.html',
  styleUrls: ['./administrations-site.component.css']
})
export class AdministrationsSiteComponent implements OnInit {

  Users: User[] = [];

  User: User = 
  { 
    UserId: 0,
    UserRoleId: 0,
    Email: '',
    TLF: 0,
    Password: '',
    FirstName: '',
    LastName: '',
    MiddleName: '',
    Address: '',
    PostalCode: 0

  }

  constructor
  (
    private userService: UserService
  ) { }

  ngOnInit(): void {
  }

  GetAllUsers(): void
  {
    this.userService.GetAllUsers()
    .subscribe(a => this.Users = a)
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
      .subscribe(() => { this.GetAllUsers()} )
    }
  }

  Cancel(): void
  {
    this.User = 
    { 
      UserId: 0,
      UserRoleId: 0,
      Email: '',
      TLF: 0,
      Password: '',
      FirstName: '',
      LastName: '',
      MiddleName: '',
      Address: '',
      PostalCode: 0
    }
  }


}
