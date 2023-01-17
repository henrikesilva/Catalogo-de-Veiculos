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
}
