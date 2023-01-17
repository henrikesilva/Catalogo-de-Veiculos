import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/Models/ArquivoConfig';
import { Usuario } from 'src/app/Models/Usuario';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient) { }
  
  buscarUsuarioPorNome(nome: string) : Observable<Usuario>{
    return this.http.get<Usuario>(`${environment.apiBaseUrl}/usuario/buscar?nome=${nome}`);
  }
}
