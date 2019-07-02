import { Component, OnInit, Inject } from '@angular/core';
import { PatientService } from '../Services/patients.service';
import { NotFoundError } from '../Errors/not-fond-error';
import { DoctorService } from '../Services/doctor.service';
import { MAT_DIALOG_DATA, MatDialogRef, MatDialog, MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-choose-doctor',
  templateUrl: './choose-doctor.component.html',
  styleUrls: ['./choose-doctor.component.css']
})
export class ChooseDoctorComponent implements OnInit {

  patient: Patient = {
    id: null,
    name: null,
    fatherName: null,
    cardNumber: null,
    doctorId: null,
    gender: null,
    hasAppointment: null,
    doctor: null,
    bloodType: null,
    dateOfBirth: null
  }
   doctor: any = {
    name: "", id: null, facility: {},
    title: { name: "" }
  };
  invalidCardNumber: boolean = false;
  query: any = {cardNumber: null};
  facilityid: number;
  doctors: Doctor[];
  newDoctorId: number;


  constructor(private patientService: PatientService, private doctorService: DoctorService, public dialog: MatDialog, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.query.facilityid = Number(sessionStorage.getItem('facilityId')); 
  }

  populatePatient() {
    this.patientService.getPatients(this.query)
      .subscribe((patient: Patient) => {
        this.patient = patient;
        this.invalidCardNumber = false;
        this.populateDoctor();
        }
      , err => {
        if (err instanceof NotFoundError)
          this.invalidCardNumber = true;
        }
      );
  }

  populateDoctor() {
  this.doctorService.get(this.patient.doctorId)
    .subscribe(doctor => {
      this.doctor = doctor;  }
    );
   }

  onConfirm() {
    this.determinateTitle()
    this.doctorService.getDoctorsByQuery(this.query)
      .subscribe((res: GetDoctors) => this.doctors = res.doctors);
  }

  determinateTitle() {
    let compareDate = new Date(Date.now());
    compareDate.setFullYear(compareDate.getFullYear() - 18);

    if (new Date(this.patient.dateOfBirth) < compareDate) { this.query.title= 'Ljekar opšte prakse' }
    else { this.query.title = 'Izabrani ljekar za djecu - Pedijatar' }
  }

  updateDoctor() {
    this.patient.doctorId = this.newDoctorId;
    this.patientService.update(this.patient)
      .subscribe(res => {
        this.snackBar.open("Uspješno je dodiljen izabrani ljekar.", "", {
          duration: 3000, horizontalPosition: 'left'
        });})
  }

  openDialog() {
    const dialogRef = this.dialog.open(ConfirmDoctorDialog, {
      data: {
        patientName: this.patient.name,
        doctorId: this.newDoctorId,
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.updateDoctor();
      }
    });
  }

}


@Component({
  selector: 'confirm-dialog',
  templateUrl: 'confirm-dialog.html',
})
export class ConfirmDoctorDialog implements OnInit {

  hideSpinner: boolean;
  doctor: any;

  constructor(
    private doctorservice: DoctorService,
    public dialogRef: MatDialogRef<ConfirmDoctorDialog>,
    @Inject(MAT_DIALOG_DATA) public data: { doctorId: number, patientName: string }) { }

  ngOnInit() {
    this.hideSpinner = false;
    this.doctorservice.get(this.data.doctorId)
      .subscribe((res: any) => {
        this.doctor = res;
        this.hideSpinner = true;
      });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
