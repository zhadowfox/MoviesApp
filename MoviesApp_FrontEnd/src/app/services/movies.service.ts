import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { MovieResponse, Movie } from '../interfaces/movies.interface';
@Injectable({
  providedIn: 'root'
})
export class MoviesService{
  private popularMoviesUrl:string = "https://api.themoviedb.org/3/movie/popular"
  private header: any = {
    'Accept': 'application/json',
    'Content-Type': 'application/json',
    'X-Skip-Interceptor':'skip',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4NWUxODk3MmZiNzc0Y2QzYTZjMzFiNjIzYTgyYjg1NCIsInN1YiI6IjY2NTBiMWQxNWQ5NTBlNmQxMTE5MGQ5MyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.hgGrC-y_BURWyRDmWmvVLRt5t2yn2qNuqt3U1zSRmzc'
  }
  constructor( private httpClient : HttpClient) { }
  popularMovies(): Observable<MovieResponse> {
    const response:any = this.httpClient.get(this.popularMoviesUrl,{ headers : new HttpHeaders(this.header)})
    return response;
  }
  getMovieDetails():Observable<any>{
    const response:any = this.httpClient.get(this.popularMoviesUrl,{ headers : new HttpHeaders(this.header)})
   return response 
  }
}
