import { HttpClient } from '@angular/common/http';
import {Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl:string ="http://localhost:5063/api/User/"
  private userPayload :any;
  constructor(private http: HttpClient , private router : Router) {
    this.userPayload = this.decodeToken();
   }
  singUp(userObj:any){
    return this.http.post<any>(`${this.baseUrl}signup`,userObj);
  }
  login(userObj:any){
    return this.http.post<any>(`${this.baseUrl}authenticate`,userObj);
  }
  storeToken(tokenValue:string){
    localStorage.setItem('UserToken',tokenValue)
  }
  getToken():string{
    return localStorage.getItem('UserToken')!;
  }
  isLoggedIn(){
    return !!localStorage.getItem('UserToken')
  }
  logginOut(){
    localStorage.clear();
    this.router.navigate(["login"])
  }
  decodeToken(){
    const jwtHelper = new JwtHelperService();
    const token:any= this.getToken();
    return jwtHelper.decodeToken(token)
  }
  getNameFromToken (){
    if(this.userPayload)
    return this.userPayload.names
  }
  getRolFromToken(){
    if(this.userPayload)
    return this.userPayload.IdRol
    return this.decodeToken()
  }
}
