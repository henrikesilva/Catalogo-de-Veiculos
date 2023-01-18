import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from 'src/app/Models/Usuario';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit{
  tituloTela: string = '';
  cadastrar: boolean = false;

  form: Usuario = {
    usuarioId: 0,
    nome: '',
    loginUsuario: '',
    senha: '',
    administrador: false,
    statusUsuario: true
  };

  constructor(
    private usuarioService: UsuarioService,
    private alertsService: AlertService,
    private router: Router,
    private route: ActivatedRoute
  ) {}


  ngOnInit(): void {
    let loginUsuario: string = this.route.snapshot.paramMap.get('loginUsuario') || '';
    
    if(loginUsuario === ''){
      this.cadastrar = true;
      this.form;
      this.tituloTela = 'Cadastro';
    }

    else{
      this.usuarioService.buscarUsuarioPorNome(loginUsuario).subscribe(usuario => {
        this.form = {
          usuarioId: usuario.usuarioId,
          nome: usuario.nome,
          loginUsuario: usuario.loginUsuario,
          senha: '',
          administrador: usuario.administrador,
          statusUsuario: usuario.statusUsuario
        }
      }, 
      error => {
        this.alertsService.oneErrorMessage('Ocorreu um erro ao buscar o usuario');
      })
      
      this.tituloTela = 'Atualizar'
    }
  }

  onSubmit() : void{
    this.converterBool();
    if(this.form.usuarioId != 0){
      this.usuarioService.atualizarUsuario(this.form).subscribe({
        next: (s) => {
          this.alertsService.oneSuccessMessage('Usuario atualizado com sucesso');
          this.router.navigate(['/usuarios']); 
        },
        error: (e) => {
          //this.alertsService.oneErrorMessage('Não foi possivel atualizar o usuario');
          console.log(e)
        }
      });
    }
    else{

      if(this.form.nome === ''){
        this.alertsService.oneErrorMessage('Informe o nome do usuario');
      }
      else{
        this.usuarioService.adicionarUsuario(this.form).subscribe({
          next: (s) => {
            this.alertsService.oneSuccessMessage('Usuario cadastrada com sucesso');
            this.router.navigate(['/usuarios']); 
          },
          error: (e) => {
            //this.alertsService.oneErrorMessage('Não foi possivel cadastrar o usuario');
          }
        });
      }
    }
  }

  converterBool(){
    if(this.form.administrador.toString() === "true"){
      this.form.administrador = true
    }
    else{
      this.form.administrador = false
    }    

      if(this.form.statusUsuario.toString() === "true"){
        this.form.statusUsuario = true
      }
      else{
        this.form.statusUsuario = false
      }    
  }
}
