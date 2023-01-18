import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Marca } from 'src/app/Models/Marca';
import { Modelo } from 'src/app/Models/Modelo';
import { Usuario } from 'src/app/Models/Usuario';
import { Veiculos } from 'src/app/Models/Veiculos';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { MarcaService } from 'src/app/services/marca/marca.service';
import { ModeloService } from 'src/app/services/modelo/modelo.service';
import { StorageService } from 'src/app/services/storage/storage.service';
import { UsuarioService } from 'src/app/services/usuario/usuario.service';
import { VeiculoService } from 'src/app/services/veiculos/veiculo.service';

@Component({
  selector: 'app-cadastrar-veiculos',
  templateUrl: './cadastrar-veiculos.component.html',
  styleUrls: ['./cadastrar-veiculos.component.css']
})
export class CadastrarVeiculosComponent implements OnInit {

  habilitado: boolean = false;
  tituloTela: string = '';
  modeloHabilitado: boolean = false;
  cadastrar: boolean = false;

  form: Veiculos = {
    nome: '',
    foto: '',
    preco: 0,
    veiculoId: 0,
    marcaId: 0,
    modeloId: 0,
    usuarioId: 0,
    usuario: {
      usuarioId: 0,
      usuario: '',
      administrador: false,
      nome: '',
      senha: ''
    },
    modelo: {
      modeloId: 0,
      nomeModelo: '',
      marcaId: 0,
      marca: {
        marcaId: 0,
        nomeMarca: ''
      },
    }
  };

  listaModelos: Modelo[] = [];
  listaMarcas: Marca[] = [];
  usuario: Usuario = {
    usuarioId: 0,
    nome: '',
    usuario: '',
    administrador: false,
    senha: ''
  };


  constructor(
    private veiculoService: VeiculoService,
    private marcaService: MarcaService,
    private modeloService: ModeloService,
    private usuarioService: UsuarioService,
    private storageService: StorageService,
    private alertsService: AlertService,
    private router: Router,
    private route: ActivatedRoute
  ) {

  }

  ngOnInit(): void {
    let id: number = parseInt(this.route.snapshot.paramMap.get('veiculoId') || '');
    const usuarioLogin = this.storageService.getUser();

    this.usuarioService.buscarUsuarioPorNome(usuarioLogin.result.usuario).subscribe(usaurioRetorno => this.usuario = usaurioRetorno);

    if (isNaN(id)) {
      this.cadastrar = true;
      this.form;
      this.form.usuarioId = this.usuario.usuarioId;
      this.tituloTela = 'Cadastro';
    }

    else {
      this.veiculoService.buscarVeiculoPorId(id).subscribe(veiculo => {
        this.form = {
          veiculoId: veiculo.veiculoId,
          nome: veiculo.nome,
          foto: veiculo.foto,
          preco: veiculo.preco,
          modeloId: veiculo.modelo.modeloId,
          dataCriacao: veiculo.dataCriacao,
          dataAtualizacao: veiculo.dataAtualizacao,
          marcaId: veiculo.modelo.marca.marcaId,
          modelo: veiculo.modelo,
          usuarioId: this.usuario.usuarioId,

          usuario: this.usuario
        }
      },
        error => {
          this.alertsService.oneErrorMessage('Ocorreu um erro ao buscar o veiculo');
        })

      this.tituloTela = 'Atualizar'
      this.habilitado = true;
    }

    this.marcaService.listarMarcas().subscribe(marca => this.listaMarcas = marca);
  }

  buscarMarca(nome: any) {
    this.listaModelos = [];
    var marcas = this.listaMarcas?.filter(function (obj) {
      return obj.nomeMarca === nome;
    });

    if (marcas) {
      for (const marca of marcas) {
        this.modeloService.listarModeloPorMarca(marca.marcaId).subscribe({
          next: (s) => {
            if(s.length === 0){
              this.alertsService.oneErrorMessage('Não foram encontrados modelos cadastrados para essa marca, por gentileza cadastre o modelo para continuar');
            }
            else{
              this.listaModelos = s;
            }
          },
          error: (e) => {
            this.alertsService.oneErrorMessage('Ocorreu um erro ao processar os dados');
          }
        });
        this.modeloHabilitado = true;

        this.form.marcaId = marca.marcaId;
        this.form.modelo.marca.marcaId = marca.marcaId;
        this.form.modelo.marca.nomeMarca = marca.nomeMarca;
      }
    }

  }

  buscarModelo(nome: any) {
    var modelos = this.listaModelos.filter(function (obj) {
      return obj.nomeModelo === nome;
    });

    if (modelos)
      for (const modelo of modelos) {
        this.form.modeloId = modelo.modeloId;
        this.form.modelo.modeloId = modelo.modeloId;
        this.form.modelo.nomeModelo = modelo.nomeModelo;
        this.habilitado = true;
      }


  }

  onSubmit(): void {
    this.form.usuarioId = this.usuario.usuarioId;
    this.form.usuario.senha = '';
    this.form.usuario = this.usuario;

    if (this.form.veiculoId != 0) {
      this.veiculoService.atualizarVeiculo(this.form).subscribe(success => {
        this.alertsService.oneSuccessMessage('Veiculo atualizado com sucesso');
        this.router.navigate(['/']);
      });
    }
    else {
      this.veiculoService.adicionarVeiculo(this.form).subscribe(success => {
        this.alertsService.oneSuccessMessage('Veiculo cadastrado com sucesso');
        this.router.navigate(['/']);
      });
    }
  }
}
