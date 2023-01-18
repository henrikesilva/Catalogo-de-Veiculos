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

  listarUsuarios() : Observable<Usuario[]>{
    return this.http.get<Usuario[]>(`${environment.apiBaseUrl}/Usuario/BuscarTodos`);
  }

  adicionarUsuario(Usuario: Usuario) : Observable<Usuario>{
    return this.http.post<Usuario>(`${environment.apiBaseUrl}/Usuario/Cadastrar`, Usuario);
  }

  atualizarUsuario(Usuario: Usuario) : Observable<Usuario>{
    return this.http.put<Usuario>(`${environment.apiBaseUrl}/Usuario/atualizar`, Usuario);
  }

  excluirUsuario(usuarioId: number) : Observable<Usuario>{
    return this.http.delete<Usuario>(`${environment.apiBaseUrl}/Usuario/Excluir/${usuarioId}`);
  }
}
