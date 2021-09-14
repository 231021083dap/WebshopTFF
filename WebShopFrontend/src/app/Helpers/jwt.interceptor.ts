import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';

// import { environment } from '../environments/environment';
import { AuthenticationService } from '../Services/AuthenticationService';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  private apiUrl = 'https://localhost:5001/api';

  constructor(private authenticationService: AuthenticationService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // add auth header with jwt if user is logged in and request is to the api url
    const currentUser = this.authenticationService.currentUserValue;
    const isLoggedIn = currentUser && currentUser.Token;
    const isApiUrl = request.url.startsWith(this.apiUrl);
    if (isLoggedIn && isApiUrl) {
      request = request.clone({
        setHeaders: { Authorization: `Bearer ${currentUser.Token}` }
      });
    }

    return next.handle(request);
  }
}