import { Component, OnInit } from '@angular/core';
import { Order } from 'src/app/models';
import { OrdersService } from 'src/app/Services/OrdersService';

@Component({
  selector: 'app-admin-orders',
  templateUrl: './admin-orders.component.html',
  styleUrls: ['./admin-orders.component.css']
})
export class AdminOrdersComponent implements OnInit {

  Orders : Order[] = [];
  Order : Order = 
  {
    OrderId: 0,
    UserId: 0,
    OrderStatus: ''
  }

  constructor(private ordersService : OrdersService) { }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders()
  {
    this.ordersService.GetAllOrders()
    .subscribe(a => this.Orders = a);
  }

  editOrder(order : Order)
  {
    this.Order = order;
  }

}
