import { Component, OnInit, Inject } from '@angular/core';
import { TitleService } from '../Services/title.service';
import { FacilityService } from '../Services/facility.service';
import { DoctorService } from '../Services/doctor.service';
import { TehnicianService } from '../Services/tehnicians.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { AdminService } from '../Services/admin.service';

export interface DialogData {
  doctor: any;
  tehnician: any;
}

@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {

  constructor(
    private titleService: TitleService,
    private facilityService: FacilityService,
    private doctorservice: DoctorService,
    private adminService: AdminService,
    private tehnicianService: TehnicianService,
    public dialog: MatDialog,
    private router: Router,
    private snackBar: MatSnackBar
  ) { }

  facilityId: number =  Number(sessionStorage.getItem("facilityId"));
  facility: any = {};
  titles: any[];
  doctor: any = {name:"", ambulance: null};
  tehnician: any = { name: "" };
  confirm: boolean;
  userId: number;
 

  ngOnInit() {


    this.generateUserId();
  
    this.facilityService.get(this.facilityId)
      .subscribe(f => this.facility = f);

    this.titleService.getAll()
      .subscribe(titles => this.titles = titles);
  }

   onCreateDoctor() {
    this.doctor.facilityId = this.facilityId;
    this.doctor.userId = this.userId;
    this.doctor.password = this.generatePassword(this.doctor.name);
    this.doctor.ambulance = Number(this.doctor.ambulance);
    this.doctorservice.create(this.doctor)
      .subscribe(res => this.success());
  }
  onCreateTehnician() {
    this.tehnician.userId = this.userId;
    this.tehnician.facilityId = this.facilityId;
    this.tehnician.password = this.generatePassword(this.tehnician.name);
    this.tehnicianService.create(this.tehnician)
      .subscribe(res => this.success());
  }

  success() {
    this.snackBar.open("Nalog je uspješno kreiran.", "Ok", {
      duration: 3000, horizontalPosition: 'left'
    });
    this.router.navigate(['/accounts/list', { userId: this.userId }]); 
  }

  onTabChange() {
    this.tehnician = {};
    this.doctor = {};
  }

  generatePassword(name: string) {
    var names = name.split(" ");

    return names[0].toLowerCase() + "123";
  }

  generateUserId() { // BUISNIS LOGIC ==> BACKEND!!!

    let doctorIds = [];
    let tehnicianIds = [];
    let adminIds = []
    this.doctorservice.getAll()
      .subscribe(res => {
        doctorIds = res.doctors.map(d => d.userId);
        this.tehnicianService.getAll()
          .subscribe(res => {
            tehnicianIds = res.tehnicians.map(t => t.userId);
              this.adminService.getAll()
                .subscribe(res => {
                  adminIds = res.map(a => a.userId);
                       var id = 1;
                  while (true) {
                    if (doctorIds.includes(id) || tehnicianIds.includes(id) || adminIds.includes(id)) id++;
              else break;
            }
            this.userId = id;
             });
          });
      });
  }

  openDialog() {
    const dialogRef =  this.dialog.open(DialogOverviewExampleDialog, {
      data: {
        doctor: this.doctor, tehnician: this.tehnician
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (this.doctor.name) {
          this.onCreateDoctor()
        }
        else {
          this.onCreateTehnician();  }
      }
    });
  }
}

@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'dialog.html',
})
export class DialogOverviewExampleDialog {

  constructor(
    private titleService: TitleService,
    public dialogRef: MatDialogRef<DialogOverviewExampleDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  title: string;

  ngOnInit() {
    if (this.data.doctor.titleId)
    this.titleService.get(this.data.doctor.titleId)
      .subscribe(title => this.title = title.name);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
