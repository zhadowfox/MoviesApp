import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { UserStoreService } from '../../services/user-store.service';
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit{
  searchTerm: string="";
  constructor(private auth: AuthService  , private router: Router, private userStore : UserStoreService) { 
  }
  private isAdmin:any="";
  ngOnInit(): void {
    this.userStore.getRolFromStore().subscribe(val=>{
      this.isAdmin= val
      console.log(this.isAdmin)
    })
  }
  searchMovie(event:any){
    event.preventDefault();
    if (this.searchTerm) {
      this.router.navigate(['/movies/search'], { queryParams: { keyword: this.searchTerm } });
    }
  }
  logOut(){ return this.auth.logginOut();}
  loggedIn() { return this.auth.isLoggedIn();}
}
