import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Marca } from 'src/app/Models/Marca';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { MarcaService } from 'src/app/services/marca/marca.service';
import { StorageService } from 'src/app/services/storage/storage.service';

@Component({
  selector: 'app-marca',
  templateUrl: './marca.component.html',
  styleUrls: ['./marca.component.css']
})
export class MarcaComponent implements OnInit{
  tituloTela: string = '';
  cadastrar: boolean = false;

  form: Marca = {
    marcaId: 0,
    nomeMarca: '',
    statusMarca: true
  };

  constructor(
    private marcaService: MarcaService,
    private storageService: StorageService,
    private alertsService: AlertService,
    private router: Router,
    private route: ActivatedRoute
  ) {}


  ngOnInit(): void {
    let id: number = parseInt(this.route.snapshot.paramMap.get('marcaId') || '');

    if(isNaN(id)){
      this.cadastrar = true;
      this.form;
      this.tituloTela = 'Cadastro';
    }

    else{
      this.marcaService.buscarMarcaPorId(id).subscribe(marca => {
        this.form = {
          marcaId: marca.marcaId,
          nomeMarca: marca.nomeMarca,
          statusMarca: marca.statusMarca
        }
      }, 
      error => {
        this.alertsService.oneErrorMessage('Ocorreu um erro ao buscar a marca');
      })
      
      this.tituloTela = 'Atualizar'
    }
  }

  onSubmit() : void{
    this.atualizarStatus();

    if(this.form.marcaId != 0){
      this.marcaService.atualizarMarca(this.form).subscribe({
        next: (s) => {
          this.alertsService.oneSuccessMessage('Marca atualizada com sucesso');
          this.router.navigate(['/marcas']); 
        },
        error: (e) => {
          this.alertsService.oneErrorMessage('Não foi possivel atualizar a marca');
          console.log(e)
        }
      });
    }
    else{

      if(this.form.nomeMarca === ''){
        this.alertsService.oneErrorMessage('Informe o nome da marca');
      }
      else{
        this.marcaService.adicionarMarca(this.form).subscribe({
          next: (s) => {
            this.alertsService.oneSuccessMessage('Marca cadastrada com sucesso');
            this.router.navigate(['/marcas']); 
          },
          error: (e) => {
            //this.alertsService.oneErrorMessage('Não foi possivel cadastrar a marca');
          }
        });
      }
    }
  }

  atualizarStatus(){
    if(this.form.statusMarca.toString() === "true"){
      this.form.statusMarca = true
    }
    else{
      this.form.statusMarca = false
    }
  }
}
