import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Observable } from "rxjs";
import { Item } from "../models";

@Injectable({
    providedIn : 'root'
})

export class ItemService{

    private itemsapiUrl = 'Https://Localhost:5001/api/item';
    private OnSaleItemsUrl = 'https://localhost:5001/api/Item/OnSale';

    httpOptions = 
    {
        headers: new HttpHeaders({'Content-Type':'application/json'})

    }

    constructor(
        private http:HttpClient
    ){}

    GetAllItems() : Observable<Item[]>
    {
        return this.http.get<Item[]>(this.itemsapiUrl);
    }

    GetAllOnSale() : Observable<Item[]>
    {
        return this.http.get<Item[]>(this.OnSaleItemsUrl);
    }

    GetItemById(itemid : number) : Observable<Item>
    {
        return this.http.get<Item>(`${this.itemsapiUrl}/${itemid}`);
    }

    RegisterItem(item: Item) : Observable<Item>
    {
        return this.http.post<Item>(this.itemsapiUrl, item, this.httpOptions);
    }

    UpdateItem(itemid : number, item : Item) : Observable<Item>
    {
        return this.http.put<Item>(`${this.itemsapiUrl}/${itemid}`, item, this.httpOptions);
    }
}