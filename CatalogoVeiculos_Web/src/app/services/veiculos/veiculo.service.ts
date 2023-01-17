import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/Models/ArquivoConfig';
import { Veiculos } from 'src/app/Models/Veiculos';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {

  constructor(private http: HttpClient) { }

  listarVeiculos() : Observable<Veiculos[]>{
    return this.http.get<Veiculos[]>(`${environment.apiBaseUrl}/veiculo/buscar`);
  }

  buscarVeiculoPorId(veiculoId: number) : Observable<Veiculos>{
    return this.http.get<Veiculos>(`${environment.apiBaseUrl}/veiculo/buscar/${veiculoId}`);
  }

  adicionarVeiculo(Veiculo: Veiculos) : Observable<Veiculos>{
    return this.http.post<Veiculos>(`${environment.apiBaseUrl}/veiculo/cadastrar`, Veiculo);
  }
}
