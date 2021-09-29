import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models';
import { UserService } from 'src/app/Services/UserService';
import { LoginComponent } from '../login/login.component';

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

  registerUser(): void
  {
    if(this.User.UserId == 0)
    {
      this.userService.RegisterUser(this.User)
      .subscribe(a => 
        {
          this.Users.push(a);
          console.log(this.User);
          this.cancel();
        });

    }
    else
    {
      this.userService.UpdateUser(this.User.UserId, this.User)
      .subscribe(() => { this.cancel()})
    }
  }

  cancel(): void
  {
    this.User = 
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
