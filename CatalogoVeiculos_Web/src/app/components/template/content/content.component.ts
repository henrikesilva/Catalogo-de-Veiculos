import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/app/Models/ArquivoConfig';
import { Veiculos } from 'src/app/Models/Veiculos';
import { VeiculoService } from 'src/app/services/veiculos/veiculo.service';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit{
  veiculos: any;

  constructor(
    private http: HttpClient,
    private router: Router
  ) {
    
  }

  ngOnInit(): void {
    this.http.get<Veiculos[]>(`${environment.apiBaseUrl}/Veiculo/buscar`).subscribe(veiculo => {
      this.veiculos = veiculo
    }, err => {
      console.log('Erro ao consultar os dados');
    });
  }

  detalhesVeiculo(veiculoId: number){
    this.router.navigate(['detalhes', veiculoId]);
  }
}
