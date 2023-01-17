import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/app/Models/ArquivoConfig';
import { Veiculos } from 'src/app/Models/Veiculos';
import { AlertService } from 'src/app/services/alerts/alert.service';
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
    private veiculoService: VeiculoService,
    private alertsService: AlertService
  ) {
    
  }

  ngOnInit(): void {
    this.veiculoService.listarVeiculos().subscribe(veiculo => {
      this.veiculos = veiculo
    }, 
    err => {
      this.alertsService.oneErrorMessage('Ocorreu um erro ao buscar os veiculos cadastrados');
    });
  }

  detalhesVeiculo(veiculoId: number){
    this.router.navigate([`atualizar-veiculo/${veiculoId}`]);
  }
}
