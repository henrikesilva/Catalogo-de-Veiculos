import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AlertService } from '../alerts/alert.service';
import { StorageService } from '../storage/storage.service';

@Injectable({
  providedIn: 'root'
})
export class GuardService {

  constructor(
    private storageService: StorageService,
    private alertsService: AlertService,
    private router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    var user = this.storageService.isLoggedIn();
    var localStorage = this.storageService.getUser();

    if (localStorage) {
      if (user && localStorage.result.administrador === true) {
        return true;
      }
      else if (!user && localStorage.admin === false) {
        this.alertsService.oneErrorMessage('O seu login expirou, por favor entre novamente no sistema');
        this.storageService.clean();

        return false;
      }
      else {
        this.router.navigate(['/'], {
          queryParams: { returnUrl: state.url }
        });
        return false;
      }
    }
    else{
      this.router.navigate(['/'], {
        queryParams: { returnUrl: state.url }
      });
      return false;
    }

  }
}
