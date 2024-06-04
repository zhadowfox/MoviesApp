import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieResponse, Movie } from '../interfaces/movies.interface';
import { AuthService } from './auth.service';
@Injectable({
  providedIn: 'root'
})
export class MoviesService{
  private popularMoviesUrl:string = "https://api.themoviedb.org/3/movie/popular"
  private searchMoviesUrl:string = "https://api.themoviedb.org/3/search/movie?query="
  private movieByIdUrl:string="https://api.themoviedb.org/3/movie/"
  private baseUrl:string ="http://localhost:5063/api/Movies/"
  private header: any = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'X-Skip-Interceptor':'skip',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4NWUxODk3MmZiNzc0Y2QzYTZjMzFiNjIzYTgyYjg1NCIsInN1YiI6IjY2NTBiMWQxNWQ5NTBlNmQxMTE5MGQ5MyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.hgGrC-y_BURWyRDmWmvVLRt5t2yn2qNuqt3U1zSRmzc'
  }
  constructor( private httpClient : HttpClient, private auth:AuthService) { }
  popularMovies(): Observable<MovieResponse> {
    const response:any = this.httpClient.get(this.popularMoviesUrl,{ headers : new HttpHeaders(this.header)})
    return response;
  }
  searchMovie(keyword:string):Observable<MovieResponse>{
    const response:any = this.httpClient.get(this.searchMoviesUrl+keyword,{ headers : new HttpHeaders(this.header)})
    return response
  }
  getMovieDetails(movieId:number):Observable<any>{
    const response:any = this.httpClient.get(this.movieByIdUrl+movieId,{ headers : new HttpHeaders(this.header)})
   return response 
  }
  addToFavMovies(movieId:number):any{
    let response:boolean = false
    if(this.auth.isLoggedIn()){
      const userId=this.auth.decodeToken();
      console.log(userId)
      console.log(+userId.UserId)
      console.log({userId:userId.UserId,movieId:movieId});
      const response = this.httpClient.post(this.baseUrl+"addToFav",{UserId:+userId.UserId,movieId:movieId})
      console.log(response)
      return response
    }
    return {status:false, message:"debes de estar logueado para agregar a favoritas"}
  }
}
