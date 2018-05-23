import { Injectable } from '@angular/core';
import { LocalStorage } from '@ngx-pwa/local-storage';

@Injectable()
export class  EldaxLocalStorage {
  constructor(
    protected localStorage: LocalStorage
  ) {}
  
  public SetItem(key : string, value: any, callback?: Function) : void {
    this.localStorage.setItem(key, value).subscribe((result) =>{    
      if(callback !== null ) callback(result);
    }, 
    (error) => {
    // Error
   });
  }
  
  public RemoveItem(key : string, callback?: Function) : void {
    this.localStorage.removeItem(key).subscribe(() => (result) =>{    
      if(callback !== null ) callback(result);
    }, 
    (error) => {
      // Error
     });
  }

  public Clear(callback?: Function) : void {
    this.localStorage.clear().subscribe(() => (result) =>{    
      if(callback !== null ) callback(result);
    }, 
      (error) => {
      // Error
     });
  }

  public GetItem<T>(key : string, callback?: Function) : void {
    this.localStorage.getItem<T>(key).subscribe((result) => {
      if(callback !== null ) callback(result);
    },
    (error) => { 
      // Error
    });
  }

}