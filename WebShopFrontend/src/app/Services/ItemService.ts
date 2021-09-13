import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Observable } from "rxjs";
import { Item } from "../models";

@Injectable({
    providedIn : 'root'
})

export class ItemService{
    private apiUrl = 'Https://Localhost:5001/api/item';

    httpOptions = 
    {
        headers: new HttpHeaders({'Content-Type':'application/json'})

    }

    constructor(
        private http:HttpClient
    ){}

    GetAllItems() : Observable<Item[]>
    {
        return this.http.get<Item[]>(this.apiUrl);
    }
}