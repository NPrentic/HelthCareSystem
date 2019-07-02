import { Injectable } from '@angular/core';
import { DataService } from './data.services';
import { catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AdminService extends DataService {

  constructor(http: HttpClient) { super('https://localhost:44314/api/Admins', http); }

  getAdminsByQuery(query) {

    return this.http.get(this.url + '?' + this.toQueryString(query)).pipe(
      catchError(this.handleError)
    );
  }
}
