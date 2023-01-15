import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/app/Models/ArquivoConfig';
import { Login } from 'src/app/Models/Login';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private currentUserSubject?: BehaviorSubject<Login>;
  public currentUser?: Observable<Login>;

  constructor(
    private http: HttpClient,
    private route: Router
  ) { 
    this.currentUserSubject = new BehaviorSubject<Login>(JSON.parse(localStorage.getItem('currentUser') || ''));
    this.currentUser = this.currentUserSubject?.asObservable();
  }

  public get currentUserValue() : Login{
    if(this.currentUserSubject)
      return this.currentUserSubject.value;

    return new Login;
  }

  login(usuario: string, senha: string){
    return this.http.post<Login>(`${environment.apiBaseUrl}/usuario/login`, {usuario, senha})
                    .pipe(
                      map(user => {
                        localStorage.setItem('currentUser', JSON.stringify(user));
                        this.currentUserSubject?.next(user);
                        return user;
                      })
                    )
  }

  logout(){
    localStorage.removeItem('currentUser');
    localStorage.clear();
    this.route.navigate(['home']);
  }
}
