import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { environment } from 'src/app/Models/ArquivoConfig';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(
    private http: HttpClient,
    private route: Router
  ) {}

  login(usuario: string, senha: string) : Observable<any>{
    return this.http.post(`${environment.apiBaseUrl}/usuario/login`, {usuario, senha}, httpOptions);
  }

  
}
