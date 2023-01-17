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
}
