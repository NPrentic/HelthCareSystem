import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../Services/appointment.service';
import { DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientService } from '../Services/patients.service';

@Component({
  selector: 'app-appointments-list',
  templateUrl: './appointments-list.component.html',
  styleUrls: ['./appointments-list.component.css']
})
export class AppointmentsListComponent implements OnInit {

  constructor(
    private appointmetService: AppointmentService,
    private route: ActivatedRoute,
    private router: Router,
    private patientService: PatientService) { }

  query: any = { date: new Date(Date.now()) };
  appointments: Appointment[];
  today: Date;
  pipe = new DatePipe('en-US');
  hideSpinner: boolean;
  appointmentIdToRemove: number;

  ngOnInit() {
    this.hideSpinner = false;
    this.today = new Date(Date.now());
    this.query.doctorid = sessionStorage.getItem("Id");
    this.populateAppointments()
  }

  populateAppointments() {
    this.query.date.setDate(this.query.date.getDate() + 3);
    this.query.date = this.pipe.transform(this.query.date, 'shortDate');

    this.route.paramMap
      .subscribe(params => {
        let appointmentIdToRemove = +params.get('app');
        let patientToUpdateId = +params.get('pat');
        if (appointmentIdToRemove && patientToUpdateId) 
          this.appointmetService.delete(appointmentIdToRemove)
            .subscribe(res => {
              this.patientService.get(patientToUpdateId)
                .subscribe((res: Patient) => {
                  let patientToUpdate = res;
                  patientToUpdate.hasAppointment = false;
                  this.patientService.update(patientToUpdate).subscribe(res => {
                    this.appointmetService.getScheduledAppointment(this.query)
                    .subscribe((res: Appointment[]) => {
                      this.appointments = res;
                      this.hideSpinner = true;
                      });
                  });
                });
            }, error => {
              this.router.navigate(['/appointments'])
            });
        else 
          this.appointmetService.getScheduledAppointment(this.query)
            .subscribe((res: Appointment[]) => {
              this.appointments = res;
              this.hideSpinner = true;
            });
      });
  }
}
