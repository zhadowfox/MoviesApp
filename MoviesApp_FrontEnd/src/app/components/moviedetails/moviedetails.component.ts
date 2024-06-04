import { Component, OnInit } from '@angular/core';
import { Movie, MovieFullData } from '../../interfaces/movies.interface';
import { MoviesService } from '../../services/movies.service';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../services/auth.service';
@Component({
  selector: 'app-moviedetails',
  templateUrl: './moviedetails.component.html',
  styleUrl: './moviedetails.component.scss',
})
export class MoviedetailsComponent  implements OnInit{
  public isLoggedIn:boolean = false;
movie :MovieFullData | undefined 
movieId: number | null = null;
constructor(private movieServices:MoviesService,private route:ActivatedRoute,private auth: AuthService){
  this.isLoggedIn= this.auth.isLoggedIn();
}
ngOnInit(): void {
  this.movieId = Number(this.route.snapshot.paramMap.get('id'));
 this.movieServices.getMovieDetails(this.movieId).subscribe(data=>{
  this.movie = data
  console.log(this.movie?.genres)
 })
}
}
