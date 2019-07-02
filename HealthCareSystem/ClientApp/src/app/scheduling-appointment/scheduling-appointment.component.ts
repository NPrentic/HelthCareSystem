import { Component, OnInit, Output} from '@angular/core';
import { PatientService } from '../Services/patients.service';
import { DoctorService } from '../Services/doctor.service';
import { NotFoundError } from '../Errors/not-fond-error';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AppointmentService } from '../Services/appointment.service';
import { MatDialog, MatDialogRef } from '@angular/material';
import { EventEmitter } from '@angular/core'


@Component({
  selector: 'scheduling-appointment',
  templateUrl: './scheduling-appointment.component.html',
  styleUrls: ['./scheduling-appointment.component.css']
})
export class SchedulingAppointmentComponent implements OnInit {

  constructor(
    private patientService: PatientService,
    private doctorService: DoctorService,
    private appointmentService: AppointmentService,
    public dialog: MatDialog,
    private snackBar: MatSnackBar) { }

  isAuthenticated: boolean = false;
  patient: any = { id: null, doctorId: null };
  invalidCardNumber: boolean = false;
  query: any = {};
  patientName: string;
  appointmentQuery: any = {};
  appointment: any = {
    time: {}};
  doctor: any = {
    name: "", id: null, facility: {},
    title: { name: "" }
  };
  @Output('patient-event') patientEvent = new EventEmitter();
  @Output('doctor-event') doctorEvent = new EventEmitter();

  ngOnInit() {
    this.isAuthenticated = localStorage.getItem("jwt") == null ? false : true;  
  }

  populatePatient() {
    this.patientService.getPatients(this.query)
      .subscribe(patient => {
        this.patient = patient;
        this.invalidCardNumber = false;
        this.populateDoctor();
        if (this.patient.hasAppointment)
        {
          this.appointmentQuery.patientId = this.patient.id;
          this.appointmentService.getAppointmentByQuery(this.appointmentQuery).
            subscribe(res => {
              this.appointment = res[0];
            })
        }
      }
      , err =>
      {
        if (err instanceof NotFoundError)
        {
          this.invalidCardNumber = true; 
        }
      }
    );
  }

  populateDoctor() {
    this.doctorService.get(this.patient.doctorId)
      .subscribe(doctor => {
      this.doctor = doctor;
      
      }
    );
  }

  emptyPatient() {
    this.patient == { id: null, doctorId: null };
  }

  onCancel() {
    this.patient.hasAppointment = false;
    this.patientService.update(this.patient)
      .subscribe(res => {
        this.appointment.patientId = 0;
        this.appointmentService.update(this.appointment).
          subscribe(res => { })
        this.snackBar.open("Uspješno ste otkazali pregled.", "Ok", {
          duration: 3000, horizontalPosition: 'left'
        });
        this.populatePatient(); 
      });

  }

  emitProperties() {
    this.patientEvent.emit(this.patient.id);
    this.doctorEvent.emit(this.doctor.id);
  }

  openDialog() {
    const dialogRef = this.dialog.open(CancelAppointmentDialog, {
      data: {}
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.onCancel();
      }
    });
  }
}
@Component({
  selector: 'cancel-dialog',
  templateUrl: 'cancel-dialog.html',
})
export class CancelAppointmentDialog {

  constructor(public dialogRef: MatDialogRef<CancelAppointmentDialog>) { }
  onNoClick(): void {
    this.dialogRef.close();
  }
}
