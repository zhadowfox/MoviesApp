import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UserStoreService {
private names$=new BehaviorSubject<string>("")
private idRol$=new BehaviorSubject<number>(2)
  constructor() { }
  public getRolFromStore(){
    return this.idRol$.asObservable()
  }
  public setRolFromStore(idRol:number){
     this.idRol$.next(idRol);
  }
  public getNamesFromStore(){
    return this.names$.asObservable()
  }
  public setNamesFromStore(names:string){
     this.names$.next(names);
  }
}
