import { Injectable } from '@angular/core';
//import 'rxjs/add/operator/catch';
//import 'rxjs/add/operator/map';
import { Observable, throwError } from 'rxjs';
import {  catchError } from 'rxjs/operators';
//import 'rxjs/add/observable/throw';
import { BadRequestError } from '../Errors/bad-request-error';
import { NotFoundError } from '../Errors/not-fond-error';
import { AppError } from '../Errors/app-error';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';

@Injectable()
export class DataService {

  constructor(protected url: string, protected http: HttpClient) { }

  get(id: number): Observable<any> {
    return this.http.get(`${this.url}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  getAll(): Observable<any> {
    return this.http.get(this.url).pipe(
      catchError(this.handleError)
    );
  }


  create(resource: any): Observable<any> {
   
    return this.http.post(this.url, resource, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
       }).pipe(
      catchError(this.handleError)
    );
  }

  update(resource: any): Observable<any> {
    return this.http.put(`${this.url}/${resource.id}`, resource, {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }).pipe(
      catchError(this.handleError)
    );
  }

  delete(id: number): Observable<any>  {
    return this.http.delete(`${this.url}/${id}`).pipe(
      catchError(this.handleError)
    );
  }

  protected handleError(error: HttpErrorResponse) {

    if (error.status === 400) { return throwError(new BadRequestError(error)); }

    if (error.status === 404) { return throwError(new NotFoundError()); }

    return throwError(new AppError(error));
  }

  protected toQueryString(obj) {
    var parts = [];
    for (var property in obj) {
      var value = obj[property];
      if (value != null && value != undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }
    return parts.join('&');
  }
}


 


