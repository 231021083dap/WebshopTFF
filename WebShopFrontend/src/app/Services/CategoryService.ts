import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Observable } from "rxjs";
import { Category } from "../models";

@Injectable({
    providedIn : 'root'
})

export class ItemService{
    private apiUrl = 'Https://Localhost:5001/api/category';

    httpOptions = 
    {
        headers: new HttpHeaders({'Content-Type':'application/json'})

    }

    constructor(
        private http:HttpClient
    ){}

    GetAllCategories() : Observable<Category[]>
    {
        return this.http.get<Category[]>(this.apiUrl);
    }
}