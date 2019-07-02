import { ErrorHandler,Inject, NgZone } from "@angular/core";
import { MatSnackBar } from '@angular/material';
import { NotFoundError } from "./not-fond-error";
import { BadRequestError } from "./bad-request-error";


export class AppErrorHandler implements ErrorHandler {

  constructor(private ngZone: NgZone, @Inject(MatSnackBar) private snackBar: MatSnackBar) { }

  handleError(error: any): void{

    this.ngZone.run(() => {
      if (error instanceof NotFoundError) {
        console.log(error);
        this.snackBar.open("Veza sa serverom ne može biti uspostavljena.", "Ok", {
          duration: 3000, horizontalPosition: 'left'
        });
      }
      else {
        if (error instanceof BadRequestError) {
          console.log(error);
          this.snackBar.open("Uputili ste neregularan zahtjev.", "Ok", {
            duration: 3000, horizontalPosition: 'left'
          });
        }
        else {
          console.log(error);
          this.snackBar.open("Došlo je do neočekivane greške.", "Ok", {
            duration: 3000, horizontalPosition: 'left'
          });
        }    
      }
    })

  }
}
