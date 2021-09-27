import { Component, OnInit } from '@angular/core';
import { LocalStorageService } from 'src/app/Services/my-cartService';

@Component({
  selector: 'app-my-cart',
  templateUrl: './my-cart.component.html',
  styleUrls: ['./my-cart.component.css']
})
export class MyCartComponent implements OnInit {
  // localStorageChanges$ = this.localStorageService.changes$;

  constructor(private localStorageService: LocalStorageService) { }  
  // persist(key: string, value: any) {
  //   this.localStorageService.set(key, value);
  // }

  ngOnInit(): void {
  }

}


