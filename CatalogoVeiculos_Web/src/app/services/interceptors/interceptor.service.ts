import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { delay, mergeMap, Observable, retryWhen } from 'rxjs';
import { AlertService } from '../alerts/alert.service';
import { StorageService } from '../storage/storage.service';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {
  constructor(
    private storageService: StorageService,
    private router: Router,
    private alertService: AlertService
  ) { }

  maxRetries: number = 2;

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const user = this.storageService.getUser();
    
    if (user) {
      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json',
          Authorization: `Bearer ${user.result.accesToken}`
        }
      });
    }

    return next.handle(req).pipe(retryWhen((error) => {
      return error.pipe(
        mergeMap((error, index) => {
          if (index <= this.maxRetries && error instanceof HttpErrorResponse) {
            switch (error.status) {
              case 401:
                this.storageService.clean();
                this.alertService.oneErrorMessage('Não foi possivel efetuar o login, tente novamente ou contate o administrador');
              break;

              case 500:
                this.alertService.oneErrorMessage('Ocorreu um erro inesperado, por gentileza contate o administrador');
              break;

              default:
                this.alertService.oneErrorMessage('Não foi possivel estabelecer comunicação com o servidor interno, contate o administrador');
              break;
            }
          }


          throw error;
        })
      )
    }));
  }
}

export const httpInterceptorProviders = [
  { provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi: true },
];
