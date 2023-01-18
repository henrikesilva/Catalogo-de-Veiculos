import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Marca } from 'src/app/Models/Marca';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { MarcaService } from 'src/app/services/marca/marca.service';

@Component({
  selector: 'app-gerenciar-marca',
  templateUrl: './gerenciar-marca.component.html',
  styleUrls: ['./gerenciar-marca.component.css']
})
export class GerenciarMarcaComponent{
  
  displayedColumns: string[] = ['nomeMarca', 'statusMarca', 'marcaId'];
  dataSource = new MatTableDataSource<Marca>(ELEMENT_DATA);
  marcas: Marca[] = [];
  marca: any;

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(
    private marcaService: MarcaService,
    private alertService: AlertService
  ) {
    marcaService.listarMarcas().subscribe(marca => {
      this.marcas = marca;

      this.converterStatus();

      this.dataSource = new MatTableDataSource<Marca>(this.marcas);
      this.dataSource.paginator = this.paginator || this.dataSource.paginator;
      this.dataSource.sort = this.sort || this.dataSource.sort;
    },
    erro => {
      this.alertService.oneErrorMessage(`${erro.error}`);
    })
  }

  converterStatus(){
    for(this.marca of this.marcas){
      if(this.marca.statusMarca === true){
        this.marca.statusMarca = 'Ativo'
      }
      else{
        this.marca.statusMarca = 'Inativo'
      }
    }
  }

  excluir(marcaId: number){
    this.marcaService.excluirMarca(marcaId).subscribe({
      next: (s) => {
        this.alertService.oneSuccessMessage('Marca inativada com sucesso');
        window.location.reload();
      },
      error: (e) => {
        this.alertService.oneErrorMessage(`${e.error}`);
      }
    });
  }
}

const ELEMENT_DATA: Marca[] = [];