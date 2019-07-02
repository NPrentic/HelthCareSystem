import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-patient-scheduling',
  templateUrl: './patient-scheduling.component.html',
  styleUrls: ['./patient-scheduling.component.css']
})
export class PatientSchedulingComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  doctorId: number = 0;
  patientId: number = 0;
  canDeactivate: boolean =true;

  constructor(private _formBuilder: FormBuilder) { }
  ngOnInit() {

    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
  }


  getPatient(patientId) { this.canDeactivate = false; this.patientId = patientId;}
  getDoctor(doctorId) { this.doctorId = doctorId; }

}
