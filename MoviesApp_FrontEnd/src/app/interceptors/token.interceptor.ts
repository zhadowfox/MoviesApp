import { HttpInterceptor,HttpHandler,HttpEvent,HttpRequest } from '@angular/common/http';
import {  Injectable } from '@angular/core';
import { request } from 'http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private auth:AuthService){}
  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const myToken = this.auth.getToken();
    if(myToken){
      req=req.clone({
        setHeaders:{
          Authorization:`Bearer ${myToken}`
        }
      })
    }
    return next.handle(req);
  }
}