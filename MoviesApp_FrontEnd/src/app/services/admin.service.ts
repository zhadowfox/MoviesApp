import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private baseUrl:string ="http://localhost:5131/api/Admin/"
  constructor( private http: HttpClient , private router : Router) { }
  listOfUsers(){
    return this.http.get<any>(`${this.baseUrl}listofusers`)
  }
  seeAnUsers(){}
  deleteUser(){}
  updateUser(){}
}
