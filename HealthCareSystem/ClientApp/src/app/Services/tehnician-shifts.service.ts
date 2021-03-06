import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.services';
import { catchError } from 'rxjs/operators';

@Injectable()
export class TehnicianShiftService extends DataService {

  constructor(http: HttpClient) { super('https://localhost:44314/api/TehnicianShifts', http); }

  getShiftsByQuery(query) {
    return this.http.get(this.url + '?' + this.toQueryString(query)).pipe(
      catchError(this.handleError)
    );
  }
}
