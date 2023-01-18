import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/Models/ArquivoConfig';
import { Modelo } from 'src/app/Models/Modelo';

@Injectable({
  providedIn: 'root'
})
export class ModeloService {

  constructor(
    private http: HttpClient
  ) { }

  listarModelo() : Observable<Modelo[]>{
    return this.http.get<Modelo[]>(`${environment.apiBaseUrl}/Modelo/BuscarTodos`);
  }
  
  buscarModeloPorId(modeloId: number) : Observable<Modelo>{
    return this.http.get<Modelo>(`${environment.apiBaseUrl}/Modelo/Buscar/${modeloId}`);
  }

  listarModeloPorMarca(marcaId: number) : Observable<Modelo[]>{
    return this.http.get<Modelo[]>(`${environment.apiBaseUrl}/Modelo/BuscarMarcas/${marcaId}`);
  }

  adicionarModelo(modelo: Modelo) : Observable<Modelo>{
    return this.http.post<Modelo>(`${environment.apiBaseUrl}/Modelo/Adicionar`, modelo);
  }

  atualizarModelo(modelo: Modelo) : Observable<Modelo>{
    return this.http.put<Modelo>(`${environment.apiBaseUrl}/Modelo/Atualizar`, modelo);
  }

  excluirModelo(modeloId: number) : Observable<Modelo>{
    return this.http.delete<Modelo>(`${environment.apiBaseUrl}/Modelo/Excluir/${modeloId}`);
  }
}
