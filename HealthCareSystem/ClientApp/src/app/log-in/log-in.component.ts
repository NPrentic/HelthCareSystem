import { Component, OnInit} from '@angular/core';
import { Router} from '@angular/router';
import { NgForm } from '@angular/forms';
import { LoginModel } from '../Models/LoginModel';
import { AuthService } from '../Services/auth-service';

@Component({
  selector: 'log-in',
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css']
})
export class LogInComponent implements OnInit {

  

  constructor(private router: Router, private authService: AuthService) { }

  hideSpinner: boolean = true;
  invalidLogin: boolean = false;
  role: string = null;

  credentials: LoginModel = { userId: null, password: null };

  ngOnInit() {
  }

  login(form: NgForm) {
    this.authService.generateToken(this.credentials).subscribe(response => {
      let token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.setSessionStrorageInformations(<any>response);
      //console.log(token);
      this.authService.setAuthStatusListener(true);
      this.invalidLogin = false;
      this.navigate();
    }, err => {
      this.invalidLogin = true;
    });
  }

  navigate() {
    this.role = sessionStorage.getItem("role");
    switch(this.role) { 
       case "Administrator": {
          this.router.navigate(["/accounts/list"]);
          break;
      }
      case "Tehnician": {
        this.router.navigate(["/schedule"]);
        break;
      } 
      default: {
          this.router.navigate(["/appointments"]);
          break;
         }
      }   
  }

  setSessionStrorageInformations(response: any) {
    let facilityId = (response).facilityId;
    let title = (response).title;
    let facilityName = (response).facilityName;
    let name = (response).name;
    let role = (response).role;
    let id = (response).id;
    sessionStorage.setItem("facilityId", facilityId);
    sessionStorage.setItem("title", title);
    sessionStorage.setItem("facilityName", facilityName);
    sessionStorage.setItem("name", name);
    sessionStorage.setItem("role", role);
    sessionStorage.setItem("Id", id);
  }
}
