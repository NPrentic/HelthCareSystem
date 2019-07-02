import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PatientService } from '../Services/patients.service';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material';
import { DateAdapter } from 'saturn-datepicker';
import { MedicalCertificate } from './medical-certificate';
import { AppointToSpecialist } from './appoint-to-specialist';
import { ArangeControl } from './aranging-control';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-appointment',
  templateUrl: './appointment.component.html',
  styleUrls: ['./appointment.component.css']
})
export class AppointmentComponent implements OnInit {

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
  hideSpinner: boolean;
  role: string = sessionStorage.getItem('role');
  appointmentId: number;

  constructor(private route: ActivatedRoute, public dialog: MatDialog, private adapter: DateAdapter<any>, private patientservice: PatientService) { }

  ngOnInit() {
    this.hideSpinner = false;
    this.adapter.setLocale('sr-Latn');

    this.route.paramMap
      .subscribe(params => {
        this.patient.id = +params.get('id');
        this.appointmentId = +params.get('app');
        this.patientservice.get(this.patient.id)
          .subscribe((res: Patient) => {
          this.patient = res;
            this.hideSpinner = true;
          });
      });
  }

  openCertificateDialog() {
    const dialogRef = this.dialog.open(MedicalCertificate, {
      data: {
        patientName: this.patient.name,
        doctorId: Number( sessionStorage.getItem('Id'))
      }
    });
  }

  openToSpecialistDialog() {
    const dialogRef = this.dialog.open(AppointToSpecialist, {
      data: {
        patientName: this.patient.name,
        patientId: this.patient.id
      }
    });
  }

  openArangeControlDialog() {
    const dialogRef = this.dialog.open(ArangeControl, {
      data: {
        patientId: this.patient.id,
        patientname: this.patient.name,
        doctorId: Number(sessionStorage.getItem('Id'))
      }
    });
  }

}
