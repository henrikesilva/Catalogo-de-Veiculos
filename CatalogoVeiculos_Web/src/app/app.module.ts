import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './components/template/header/header.component';
import { FooterComponent } from './components/template/footer/footer.component';
import { LoginComponent } from './components/login/login.component';
import { ContentComponent } from './components/template/content/content.component';

import { AuthService } from './services/auth/auth.service';
import { GuardService } from './services/guard/guard.service';
import { httpInterceptorProviders, InterceptorService } from './services/interceptors/interceptor.service';
import { CadastrarVeiculosComponent } from './components/cadastrar-veiculos/cadastrar-veiculos.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { MarcaComponent } from './components/marca/marca.component';
import { GerenciarMarcaComponent } from './components/gerenciar-marca/gerenciar-marca.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    ContentComponent,
    CadastrarVeiculosComponent,
    InicioComponent,
    MarcaComponent,
    GerenciarMarcaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    
    MatSnackBarModule,
    MatInputModule,
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatIconModule,
    MatButtonModule,

    HttpClientModule
  ],
  providers: [
    AuthService,
    GuardService,
    httpInterceptorProviders
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
