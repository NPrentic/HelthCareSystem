import { Injectable } from '@angular/core';
import { DataService } from './data.services';
import { catchError } from 'rxjs/operators';
import { HttpClient} from '@angular/common/http';

@Injectable()
export class DoctorService extends DataService {

  constructor(http: HttpClient) { super('https://localhost:44314/api/Doctors', http); }

  getDoctorsByQuery(query) {
    return this.http.get(this.url + '?' + this.toQueryString(query)).pipe(
      catchError(this.handleError)
    );
  }
}
