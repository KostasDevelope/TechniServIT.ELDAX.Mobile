
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs/observable';
import { ErrorHandler } from '@angular/core';
import { config }  from '../config';
import { ControllersInfo } from './../interfaces/controllersInfo';
import { String, StringBuilder } from 'typescript-string-operations';

@Injectable()
export class ApiControllersInfo{
    constructor(
        protected httpClient:  HttpClient,
        protected errorHandler: ErrorHandler
    ) {}
    //http://www.damirscorner.com/blog/posts/20170127-Angular2TutorialWithAsyncAndAwait.html
    async GetClientVersion() : Promise<string>{
        try 
        {
            let url: string = String.Format("{0}{1}",config.baseUrl, config.urls.getClientVersion);
            let response = await this.httpClient.get<string>(url).toPromise();
            return response;
        } 
        catch (error) {
              return await "";
        }
    }
    async GetApiControllersInfo() : Promise<Array<ControllersInfo>>{
        try 
        {
            let url: string = String.Format("{0}{1}",config.baseUrl, config.urls.getApiControllersInfo);
            let response = await this.httpClient.get<Array<ControllersInfo>>(url).toPromise();
            return response;
        } 
        catch (error)
         {
            return await new  Array<ControllersInfo>(); 
         }
    }
}