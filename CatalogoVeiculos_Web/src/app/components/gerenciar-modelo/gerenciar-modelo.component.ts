import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Modelo } from 'src/app/Models/Modelo';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { ModeloService } from 'src/app/services/modelo/modelo.service';

@Component({
  selector: 'app-gerenciar-modelo',
  templateUrl: './gerenciar-modelo.component.html',
  styleUrls: ['./gerenciar-modelo.component.css']
})
export class GerenciarModeloComponent {
  displayedColumns: string[] = ['nomeModelo', 'nomeMarca', 'statusModelo', 'modeloId'];
  dataSource = new MatTableDataSource<Modelo>(ELEMENT_DATA);
  modelos: Modelo[] = [];
  modelo: any;

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(
    private router: Router,
    private modeloService: ModeloService,
    private alertService: AlertService
  ) {
    modeloService.listarModelo().subscribe(modelo => {
      this.modelos = modelo;

      this.converterStatus();

      this.dataSource = new MatTableDataSource<Modelo>(this.modelos);
      this.dataSource.paginator = this.paginator || this.dataSource.paginator;
      this.dataSource.sort = this.sort || this.dataSource.sort;
    },
    erro => {
      this.alertService.oneErrorMessage(`${erro.error}`);
    })
  }

  converterStatus(){
    for(this.modelo of this.modelos){
      if(this.modelo.statusModelo === true){
        this.modelo.statusModelo = 'Ativo'
      }
      else{
        this.modelo.statusModelo = 'Inativo'
      }
    }
  }

  excluir(modeloId: number){
    this.modeloService.excluirModelo(modeloId).subscribe({
      next: (s) => {
        this.alertService.oneSuccessMessage('Modelo inativado com sucesso');
        window.location.reload();
      },
      error: (e) => {
        this.alertService.oneErrorMessage(`${e.error}`);
      }
    });
  }
}

const ELEMENT_DATA: Modelo[] = [];