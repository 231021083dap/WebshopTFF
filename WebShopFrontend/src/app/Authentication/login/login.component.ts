import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models';
import { Us}

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

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

  LoginUser()
  {

  }
}