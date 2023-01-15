import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../auth/auth.service';

@Injectable({
  providedIn: 'root'
})
export class GuardService {

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot){
    var localUser = localStorage.getItem('currentUser');
    var permission = this.authService.currentUserValue;

    if(localUser != null){
      if(route.data['role'] && route.data['role'].indexOf(permission?.Administrador) === -1){
        this.router.navigate(['/administrador']);
        return false;
      }

      return true
    }
    else{
      this.router.navigate(['/inicio'], {
        queryParams: {returnUrl: state.url}
      });
      return false;
    }
  }
}
