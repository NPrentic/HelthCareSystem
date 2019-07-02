import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.services';
import { catchError } from 'rxjs/operators';

@Injectable()
export class AppointmentService extends DataService {

  constructor(http: HttpClient) { super('https://localhost:44314/api/Appointments', http); }

  getAppointmentByQuery(query) {

    return this.http.get(this.url + '?' + this.toQueryString(query)).pipe(
      catchError(this.handleError)
    );
  }
  getScheduledAppointment(query) {
    return this.http.post(this.url, query).pipe(
      catchError(this.handleError)
    );
  }
}
