import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarVeiculosComponent } from './components/cadastrar-veiculos/cadastrar-veiculos.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { LoginComponent } from './components/login/login.component';
import { ContentComponent } from './components/template/content/content.component';
import { GuardService } from './services/guard/guard.service';

const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    component: ContentComponent,
    children: [
      {
        path: '',
        component: InicioComponent
      },
      {
        path: 'cadastrar-veiculo',
        component: CadastrarVeiculosComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'atualizar-veiculo/:veiculoId',
        component: CadastrarVeiculosComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      }
    ]
  },
  {
    path: '**',
    redirectTo: ''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
