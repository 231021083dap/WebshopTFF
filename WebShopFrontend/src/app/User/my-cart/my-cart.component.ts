import { Component, OnInit } from '@angular/core';
import { CartService } from 'src/app/Services/CartService';

@Component({
  selector: 'app-my-cart',
  templateUrl: './my-cart.component.html',
  styleUrls: ['./my-cart.component.css']
})
export class MyCartComponent implements OnInit {

  constructor(private cartService : CartService) { }

  ngOnInit(): void {
    this.getCart();
  }

  getCart()
  {
    const item = this.cartService.getcart();
  }

  removeFromCart() : void
  {
    
  }

  deleteEntireCart() : void
  {
    this.cartService.emptyCart();
  }

}
