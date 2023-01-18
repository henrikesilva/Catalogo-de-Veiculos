import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/Models/ArquivoConfig';
import { Marca } from 'src/app/Models/Marca';

@Injectable({
  providedIn: 'root'
})
export class MarcaService {

  constructor(
    private http: HttpClient
  ) { }

  listarMarcas() : Observable<Marca[]>{
    return this.http.get<Marca[]>(`${environment.apiBaseUrl}/Marca/BuscarTodas`);
  }

  buscarMarcaPorId(marcaId: number) : Observable<Marca>{
    return this.http.get<Marca>(`${environment.apiBaseUrl}/marca/buscar/${marcaId}`);
  }

  adicionarMarca(Marca: Marca) : Observable<Marca>{
    return this.http.post<Marca>(`${environment.apiBaseUrl}/Marca/Adicionar`, Marca);
  }

  atualizarMarca(Marca: Marca) : Observable<Marca>{
    return this.http.put<Marca>(`${environment.apiBaseUrl}/Marca/atualizar`, Marca);
  }

  excluirMarca(marcaId: number) : Observable<Marca>{
    return this.http.delete<Marca>(`${environment.apiBaseUrl}/Marca/Excluir/${marcaId}`);
  }
}
