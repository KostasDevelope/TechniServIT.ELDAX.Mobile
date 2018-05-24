
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs/observable';
import { ErrorHandler } from '@angular/core';
import { config }  from '../config';
import { ControllersInfo } from './../interfaces/controllersInfo';
import { String, StringBuilder } from 'typescript-string-operations';

@Injectable()
export class Documentoperations{
    constructor(
        protected httpClient:  HttpClient,
        protected errorHandler: ErrorHandler
    ) {}
    public async GetClientVersion() : Promise<string>{
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
    public async GetApiControllersInfo() : Promise<Array<ControllersInfo>>{
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