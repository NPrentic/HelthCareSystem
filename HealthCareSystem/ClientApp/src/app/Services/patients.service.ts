import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.services';
import { catchError } from 'rxjs/operators';

@Injectable()
export class PatientService extends DataService {

  constructor(http: HttpClient) { super('https://localhost:44314/api/Patients', http); }

  getPatients(query) {
    return this.http.get(this.url + '?' + this.toQueryString(query)).pipe(
      catchError(this.handleError)
    );
  }
  updatePatient(patientId) {
    return this.http.put(this.url + '/' + patientId, null).pipe(
      catchError(this.handleError)
    );
  }
}
