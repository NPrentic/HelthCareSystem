import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../Services/doctor.service';
import { DateAdapter } from 'saturn-datepicker'
import { TehnicianService } from '../Services/tehnicians.service';
import { ShiftService } from '../Services/shift.service';
import { MatSnackBar } from '@angular/material';
import { DoctorShiftService } from '../Services/doctor-shifts.service';
import { TehnicianShiftService } from '../Services/tehnician-shifts.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-updating-shifts',
  templateUrl: './updating-shifts.component.html',
  styleUrls: ['./updating-shifts.component.css']
})
export class UpdatingShiftsComponent implements OnInit {



  constructor(
    private tehnicianService: TehnicianService,
    private doctorService: DoctorService,
    private doctorShiftService: DoctorShiftService,
    private tehShiftService: TehnicianShiftService,
    private adapter: DateAdapter<any>,
    private shiftService: ShiftService,
    private snackBar: MatSnackBar
   ) { }

  getDoctorsResult: any = {};
  tehnicians: any[];
  query: any = { facilityId: sessionStorage.getItem("facilityId")}
  shiftDetails: any = {isDoctor: null};
  minDate: any;
  dates: any = [];
  pipe = new DatePipe('en-US');

  dateClass = (d: Date) => {
   
    var frontEndDate = this.pipe.transform(d, 'fullDate');
    var ind = true;
    for (let dat of this.dates) {
      if (this.pipe.transform(dat, 'fullDate') === frontEndDate)
        ind = false;
    }
    return ind;
  }

  ngOnInit() {

    this.minDate = new Date(Date.now());  // Danasnji datum
    this.minDate.setDate(this.minDate.getDate() + 1); //Sjutrasnji datum
    this.adapter.setLocale('sr-Latn');
    this.shiftDetails.isDoctor = true;

    this.doctorService.getDoctorsByQuery(this.query)
      .subscribe(result => {
      this.getDoctorsResult = result
        this.tehnicianService.getTehniciansByQuery(this.query)
          .subscribe(res => {
            this.tehnicians = res.tehnicians;
           });
      });
  }

  onSubmit() {
    console.log(this.shiftDetails.dateRange);
    this.shiftService.create(this.shiftDetails)
      .subscribe(res => {
        this.snackBar.open("Uspješno ažuriranje.","",{
          duration: 2000, horizontalPosition: 'left'
        });
        this.disableDates();
      });
  }

  onTabChange() {
    this.shiftDetails.employeeId = null;
    this.shiftDetails.dateRange = null;
    this.shiftDetails.isDoctor = !this.shiftDetails.isDoctor;
    this.shiftDetails.shift = null;
  }

  disableDates() {
    if (this.shiftDetails.isDoctor) {
      this.query.doctorId = this.shiftDetails.employeeId
      this.doctorShiftService.getShiftsByQuery(this.query)
        .subscribe(res => {
          var updatedShifts = res.doctorShifts;
          this.dates = updatedShifts.map(s => s.date);
        });
    }
    else {
      this.query.tehnicianId = this.shiftDetails.employeeId
      this.tehShiftService.getShiftsByQuery(this.query)
        .subscribe((res: any) => {
          var updatedShifts = res.tehnicianShifts;
          this.dates = updatedShifts.map(s => s.date);
        });
    }
  }
}
