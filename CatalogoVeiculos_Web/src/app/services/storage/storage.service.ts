import { Injectable } from '@angular/core';
import { Usuario } from 'src/app/Models/Usuario';

const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  clean(): void{
    window.localStorage.clear();
  }

  public saveUser(usuario: Usuario): void{
    window.localStorage.removeItem(USER_KEY);
    window.localStorage.setItem(USER_KEY, JSON.stringify(usuario));
  }

  public getUser(): any{
    const user = window.localStorage.getItem(USER_KEY);
    if(user){
      return JSON.parse(user);
    }

    return;
  }

  public isLoggedIn(): boolean {
    const user = window.localStorage.getItem(USER_KEY);
    if (user) {
      return true;
    }

    return false;
  }
}
