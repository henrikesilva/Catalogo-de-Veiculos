import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../auth/auth.service';
import { StorageService } from '../storage/storage.service';

@Injectable({
  providedIn: 'root'
})
export class GuardService {

  constructor(
    private authService: AuthService,
    private storageService: StorageService,
    private router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
    var user = this.storageService.isLoggedIn();
    var localStorage = this.storageService.getUser();

    if(user && localStorage.admin === true){
        return true;
    }
    else{
      this.router.navigate(['/'], {
        queryParams: {returnUrl: state.url}
      });
      return false;
    }
  }
}
