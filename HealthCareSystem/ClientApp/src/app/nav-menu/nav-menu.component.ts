import { Component, Input, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialog } from '@angular/material';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from '../Services/auth-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  isExpanded = false;
  isAuthenticated: boolean = false;
  facilityName: string = null;
  employeeName: string = null;
  employeeTitle: string = null;
  employeeRole: string = null;

  constructor(public dialog: MatDialog,
    private authService: AuthService,
    private jwtHelper: JwtHelperService,
    private router: Router) { }

  ngOnInit() {
    this.isAuthenticated = !this.jwtHelper.isTokenExpired(localStorage.getItem("jwt")); // u slucaju reload-a
    this.updateUserInformations();

    this.authService.getAuthStatusListener().subscribe(isAuthenticated => { // u slucaju login-a i logout-a
      this.isAuthenticated = isAuthenticated;
      this.updateUserInformations();
    });
  }

  updateUserInformations() {
    this.facilityName = sessionStorage.getItem("facilityName");
    this.employeeName = sessionStorage.getItem("name");
    this.employeeTitle = sessionStorage.getItem("title");
    this.employeeRole = sessionStorage.getItem("role");
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    localStorage.removeItem("jwt");
    sessionStorage.removeItem("facilityId");
    sessionStorage.removeItem("facilityName");
    sessionStorage.removeItem("title");
    sessionStorage.removeItem("role");
    sessionStorage.removeItem("id");
    this.authService.setAuthStatusListener(false);
    this.router.navigate(["/"]);
  }

  openLogoutDialog() {
    const dialogRef = this.dialog.open(LogoutDialog, {
      data: { }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.logout();
      }
      else {
        this.router.navigateByUrl(this.authService.getPreviousUrl())
      }
    });
  }
}
@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'logout-dialog.html',
})
export class LogoutDialog {

  constructor(
    public dialogRef: MatDialogRef<LogoutDialog>,
    @Inject(MAT_DIALOG_DATA) public data: {}) { }

  title: string;

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
