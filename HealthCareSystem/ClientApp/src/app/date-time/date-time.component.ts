import { Component, OnInit, Inject, Input } from '@angular/core';
import { PatientService } from '../Services/patients.service';
import { AppointmentService } from '../Services/appointment.service';
import { ActivatedRoute, Router } from '@angular/router';
import { DateAdapter, MatSnackBar, MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DoctorShiftService } from '../Services/doctor-shifts.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'date-time',
  templateUrl: './date-time.component.html',
  styleUrls: ['./date-time.component.css']
})
export class DateTimeComponent implements OnInit {

  constructor(
    private patientSrervice: PatientService,
    private doctorShiftService: DoctorShiftService,
    private appointmentService: AppointmentService,
    public dialog: MatDialog,
    private router: Router,
    private snackBar: MatSnackBar,
    private adapter: DateAdapter<any>) { }

  @Input('patient-id') patientId: number;
  @Input('doctor-id') doctorId: number;
  query: any = {}
  shifts: any[];
  date: Date;
  dates: Date[];
  minDate: any;
  appointment: any = {};
  appointments: any[];
  patient: any;
  role: string = sessionStorage.getItem('role');
  pipe = new DatePipe('en-US');
  dateClass = (d: Date) : boolean => {

    var frontEndDate = this.pipe.transform(d, 'fullDate');
    var ind = false;
    for (let dat of this.dates) {
      if (this.pipe.transform(dat, 'fullDate') === frontEndDate)
        ind = true;
    }
    return ind;
  }

  ngOnInit() {
    this.minDate = new Date(Date.now());  // Danasnji datum
    this.minDate.setDate(this.minDate.getDate() + 1); //Sjutrasnji datum
    this.adapter.setLocale('sr-Latn');

    this.query.doctorId = this.doctorId;
    this.appointment.patientId = this.patientId;

    this.patientSrervice.get(this.patientId)
      .subscribe((res: any) => { this.patient = res })

    this.doctorShiftService.getShiftsByQuery(this.query)
      .subscribe((res : any) => {
        this.shifts = res.doctorShifts;
        this.dates = this.shifts.map(s => s.date);
      })
  }
  onDateChange() {
    this.query.date = this.pipe.transform(this.date, 'short');
    this.appointmentService.getAppointmentByQuery(this.query)
      .subscribe((res: any) => this.appointments = res);
  }
  onSubmit() {
    this.appointment.doctorId = this.query.doctorId;
    this.appointment.date = this.query.date;
    this.appointmentService.update(this.appointment)
      .subscribe(res => {
        this.snackBar.open("Pregled je uspješno zakazan.", "", {
          duration: 3000, horizontalPosition: 'left'
        });
        if (this.role != 'nonSpecialist' && this.role != 'Specialist') {
          this.patient.HasAppointment = true;
          this.patientSrervice.update(this.patient)
            .subscribe(res => { this.navigate(); });
        }
      }
   );
  }

  navigate() {
    let role = sessionStorage.getItem("role");
    switch (role) {
      case "Tehnician": {
        this.router.navigate(["/schedule"]);
        break;
      }
      default: {
        this.router.navigate(["/"]);
        break;
      }
    }
  }

  openDialog() {
    const dialogRef = this.dialog.open(ArrangeAppointmentDialog, {
      data: {
        patientId: this.patientId,
        doctorId: this.doctorId,
        date: this.query.date,
        appointmentId: this.appointment.id
      }
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.onSubmit();
      }
    });
  }
}
@Component({
  selector: 'arange-dialog',
  templateUrl: 'arange-dialog.html',
})
export class ArrangeAppointmentDialog implements OnInit {


  patient: any = {};
  appointment: any = {
    doctor: {},
  time: {}
  };
    hideSpinner: boolean;

  constructor(
    private appointmentService: AppointmentService,
    private patientService: PatientService,
    public dialogRef: MatDialogRef<ArrangeAppointmentDialog>,
    @Inject(MAT_DIALOG_DATA) public data: {
      patientId: number,
      doctorId: number,
      date: Date,
      appointmentId: number
    }) { }

  ngOnInit(){
    this.hideSpinner = false;
    this.patientService.get(this.data.patientId)
      .subscribe(res => this.patient = res);

    this.appointmentService.get(this.data.appointmentId)
      .subscribe(res => {
      this.appointment = res
        this.hideSpinner = true;

      });
 }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
