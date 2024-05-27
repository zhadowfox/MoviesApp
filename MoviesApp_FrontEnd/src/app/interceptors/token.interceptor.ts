import { HttpInterceptor,HttpHandler,HttpEvent,HttpRequest } from '@angular/common/http';
import {  Injectable } from '@angular/core';
import { request } from 'http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
const InterceptorSkip = 'X-Skip-Interceptor';
@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  constructor(private auth:AuthService){}
  intercept(req: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const myToken = this.auth.getToken();
    console.log(req.headers)
    if(req.headers && req.headers.has(InterceptorSkip)){
      return next.handle(req)
    }
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
