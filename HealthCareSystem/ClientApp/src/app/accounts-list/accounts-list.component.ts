import { Component, OnInit, Inject } from '@angular/core';
import { DoctorService } from '../Services/doctor.service';
import { TehnicianService } from '../Services/tehnicians.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

import { TitleService } from '../Services/title.service';
import { MatSnackBar } from '@angular/material';
import { ActivatedRoute } from '@angular/router';

export interface DialogData {
  doctor: any;
  tehnician: any;
}

@Component({
  selector: 'app-accounts-list',
  templateUrl: './accounts-list.component.html',
  styleUrls: ['./accounts-list.component.css']
})
export class AccountsListComponent implements OnInit {

  constructor(
    private doctorService: DoctorService,
    private tehnicianService: TehnicianService,
    public dialog: MatDialog,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar
  ) { }
  query: any = { facilityId: sessionStorage.getItem("facilityId"), pageSize: 8 }
  getDoctorResult: any = { doctors: null};
  tehnicians: any[];
  doctor: any = {};
  tehnician: any = {};
  numberOfTehnicians: number;
  highlatedEmployee: number;
  hideSpinner: boolean;

  ngOnInit() {

    this.route.paramMap
      .subscribe(params => {
        this.highlatedEmployee = +params.get('userId');
      });
    this.hideSpinner = false;

    this.populateDoctors();
    this.populateTehnicians();
  }

  populateTehnicians() {
    this.tehnicianService.getTehniciansByQuery(this.query)
      .subscribe(res => {
        this.tehnicians = res.tehnicians
        this.numberOfTehnicians = res.itemsNumber;
      });
  }

  populateDoctors() {
    this.doctorService.getDoctorsByQuery(this.query)
      .subscribe(res => {
        this.getDoctorResult = res;
        this.hideSpinner = true;
      });
  }

  onDeleteDoctor(doctorId) {
    this.doctorService.get(doctorId)
      .subscribe(doctor => { this.doctor = doctor, this.openDialog() })
  }
  onDeleteTehnician(tehId) {
    this.tehnicianService.get(tehId)
      .subscribe(teh => {this.tehnician = teh, this.openDialog() })
  }

  onTabChange() {
    if (this.doctor) this.doctor = null;
    else this.tehnician = null;
  }

  onDoctorPageChange(page) {
    this.query.page = page.pageIndex+1;
    this.query.pageSize = page.pageSize;
    this.populateDoctors();
  }
  onTehPageChange(page) {
    this.query.page = page.pageIndex + 1;
    this.query.pageSize = page.pageSize;
    this.populateTehnicians();
  }

  openDialog() {
    const dialogRef = this.dialog.open(DeleteDialog, {
      data: {
        doctor: this.doctor, tehnician: this.tehnician
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        if (this.doctor) {
          this.doctorService.delete(this.doctor.id)
            .subscribe(res => {
              this.populateDoctors();
              this.snackBar.open("Nalog je uspješno izbrisan.", "Ok", {
                duration: 3000,  horizontalPosition: 'left'
              });
            });
        }
        else {
          console.log("Proslo do backenda..");
          this.tehnicianService.delete(this.tehnician.id)
            .subscribe(res => {
              this.populateTehnicians();
            this.snackBar.open("Nalog je uspješno izbrisan.", "Ok", {
              duration: 3000, horizontalPosition: 'left'
            });
          });
      
        }
      }
    });
  }
}
@Component({
  selector: 'dialog-overview-example-dialog',
  templateUrl: 'delete-dialog.html',
})
export class DeleteDialog {

  constructor(
    private titleService: TitleService,
    public dialogRef: MatDialogRef<DeleteDialog>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData) { }

  title: string;

  ngOnInit() {
    if (this.data.doctor) {
      this.titleService.get(this.data.doctor.titleId)
        .subscribe(title => this.title = title.name);
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
