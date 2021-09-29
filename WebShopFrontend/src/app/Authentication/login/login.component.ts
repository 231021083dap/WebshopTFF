import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { AuthenticationService } from 'src/app/Services/AuthenticationService';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  Email: string = '';
  Password: string = '';
  submitted = false;
  error = '';

  
  constructor
  (
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService : AuthenticationService
  ) 
  { 
    if(this.authenticationService.currentUserValue != null && this.authenticationService.currentUserValue.UserId > 0)
    {
      this.router.navigate(['/']);
    }
  }

  ngOnInit(): void {
  }


  Login(): void {
    this.error = '';
    this.authenticationService.login(this.Email, this.Password)
      .subscribe({
        next: () => {
          // // get return url from route parameters or default to '/'
          const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
          this.router.navigate([returnUrl]);
        },
        error: obj => {
          // console.log('login error ', obj.error);
          if (obj.error.status == 400 || obj.error.status == 401 || obj.error.status == 500) {
            this.error = 'Forkert brugernavn eller kodeord';
          }
          else {
            this.error = obj.error.title;
          }
        }
      });
    }
}