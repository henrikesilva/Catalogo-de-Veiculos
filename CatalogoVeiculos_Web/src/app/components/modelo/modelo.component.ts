import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Marca } from 'src/app/Models/Marca';
import { Modelo } from 'src/app/Models/Modelo';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { MarcaService } from 'src/app/services/marca/marca.service';
import { ModeloService } from 'src/app/services/modelo/modelo.service';

@Component({
  selector: 'app-modelo',
  templateUrl: './modelo.component.html',
  styleUrls: ['./modelo.component.css']
})
export class ModeloComponent implements OnInit {
  tituloTela: string = '';
  cadastrar: boolean = false;
  marcas: Marca[] = [];

  form: Modelo = {
    modeloId: 0,
    nomeModelo: '',
    statusModelo: true,
    marcaId: 0,
    marca: {
      marcaId: 0,
      nomeMarca: '',
      statusMarca: true
    }
  };

  listaMarcas: Marca[] = [];

  constructor(
    private modeloService: ModeloService,
    private marcaService: MarcaService,
    private alertsService: AlertService,
    private router: Router,
    private route: ActivatedRoute
  ) {

  }

  ngOnInit(): void {
    let id: number = parseInt(this.route.snapshot.paramMap.get('modeloId') || '');

    if (isNaN(id)) {
      this.cadastrar = true;
      this.form;
      this.tituloTela = 'Cadastro';
    }

    else {
      this.modeloService.buscarModeloPorId(id).subscribe(modelo => {
        this.form = {
          modeloId: modelo.modeloId,
          nomeModelo: modelo.nomeModelo,
          statusModelo: modelo.statusModelo,
          marcaId: modelo.marca.marcaId,
          marca: {
            marcaId: modelo.marca.marcaId,
            nomeMarca: modelo.marca.nomeMarca,
            statusMarca: modelo.marca.statusMarca
          }
        }
      },
        error => {
          this.alertsService.oneErrorMessage(`${error.error}`);
        })

      this.tituloTela = 'Atualizar'
    }

    this.marcaService.listarMarcas().subscribe(marca => {
      this.listaMarcas = marca
      
      this.verificarStatusMarca();
    
    });
  }

  buscarMarca(nome: any) {
    var marcas = this.listaMarcas.filter(function (obj) {
      return obj.nomeMarca === nome;
    });

    if (marcas)
      for (const modelo of marcas) {
        this.form.marcaId = modelo.marcaId;
        this.form.marca.marcaId = modelo.marcaId;
        this.form.marca.nomeMarca = modelo.nomeMarca;
      }
  }

  onSubmit() : void{
    this.atualizarStatus();

    if(this.form.modeloId != 0){
      this.modeloService.atualizarModelo(this.form).subscribe({
        next: (s) => {
          this.alertsService.oneSuccessMessage('Modelo atualizado com sucesso');
          this.router.navigate(['/modelos']); 
        },
        error: (e) => {
          this.alertsService.oneErrorMessage(`${e.error}`);
        }
      });
    }
    else{

      if(this.form.nomeModelo === ''){
        this.alertsService.oneErrorMessage('Informe o nome do modelo');
      }
      else{
        this.modeloService.adicionarModelo(this.form).subscribe({
          next: (s) => {
            this.alertsService.oneSuccessMessage('Modelo cadastrado com sucesso');
            this.router.navigate(['/modelos']); 
          },
          error: (e) => {
            this.alertsService.oneErrorMessage(`${e.error}`);
          }
        });
      }
    }
  }

  atualizarStatus(){
    if(this.form.statusModelo.toString() === "true"){
      this.form.statusModelo = true
    }
    else{
      this.form.statusModelo = false
    }
  }

  verificarStatusMarca(){
    for(var marca of this.listaMarcas){
      if(marca.statusMarca){
        this.marcas.push(marca);
      }
    }
  }
}
