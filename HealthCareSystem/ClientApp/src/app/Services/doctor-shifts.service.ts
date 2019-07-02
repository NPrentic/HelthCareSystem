import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.services';
import { catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Injectable()
export class DoctorShiftService extends DataService {

  constructor(http: HttpClient) { super('https://localhost:44314/api/DoctorShifts', http); }

  getShiftsByQuery(query) : Observable<any> {
    return this.http.get(this.url + '?' + this.toQueryString(query)).pipe(
      catchError(this.handleError)
    );
  }
}
