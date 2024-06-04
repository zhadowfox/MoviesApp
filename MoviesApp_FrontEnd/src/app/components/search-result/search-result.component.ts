import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
import { Movie } from '../../interfaces/movies.interface';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../services/auth.service';
@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrl: './search-result.component.scss'
})
export class SearchResultComponent implements OnInit{
constructor(private moviesServices:MoviesService,private route:ActivatedRoute, private auth:AuthService){}
listOfFindedMovies :Movie[] | undefined;
keyword :string =""
isLoggedIn:boolean = false;
  ngOnInit(): void {
    this.route.queryParams.subscribe(params=>{
      this.keyword=params["keyword"]
      this.moviesServices.searchMovie(this.keyword).subscribe(data=>{
        this.listOfFindedMovies = data.results.sort((a,b)=> b.popularity - a.popularity )
      })
    })
    this.isLoggedIn = this.auth.isLoggedIn();
  }
}
