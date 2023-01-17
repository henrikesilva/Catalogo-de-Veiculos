import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

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

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    LoginComponent,
    ContentComponent,
    CadastrarVeiculosComponent,
    InicioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,

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
