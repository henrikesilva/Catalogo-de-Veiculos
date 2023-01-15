import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {

  constructor() { }
  
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const currentUser = JSON.parse(localStorage.getItem('currentUser') || '');

    if(currentUser && currentUser.token){
      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json',
          Authorization: `bearer ${currentUser.token}`
        }
      });
    }

    return next.handle(req);
  }
}
