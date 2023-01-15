import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleGuardService implements CanActivate{

  constructor(
    private router: Router
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    const localUser = localStorage.getItem('currentUser');
    const expectedRole = route.data['expectedRole'];

    if(localUser)
      var permissao = JSON.parse(localUser);

    if(permissao.administrador === expectedRole){
      return true;
    }

    else{
      this.router.navigate(['/inicio']);
      return false;
    }
  }


}
