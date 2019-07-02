import { Component, OnInit, Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material";



@Component({
  selector: 'medical-certificate-dialog',
  templateUrl: 'aranging-control.html'
})
export class ArangeControl implements OnInit {


  hideSpinner: boolean;

  doctorId: number;


  constructor(
    public dialogRef: MatDialogRef<ArangeControl>,
    @Inject(MAT_DIALOG_DATA) public data: { patientId: number, patientName: string, doctorId: number; }) { }

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
