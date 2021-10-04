import { Component, OnInit } from '@angular/core';

import { CartService } from 'src/app/Services/CartService';
import { CartItem, Item } from 'src/app/models';


@Component({
  selector: 'app-my-cart',
  templateUrl: './my-cart.component.html',
  styleUrls: ['./my-cart.component.css']
})
export class MyCartComponent implements OnInit {

  cartItems: CartItem[] = [];
  
  result: number = 0;

  constructor(private cartService : CartService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart()
  {
    this.cartItems = this.cartService.getcart();

    this.calculatePrice();
  }

  
  calculatePrice()
  {
    this.cartItems.forEach(cartItem => 
      {
        this.result = cartItem.ItemPrice * cartItem.AmountInCart;
      });
  }
  

  removeFromCart(ItemId : number) : void
  {
    this.cartService.removefromCart(ItemId);

    this.getCart();
  }

  deleteEntireCart() : void
  {
    this.cartService.emptyCart();

    window.location.reload();
  }

}


