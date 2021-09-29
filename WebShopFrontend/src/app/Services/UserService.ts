import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

import { Observable } from "rxjs";
import { Roles, User } from "../models";


@Injectable({
    providedIn : 'root'
})

export class UserService{
    private apiUrl = 'Https://Localhost:5001/api/user';
    private RolesapiUrl = 'https://localhost:5001/api/User/Roles'
    private GetUserByIdUrl = "https://localhost:5001/api/User/" + this.route.snapshot.paramMap.get("UserId") 

    httpOptions = 
    {
        headers: new HttpHeaders({'Content-Type':'application/json'})

    }

    constructor
    (
        private http: HttpClient,
        private route: ActivatedRoute,
        private router: Router
    ){}

    GetAllUsers() : Observable<User[]>
    {
        return this.http.get<User[]>(this.apiUrl);
    }

    GetUserRoles() : Observable<Roles[]>
    {
        return this.http.get<Roles[]>(this.RolesapiUrl);
    }

    GetUserById(userid : number) : Observable<User>
    {
        return this.http.get<User>(`${this.apiUrl}/${userid}`);
    }

    RegisterUser(user: User) : Observable<User>
    {
        return this.http.post<User>(this.apiUrl, user, this.httpOptions);
    }

    UpdateUser(userid : number, user : User) : Observable<User>
    {
        return this.http.put<User>(`${this.apiUrl}/${userid}`, user, this.httpOptions);
    }

    DeleteUser(userid : number) : Observable<Boolean>
    {
        return this.http.delete<Boolean>(`${this.apiUrl}/${userid}`, this.httpOptions);
    }
}