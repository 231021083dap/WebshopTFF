import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class LocalStorageService {
    constructor () { }

    public setItem(key: string, value: string){
        localStorage.setItem(key, value);
    }

    public getItem(key: string) {
        return localStorage.getItem(key)
    }

    public removeItem(key:string){
        localStorage.removeItem(key);
    }

    public clear(){
        localStorage.clear();
    }

}



// export class LocalStorageService {
//   localStorage: Storage;

//   changes$ = new Subject();

//   constructor() {
//     this.localStorage = window.localStorage;
//   }

//   var a = [];
//   a.push(JSON.parse(localStorage.getItem('cart')));
//   localStorage.setItem('cart', JSON.stringify(a));
  
//   get(key: string): any {
//     if (this.isLocalStorageSupported) {
//       return JSON.parse(this.localStorage.getItem(key));
//     }
//     return null;
//   }

//   saveitemtoCart(item)
//   {
//     var a = [];

//     a = JSON.parse(localStorage.getItem('cart')) || [];

//     a.push(item);

//     alert(a);

//     localStorage.setItem('cart', JSON.stringify(a));
//   }


//   set(key: string, value: any): boolean {
//     if (this.isLocalStorageSupported) {
//       this.localStorage.setItem(key, JSON.stringify(value));
//       this.changes$.next({
//         type: 'set',
//         key,
//         value
//       });
//       return true;
//     }
//     return false;
//   }

//   remove(key: string): boolean {
//     if (this.isLocalStorageSupported) {
//       this.localStorage.removeItem(key);
//       this.changes$.next({
//         type: 'remove',
//         key
//       });
//       return true;
//     }
//     return false;
//   }

//   get isLocalStorageSupported(): boolean {
//     return !!this.localStorage
//   }
// }
