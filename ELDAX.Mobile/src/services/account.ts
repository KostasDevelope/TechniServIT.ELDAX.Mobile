
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs/observable';
import { ErrorHandler } from '@angular/core';
import { config }  from '../config';
import { AuthenticationContext } from './../interfaces/authenticationContext';
import { String } from 'typescript-string-operations';

@Injectable()
export class Account{
    constructor(
        protected httpClient:  HttpClient,
        protected errorHandler: ErrorHandler
    ) {}
    public async AuthenticateEx( authenticationContext: AuthenticationContext ) : Promise<AuthenticationContext>{
        try 
        {
            let httpOptions = {
                headers: new HttpHeaders({
                     "Content-Type":  'application/json',
                     "Login": authenticationContext.ApplicationLogin,
                     "Password": authenticationContext.Password,
                     "ClientVersion": config.clientVersion,
                     "IpAddress": config.IpAddress
            })};
            let url: string = String.Format("{0}{1}",config.baseUrl, config.urls.authenticateExUrl);
            let response = await this.httpClient.post<AuthenticationContext>(url,null, httpOptions).toPromise();
            return response;
        } 
        catch (error) {
              return await null;
        }
    }
        /*private handleError(error: HttpErrorResponse) {
            if (error.error instanceof ErrorEvent) {
              // A client-side or network error occurred. Handle it accordingly.
              console.error('An error occurred:', error.error.message);
            } else {
              // The backend returned an unsuccessful response code.
              // The response body may contain clues as to what went wrong,
              console.error(
                `Backend returned code ${error.status}, ` +
                `body was: ${error.error}`);
            }
            // return an observable with a user-facing error message
            return throwError(
              'Something bad happened; please try again later.');
          };
    }*/

}