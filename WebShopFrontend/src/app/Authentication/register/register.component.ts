import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models';
import { UserService } from 'src/app/Services/UserService';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

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

  RegisterUser(): void
  {
    if(this.User.UserId == 0)
    {
      this.userService.RegisterUser(this.User)
      .subscribe(a => 
        {
          this.Users.push(a);
          this.Cancel();
        });
    }
    else
    {
      this.userService.UpdateUser(this.User.UserId, this.User)
      .subscribe(() => { this.Cancel()})
    }
  }

  Cancel(): void
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
