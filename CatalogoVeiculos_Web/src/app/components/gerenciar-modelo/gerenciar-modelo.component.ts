import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Modelo } from 'src/app/Models/Modelo';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { ModeloService } from 'src/app/services/modelo/modelo.service';
import { StorageService } from 'src/app/services/storage/storage.service';

@Component({
  selector: 'app-gerenciar-modelo',
  templateUrl: './gerenciar-modelo.component.html',
  styleUrls: ['./gerenciar-modelo.component.css']
})
export class GerenciarModeloComponent {
  displayedColumns: string[] = ['nomeModelo', 'nomeMarca', 'modeloId'];
  dataSource = new MatTableDataSource<Modelo>(ELEMENT_DATA);
  modelos: Modelo[] = [];

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(
    private storageService: StorageService,
    private modeloService: ModeloService,
    private alertService: AlertService
  ) {
    modeloService.listarModelo().subscribe(modelo => {
      this.modelos = modelo;

      this.dataSource = new MatTableDataSource<Modelo>(this.modelos);
      this.dataSource.paginator = this.paginator || this.dataSource.paginator;
      this.dataSource.sort = this.sort || this.dataSource.sort;
    },
    erro => {
      alertService.oneErrorMessage('Ocorreu um erro inesperado');
    })
  }

}

const ELEMENT_DATA: Modelo[] = [];