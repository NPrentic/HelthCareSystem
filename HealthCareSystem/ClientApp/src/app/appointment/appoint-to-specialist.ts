import { Component, OnInit, Inject } from "@angular/core";
import { DoctorService } from "../Services/doctor.service";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";
import { TitleService } from "../Services/title.service";

@Component({
  selector: 'medical-certificate-dialog',
  templateUrl: 'appoint-to-specialist.html'
})
export class AppointToSpecialist implements OnInit {

  private _doctorId: number;

  hideSpinner: boolean;
  doctor: any;
  maxDate: Date = new Date(Date.now()) ;
  titles: DoctorTitle[];
  titleName: string;
  doctors: Doctor[];

  set doctorId(value){
    this._doctorId = null;
    this._doctorId = value;
  }

  get doctorId(): number { return this._doctorId; }

  constructor(
    private doctorsService: DoctorService,
    private titleService: TitleService,
    public dialogRef: MatDialogRef<AppointToSpecialist>,
    @Inject(MAT_DIALOG_DATA) public data: { patientName: string , patientId: number}) { }

  ngOnInit() {
    this.hideSpinner = false;

    this.titleService.getAll()
      .subscribe((res: DoctorTitle[]) => {
        this.titles = res.filter(t => t.isSpecialist == true);
        this.hideSpinner = true;
      });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  generateDoctorsList() {
    this.doctorsService.getDoctorsByQuery({ title: this.titleName })
      .subscribe((res: GetDoctors) => {
        this.doctors = res.doctors;
        this.doctorId = null;
      });
  }
}
