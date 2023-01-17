import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/Models/Usuario';

const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor(private router: Router) { }

  clean(): void{
    localStorage.clear();
    this.router.navigate(['/'])
  }

  public saveUser(usuario: Usuario): void{
    localStorage.removeItem(USER_KEY);
    localStorage.setItem(USER_KEY, JSON.stringify(usuario));
  }

  public getUser(): any{
    const user = localStorage.getItem(USER_KEY);
    if(user){
      return JSON.parse(user);
    }

    return;
  }

  public isLoggedIn(): boolean {
    const user = localStorage.getItem(USER_KEY);
    if (user) {
      return true;
    }

    return false;
  }
}
