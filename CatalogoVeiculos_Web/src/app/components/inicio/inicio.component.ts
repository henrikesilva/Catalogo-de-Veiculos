import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/app/Models/ArquivoConfig';
import { Veiculos } from 'src/app/Models/Veiculos';
import { VeiculoService } from 'src/app/services/veiculos/veiculo.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
  veiculos: Veiculos[] = [];

  constructor(
    private http: HttpClient,
    private router: Router,
    private veiculoService: VeiculoService
  ) {
    
  }

  ngOnInit(): void {
    this.veiculoService.listarVeiculos().subscribe(veiculo => this.veiculos = veiculo);
  }

  detalhesVeiculo(veiculoId: number){
    this.router.navigate(['detalhes', veiculoId]);
  }
}
