import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private snackBar: MatSnackBar) { }

  timeOut = 10000;
  errorTimeout = 20000;

  oneSuccessMessage(message: string){
    this.snackBar.open(message, 'X', {
      duration: this.timeOut,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: ['alertMsg']
    });
  }

  oneErrorMessage(message: string){
    this.snackBar.open(message, 'X', {
      duration: this.errorTimeout,
      horizontalPosition: 'center',
      verticalPosition: 'top',
      panelClass: ['errorMsg']
    });
  }
}
