import { Injectable } from '@angular/core';
import { LocalStorage } from '@ngx-pwa/local-storage';

@Injectable()
export class  EldaxLocalStorage {
  constructor(
    protected localStorage: LocalStorage
  ) {}
  
  public SetItem(key: string, value: any, callback?: Function) : void {
    this.localStorage.setItem(key, value).subscribe((result) =>{    
      if(callback !== null ) callback(result);
    }, 
    (error) => {
    // Error
   });
  }

  public async SetItemAsync(key: string, value: any) : Promise<boolean> {
    try 
    {
      let response = await this.localStorage.setItem(key, value).toPromise();
      return response;
    } 
    catch (error) {
      return await false;
    } 
  } 

  public RemoveItem(key: string, callback?: Function) : void {
    this.localStorage.removeItem(key).subscribe(() => (result) =>{    
      if(callback !== null ) callback(result);
    }, 
    (error) => {
      // Error
     });
  }

  public async RemoveItemAsync(key: string) : Promise<boolean> {
     try {
       let response = await this.localStorage.removeItem(key).toPromise();
       return response;
    } 
    catch (error) {
      return await false;
    } 
  }

  public Clear(callback?: Function) : void {
    this.localStorage.clear().subscribe(() => (result) =>{    
      if(callback !== null ) callback(result);
    }, 
    (error) => {
      // Error
     });
  }
  
  public async ClearAsync() : Promise<boolean> {
    try 
    {
      let response = await this.localStorage.clear().toPromise();
      return response;
    } 
    catch (error) {
      return await null;
    } 
  }

  public GetItem<T>(key: string, callback?: Function) : void {
    this.localStorage.getItem<T>(key).subscribe((result) => {
      if(callback !== null ) callback(result);
    },
    (error) => { 
    });
  }

  public async GetItemAsync<T>(key: string) : Promise<T> {
    try 
    {
      let response = await this.localStorage.getItem<T>(key).toPromise();
      return response;
    } 
    catch (error) {
      return await null;
    } 
  }
}