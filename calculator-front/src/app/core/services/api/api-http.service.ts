/*import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ApiHttpService {

  constructor() { }
}*/

import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  throwError  } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { /*NotFoundError, BadInput,*/ AppError } from '../../core/error-handling/app-error';
import { environment } from './../../../../environments/environment';



const api = environment.apiEndoint;

@Injectable({
  providedIn: 'root'
})
export class ApiHttpService {

  constructor(
    // Angular Modules
    private http: HttpClient
  ) { }
  public get(url: string, options?: any) {
   
    return this.http.get(api + url, options) .pipe(
      map(response => response),
   catchError(this.handleError)
 );
  }
  public post(url: string, data: any,  options?: any) {
    return this.http.post(api + url, data, options)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }
  public put(url: string, data: any, options?: any) {
    return this.http.put(url, data, options)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }
  public delete(url: string, options?: any) {
    return this.http.delete(url, options)
    .pipe(
      map(response => response),
      catchError(this.handleError)
    );
  }

  private handleError(error: Response){
    /*if (error.status === 404) {
      return throwError( new NotFoundError());
    }

    if (error.status === 400) {
      return throwError(new BadInput(error));
    }*/

    return throwError(new AppError(error));
  }

}

