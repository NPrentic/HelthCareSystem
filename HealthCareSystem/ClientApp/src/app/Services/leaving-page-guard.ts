import { Injectable } from '@angular/core';
import { CanDeactivate } from '@angular/router';
import { PatientSchedulingComponent } from '../patient-scheduling/patient-scheduling.component';
import { AppointmentComponent } from '../appointment/appointment.component';


@Injectable()
export class LeavingPageGuard implements CanDeactivate<AppointmentComponent> {

  canDeactivate(component: AppointmentComponent): boolean {
    return true;
  }
} 
