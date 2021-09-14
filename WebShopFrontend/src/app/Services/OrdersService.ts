import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

import { Observable } from "rxjs";
import { Order } from "../models";


@Injectable({
    providedIn : 'root'
})

export class OrdersService{
    private apiUrl = 'Https://Localhost:5001/api/Orders';

    httpOptions = 
    {
        headers: new HttpHeaders({'Content-Type':'application/json'})

    }

    constructor(
        private http:HttpClient
    ){}

    GetAllOrders() : Observable<Order[]>
    {
        return this.http.get<Order[]>(this.apiUrl);
    }

    GetOrderById(orderid : number) : Observable<Order>
    {
        return this.http.get<Order>(`${this.apiUrl}/${orderid}`);
    }

    RegisterOrder(order: Order) : Observable<Order>
    {
        return this.http.post<Order>(this.apiUrl, order, this.httpOptions);
    }

    UpdateUser(orderid : number, order : Order) : Observable<Order>
    {
        return this.http.put<Order>(`${this.apiUrl}/${orderid}`, order, this.httpOptions);
    }

    DeleteUser(orderid : number) : Observable<Boolean>
    {
        return this.http.delete<Boolean>(`${this.apiUrl}/${orderid}`, this.httpOptions);
    }
}