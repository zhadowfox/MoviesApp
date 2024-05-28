import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../interfaces/movies.interface';
import { AuthService } from '../../services/auth.service';
@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent implements OnInit{
  constructor(private moviesServices :MoviesService, private auth:AuthService){}
  public isLoggedIn:boolean = false;
  public popularMovies:Movie[]=[]
  ngOnInit() {
    this.moviesServices.popularMovies().subscribe({next:(res:any)=>{
      this.popularMovies=this.getRandomMovies(res.results, 5)
    },error:(err:any)=>{
      console.log(err)
    }})
    this.isLoggedIn= this.auth.isLoggedIn();
  }
  getRandomMovies(array:[], numItems:number):Movie[] {
    // Shuffle the array
    for (let i = array.length - 1; i > 0; i--) {
      const j = Math.floor(Math.random() * (i + 1));
      [array[i], array[j]] = [array[j], array[i]]; // Swap elements
    }
    // Return the first `numItems` elements
    return array.slice(0, numItems);
  }
}
