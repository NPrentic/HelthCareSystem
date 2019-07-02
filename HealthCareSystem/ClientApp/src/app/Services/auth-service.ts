import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginModel } from '../Models/LoginModel';
import { MatSnackBar } from '@angular/material';
import { Router, NavigationEnd } from '@angular/router';
import { Subject, Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable()
export class AuthService {

  private previousUrl: string;
  private currentUrl: string;

  private authStatusListener = new Subject<boolean>();

  constructor(private http: HttpClient, private snackBar: MatSnackBar, private router: Router, private jwtHelper: JwtHelperService) {
    this.currentUrl = this.router.url;
    router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.previousUrl = this.currentUrl;
        this.currentUrl = event.url;
      };
    });
  }

  getAuthStatusListener() { return this.authStatusListener.asObservable(); }

  setAuthStatusListener(input: boolean) { this.authStatusListener.next(input); }

  isAuthorized(): boolean {
    let token = localStorage.getItem("jwt");
    if (this.jwtHelper.isTokenExpired(token)) {
      this.authStatusListener.next(false);
      this.showLoginMessage();
      this.router.navigate(["/"]);
      return false;
    }
    else {
      return true;
    }
  }

  public getPreviousUrl() {
    return this.previousUrl;
  }

  showLoginMessage() {
    this.snackBar.open("Molimo vas prijavite se da bi nastavili.", "", {
      duration: 3000, horizontalPosition: 'left'
    });
  }

  generateToken(credentials: LoginModel): Observable<any> {

    return this.http.post("https://localhost:44314/api/auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    })
  }
}

