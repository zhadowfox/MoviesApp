import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { AuthService } from '../../services/auth.service';
import { UserStoreService } from '../../services/user-store.service';
@Component({
  selector: 'app-admindashboard',
  templateUrl: './admindashboard.component.html',
  styleUrl: './admindashboard.component.scss'
})
export class AdmindashboardComponent implements OnInit{
  public users:any=[];
  public names:string  = ""
  constructor(private admin:AdminService,private auth:AuthService, private userStore:UserStoreService){
  }
  ngOnInit(){
    this.admin.listOfUsers().subscribe(res=>{
      this.users = res.listOfUsers;
    })
    this.userStore.getNamesFromStore().subscribe(val=>{
      let nameFromToken =  this.auth.getNameFromToken();  
      this.names = val || nameFromToken;
    })
  }
  seeUser(){
  }
  deleteUser(){}
}
