import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Usuario } from 'src/app/Models/Usuario';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';

@Component({
  selector: 'app-gerenciar-usuario',
  templateUrl: './gerenciar-usuario.component.html',
  styleUrls: ['./gerenciar-usuario.component.css']
})
export class GerenciarUsuarioComponent {
  displayedColumns: string[] = ['nome', 'loginUsuario', 'administrador', 'statusUsuario', 'usuarioId'];
  dataSource = new MatTableDataSource<Usuario>(ELEMENT_DATA);
  usuarios: Usuario[] = [];
  usuario: any;

  @ViewChild(MatPaginator) paginator?: MatPaginator;
  @ViewChild(MatSort) sort?: MatSort;

  constructor(
    private usuarioService: UsuarioService,
    private alertService: AlertService
  ) {
    usuarioService.listarUsuarios().subscribe(usuario => {
      this.usuarios = usuario;

      this.converterStatus();

      this.dataSource = new MatTableDataSource<Usuario>(this.usuarios);
      this.dataSource.paginator = this.paginator || this.dataSource.paginator;
      this.dataSource.sort = this.sort || this.dataSource.sort;
    },
    erro => {
      this.alertService.oneErrorMessage(`${erro.error}`);
    })
  }

  converterStatus(){
    for(this.usuario of this.usuarios){
      if(this.usuario.administrador === true){
        this.usuario.administrador = 'Sim'
      }
      else{
        this.usuario.administrador = 'Não'
      }

      if(this.usuario.statusUsuario === true){
        this.usuario.statusUsuario = 'Ativo'
      }
      else{
        this.usuario.statusUsuario = 'Inativo'
      }
    }
  }

  excluir(usuarioId: number){
    this.usuarioService.excluirUsuario(usuarioId).subscribe({
      next: (s) => {
        this.alertService.oneSuccessMessage('Usuario inativado com sucesso');
        window.location.reload();
      },
      error: (e) => {
        this.alertService.oneErrorMessage(`${e.error}`);
      }
    });
  }
}

const ELEMENT_DATA: Usuario[] = [];
