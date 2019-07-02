import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule} from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from './material-module';
import { SatDatepickerModule, SatNativeDateModule } from 'saturn-datepicker';

import { AppComponent } from './app.component';
import { NavMenuComponent, LogoutDialog } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { HttpModule } from '@angular/http';
import { DateTimeComponent, ArrangeAppointmentDialog } from './date-time/date-time.component';
import { NamePipe } from './Pipes/name.pipe';
import { UpdatingShiftsComponent } from './updating-shifts/updating-shifts.component';
import { AppointmentService } from './Services/appointment.service';
import { DoctorService } from './Services/doctor.service';
import { TimeService } from './Services/times.service';
import { PatientService } from './Services/patients.service';
import { MatNativeDateModule, MatPaginatorIntl} from '@angular/material';
import { SchedulingAppointmentComponent, CancelAppointmentDialog } from './scheduling-appointment/scheduling-appointment.component';
import { TehnicianService } from './Services/tehnicians.service';
import { ShiftService } from './Services/shift.service';
import { CreateAccountComponent, DialogOverviewExampleDialog} from './create-account/create-account.component';
import { TitleService } from './Services/title.service';
import { PasswordPipe } from './Pipes/password';
import { FacilityService } from './Services/facility.service';
import { AccountsListComponent, DeleteDialog } from './accounts-list/accounts-list.component';
import { DoctorShiftService } from './Services/doctor-shifts.service';
import { TehnicianShiftService } from './Services/tehnician-shifts.service';
import { ScheduleComponent } from './schedule/schedule.component';
import { translatePaginatorIntl } from './Services/translate-service.service';
import { PatientSchedulingComponent } from './patient-scheduling/patient-scheduling.component';
import { TranslateDatePipe } from './Pipes/translate-date.pipe';
import { LogInComponent } from './log-in/log-in.component';
import { AdminService } from './Services/admin.service';
import { PasswordChangeComponent } from './password-change/password-change.component';
import { AppErrorHandler } from './Errors/app-error-handler';
import { ConfirmPasswordDirective } from './Shered/confirm-password.directive';
import { AuthGuard } from './Services/auth-guard.service';
import { JwtHelperService, JWT_OPTIONS } from '@auth0/angular-jwt';
import { AuthService } from './Services/auth-service';
import { EmptyComponent } from './empty/empty.component';
import { AppointmentsListComponent } from './appointments-list/appointments-list.component';
import { LeavingPageGuard } from './Services/leaving-page-guard';
import { InformationsComponent } from './informations/informations.component';
import { PhoneNumberPipe } from './Pipes/phone-number.pipe';
import { ChooseDoctorComponent, ConfirmDoctorDialog } from './choose-doctor/choose-doctor.component';
import { AppointmentComponent } from './appointment/appointment.component';
import { MedicalCertificate } from './appointment/medical-certificate';
import { AppointToSpecialist } from './appointment/appoint-to-specialist';
import { ArangeControl } from './appointment/aranging-control';




@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    NamePipe,
    PasswordPipe,
    PhoneNumberPipe,
    UpdatingShiftsComponent,
    SchedulingAppointmentComponent,
    DateTimeComponent,
    CreateAccountComponent,
    DialogOverviewExampleDialog,
    MedicalCertificate,
    ConfirmDoctorDialog,
    AppointToSpecialist,
    ArrangeAppointmentDialog,
    CancelAppointmentDialog,
    ArangeControl,
    DeleteDialog,
    AccountsListComponent,
    ScheduleComponent,
    PatientSchedulingComponent,
    TranslateDatePipe,
    LogInComponent,
    PasswordChangeComponent,
    LogoutDialog,
    ConfirmPasswordDirective,
    EmptyComponent,
    AppointmentsListComponent,
    InformationsComponent,
    ChooseDoctorComponent,
    AppointmentComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    SatDatepickerModule,
    SatNativeDateModule,
    HttpModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: '', component: LogInComponent },
      { path: 'informations', component: InformationsComponent },
      { path: 'logout', component: EmptyComponent, canActivate: [AuthGuard] },
      { path: 'patient/appointment', component: PatientSchedulingComponent},
      { path: 'updating/shifts', component: UpdatingShiftsComponent, canActivate: [AuthGuard] },
      { path: 'choose/docotr', component: ChooseDoctorComponent, canActivate: [AuthGuard] },
      { path: 'create/account', component: CreateAccountComponent, canActivate: [AuthGuard] },
      { path: 'accounts/list', component: AccountsListComponent, canActivate: [AuthGuard] },
      { path: 'password/change', component: PasswordChangeComponent, canActivate: [AuthGuard] },
      { path: 'appointments', component: AppointmentsListComponent, canActivate: [AuthGuard] },
      { path: 'appointment/:id', component: AppointmentComponent, canActivate: [AuthGuard] },
      { path: 'schedule', component: ScheduleComponent, canActivate: [AuthGuard] },
    ])
  ],
  providers: [
    TimeService,
    DoctorService,
    PatientService,
    AppointmentService,
    TehnicianService,
    ShiftService,
    TitleService,
    FacilityService,
    DoctorShiftService,
    TehnicianShiftService,
    AdminService,
    AuthGuard,
    LeavingPageGuard,
    AuthService,
    JwtHelperService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
  //  { provide: ErrorHandler, useClass: AppErrorHandler },
    { provide: MatPaginatorIntl, useValue: translatePaginatorIntl() }
  ],
  exports: [],
  entryComponents:
    [DialogOverviewExampleDialog,
      MedicalCertificate,
      ConfirmDoctorDialog,
      DeleteDialog,
      AppointToSpecialist,
      ArrangeAppointmentDialog,
      ArangeControl,
      CancelAppointmentDialog,
      LogoutDialog],
  bootstrap: [AppComponent]
})
export class AppModule { }
