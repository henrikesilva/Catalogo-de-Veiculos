import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/Models/Login';
import { AlertService } from 'src/app/services/alerts/alert.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { StorageService } from 'src/app/services/storage/storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: any = {
    usuario: null,
    senha: null
  }

  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];

  constructor(
    private authservice: AuthService,
    private storageService: StorageService,
    private alertsService: AlertService,
    private router: Router
  ) { }


  ngOnInit(): void {
    if (this.storageService.isLoggedIn()) {
      this.isLoggedIn = true;
      this.roles = this.storageService.getUser().roles;
    }
  }

  onSubmit(): void {
    const { usuario, senha } = this.form;

    this.authservice.login(usuario, senha).subscribe({
      next: data => {
        this.storageService.saveUser(data);

        this.isLoggedIn = true;
        this.isLoginFailed = false;
        this.roles = this.storageService.getUser().roles;

        this.router.navigate(['/']);
        this.alertsService.oneSuccessMessage('Login efetuado com sucesso.');
      },
      error: err => {
        this.alertsService.oneErrorMessage('Ocorreu um erro ao tentar efetuar o Login');
        this.isLoginFailed = true;
      }
    })
  }
}
