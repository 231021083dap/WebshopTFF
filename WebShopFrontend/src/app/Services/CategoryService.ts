import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Observable } from "rxjs";
import { Category, SubCategory } from "../models";

@Injectable({
    providedIn : 'root'
})

export class CategoryService{
    private catapiUrl = 'Https://Localhost:5001/api/category';
    private subapiUrl = 'https://localhost:5001/api/Sub';

    httpOptions = 
    {
        headers: new HttpHeaders({'Content-Type':'application/json'})

    }

    constructor(
        private http:HttpClient
    ){}

    GetAllCategories() : Observable<Category[]>
    {
        return this.http.get<Category[]>(this.catapiUrl);
    }

    GetAllSubCategories() : Observable<SubCategory[]>
    {
        return this.http.get<SubCategory[]>(this.subapiUrl);
    }
}