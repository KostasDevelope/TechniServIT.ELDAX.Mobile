import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpInterceptor } from '@angular/common/http';
import { HttpRequest } from '@angular/common/http';
import { HttpHandler } from '@angular/common/http';
import { HttpEvent } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import 'rxjs/add/observable/fromPromise';
 
Component({
 
})
export class CustomHttpInterceptor implements HttpInterceptor {
  constructor() {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return Observable.fromPromise(this.handleAccess(request, next));
  }
 
  private async handleAccess(request: HttpRequest<any>, next: HttpHandler):
      Promise<HttpEvent<any>> {
    const token = await ""; //this.eldaxLocalStorage.GetItem
    let changedRequest = request;
    // HttpHeader object immutable - copy values
    const headerSettings: {[name: string]: string | string[]; } = {};
 
    for (const key of request.headers.keys()) {
      headerSettings[key] = request.headers.getAll(key);
    }
    if (token) {
      headerSettings['Authorization'] = 'Bearer ' + token;
    }
    headerSettings['Content-Type'] = 'application/json';
    const newHeader = new HttpHeaders(headerSettings);
 
    changedRequest = request.clone({
      headers: newHeader});
    return next.handle(changedRequest).toPromise();
  }
}
 