import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastrarVeiculosComponent } from './components/cadastrar-veiculos/cadastrar-veiculos.component';
import { GerenciarMarcaComponent } from './components/gerenciar-marca/gerenciar-marca.component';
import { GerenciarModeloComponent } from './components/gerenciar-modelo/gerenciar-modelo.component';
import { GerenciarUsuarioComponent } from './components/gerenciar-usuario/gerenciar-usuario.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { LoginComponent } from './components/login/login.component';
import { MarcaComponent } from './components/marca/marca.component';
import { ModeloComponent } from './components/modelo/modelo.component';
import { ContentComponent } from './components/template/content/content.component';
import { UsuarioComponent } from './components/usuario/usuario.component';
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
      },
      {
        path: 'marcas',
        component: GerenciarMarcaComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'cadastrar-marca',
        component: MarcaComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'atualizar-marca/:marcaId',
        component: MarcaComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'modelos',
        component: GerenciarModeloComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'cadastrar-modelo',
        component: ModeloComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'atualizar-modelo/:modeloId',
        component: ModeloComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'usuarios',
        component: GerenciarUsuarioComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'cadastrar-usuario',
        component: UsuarioComponent,
        canActivate: [GuardService],
        data: {
          expectedRole: true
        }
      },
      {
        path: 'atualizar-usuario/:loginUsuario',
        component: UsuarioComponent,
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
