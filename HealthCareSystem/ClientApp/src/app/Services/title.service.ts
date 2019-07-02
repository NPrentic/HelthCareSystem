import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from './data.services';

@Injectable()
export class TitleService extends DataService {

  constructor(http: HttpClient) { super('https://localhost:44314/api/Titles', http); }
}
