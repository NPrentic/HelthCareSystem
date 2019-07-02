import { Component, OnInit, Inject } from "@angular/core";
import { DoctorService } from "../Services/doctor.service";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";

@Component({
  selector: 'medical-certificate-dialog',
  templateUrl: 'medical-certificate-dialog.html'
})
export class MedicalCertificate implements OnInit {

  hideSpinner: boolean;
  doctor: any;
  maxDate: Date = new Date(Date.now());
  text: string;
  dates: DateRange;

  constructor(
    private doctorsService: DoctorService,
    public dialogRef: MatDialogRef<MedicalCertificate>,
    @Inject(MAT_DIALOG_DATA) public data: { doctorId: number, patientName: string }) { }

  ngOnInit() {
    this.hideSpinner = false;

    this.doctorsService.get(this.data.doctorId)
      .subscribe((res: any) => {
        this.doctor = res
        this.hideSpinner = true;

      });
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
