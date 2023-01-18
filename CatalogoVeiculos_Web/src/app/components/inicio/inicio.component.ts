import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Veiculos } from 'src/app/Models/Veiculos';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { StorageService } from 'src/app/services/storage/storage.service';
import { VeiculoService } from 'src/app/services/veiculos/veiculo.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit {
  veiculos: Veiculos[] = [];
  admin: boolean = false;
  user: any;

  constructor(
    private router: Router,
    private veiculoService: VeiculoService,
    private alertsService: AlertService,
    private storageService: StorageService
  ) {
    
  }

  ngOnInit(): void {
    this.veiculoService.listarVeiculos().subscribe(veiculo => {
      this.veiculos = veiculo
    }, 
    err => {
      this.alertsService.oneErrorMessage(`${err.error}`);
    });

    this.user = this.storageService.getUser();

    if(this.user === undefined){
      this.admin = false;
    }
    else{
      this.admin = true;
    }
  }

  detalhesVeiculo(veiculoId: number){
    this.router.navigate([`atualizar-veiculo/${veiculoId}`]);
  }

  excluir(veiculoId: number){
    this.veiculoService.excluirVeiculo(veiculoId).subscribe({
      next: (s) => {
        this.alertsService.oneSuccessMessage('Veiculo inativado com sucesso');
        window.location.reload();
      },
      error: (e) => {
        this.alertsService.oneErrorMessage(`${e.error}`);
      }
    });
  }
}
