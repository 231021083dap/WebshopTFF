import { Injectable } from "@angular/core";
import { CartItem, Item } from "../models";

import { Observable } from "rxjs";

@Injectable({
    providedIn : 'root'
})

export class CartService{

    key = 'cart';
    
    cartItems: CartItem[] = [];

    constructor() {}

    

    private createcart()
    {        
        var createcart = JSON.parse(localStorage.getItem(this.key) || '[]');

        if(createcart == null || createcart == '')
        {
            localStorage.setItem(this.key, JSON.stringify(this.cartItems));
        }
    }


    getcart() : CartItem[]
    {
        this.createcart();

        this.cartItems = JSON.parse(localStorage.getItem(this.key) || '[]');

        return this.cartItems;
    }


    savecart()
    {
        localStorage.setItem(this.key, JSON.stringify(this.cartItems));
    }


    additemtocart(item : CartItem)
    {
        console.log(item);
        
        this.cartItems = this.getcart();

        var itemchanged = false;
        this.cartItems.forEach(cartitem => { 
            if(cartitem.ItemId == item.ItemId)
            {
                cartitem.AmountInCart += item.AmountInCart;

                //cartitem.AmountInCart ++;

                itemchanged = true;
                console.log(cartitem.AmountInCart);
            }
         })      

        if(!itemchanged)
        {
            this.cartItems.push(item); 
            console.log(this.cartItems); 
        }
        
        this.savecart();
    }


    updateitemincart(item : CartItem)
    {
        this.getcart();

        // ...... No clue atm
    }


    emptyCart()
    {
        localStorage.clear();
    }


    removefromCart(passedId : number)
    {
        var cart_items = JSON.parse(localStorage["cart"]);

        for (var i=0; i < cart_items.length; i++)
        {   
            if (cart_items[i].ItemId == passedId) 
            {
                cart_items.splice(i,1);
            }

            localStorage["cart"] = JSON.stringify(cart_items);
    
        }
    }

}