import { Component, OnInit, ViewChild } from '@angular/core';
import { DoctorShiftService } from '../Services/doctor-shifts.service';
import { DoctorService } from '../Services/doctor.service';
import { TehnicianShiftService } from '../Services/tehnician-shifts.service';
import { TehnicianService } from '../Services/tehnicians.service';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.css']
})
export class ScheduleComponent implements OnInit {

  constructor(
    private doctorShiftService: DoctorShiftService,
    private tehShiftService: TehnicianShiftService,
    private tehnicianService: TehnicianService,
    private doctorService: DoctorService ) { }

  isDoctor: boolean = sessionStorage.getItem("role") == "Specialist" || sessionStorage.getItem("role") == "nonSpecialist";
  isTehnician: boolean = sessionStorage.getItem("role") == "Tehnician";
  id: number = Number(sessionStorage.getItem("Id"));

  doctorShiftsQuery: any = {
    pageSize: 8
  };
  tehnicianShiftsQuery: any = {
    pageSize: 8
  };
  doctorShifts: any[];
  tehnicianShifts: any[];
  doctorShiftsNumber: number;
  tehnicianShiftsNumber: number;
  doctorsNumber: number;
  tehniciansNumber: number;
  doctorQuery: any = { facilityId: sessionStorage.getItem("facilityId"), pageSize: 8 };
  tehnicianQuery: any = { facilityId: sessionStorage.getItem("facilityId"), pageSize: 8 };
  panelOpenState: false;
  doctors: any[];
  tehnicians: any[];
  hideSpinner: boolean;


  ngOnInit() {
    this.hideSpinner = false;

    this.populateDoctors();
    this.populateTehnicians();
  
    if (this.isDoctor) {
      this.doctorShiftsQuery.doctorId = Number(sessionStorage.getItem("Id"));
      this.populateDoctorShifts();
    }
    if (this.isTehnician) {
      this.tehnicianShiftsQuery.tehnicianId = Number(sessionStorage.getItem("Id"));
      this.populateTehnicianShifts();
    }
  }

  populateDoctorShifts() {
    this.doctorShiftService.getShiftsByQuery(this.doctorShiftsQuery)
    .subscribe(res => {
      this.doctorShifts = res.doctorShifts;
      this.doctorShiftsNumber = res.itemsNumber;
      });
  }

  populateTehnicianShifts() {
    this.tehShiftService.getShiftsByQuery(this.tehnicianShiftsQuery)
    .subscribe((res: any) => {
      this.tehnicianShifts = res.tehnicianShifts;
      this.tehnicianShiftsNumber = res.itemsNumber;
      });
  }

  populateDoctors() {
    this.doctorService.getDoctorsByQuery(this.doctorQuery)
      .subscribe((res: any)=> {
      this.doctors = res.doctors;
        this.doctorsNumber = res.itemsNumber
        this.populateTehnicians();
      
      });
  }

  populateTehnicians() {
    this.tehnicianService.getTehniciansByQuery(this.tehnicianQuery)
      .subscribe((res: any) => {
        this.tehnicians = res.tehnicians;
        this.tehniciansNumber = res.itemsNumber;
        this.hideSpinner = true;
      });
  }

  onDoctorClick(id) {
    this.doctorShiftsQuery.doctorId = id;
    this.populateDoctorShifts();
  }
  onTehnicianClick(id) {
    this.tehnicianShiftsQuery.tehnicianId = id;
    this.populateTehnicianShifts();
  }

  onDoctorShiftPageChange(page) {
    this.doctorShiftsQuery.page = page.pageIndex + 1;
    this.doctorShiftsQuery.pageSize = page.pageSize;
    this.populateDoctorShifts();
  }

  onDoctorPageChange(page) {
    this.doctorQuery.page = page.pageIndex + 1;
    this.doctorQuery.pageSize = page.pageSize;
    this.populateDoctors();
  }
  onTehnicianShiftPageChange(page) {
    this.tehnicianShiftsQuery.page = page.pageIndex + 1;
    this.tehnicianShiftsQuery.pageSize = page.pageSize;
    this.populateTehnicianShifts();
  }

  onTehnicianPageChange(page) {
    this.tehnicianQuery.page = page.pageIndex + 1;
    this.tehnicianQuery.pageSize = page.pageSize;
    this.populateTehnicians();
  }

}
