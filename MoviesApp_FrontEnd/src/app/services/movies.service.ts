import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class MoviesService{
  private popularMoviesUrl:string = "https://api.themoviedb.org/3/movie/popular"
  private header: any = {
    'Content-Type': 'application/json',
    'Accept': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4NWUxODk3MmZiNzc0Y2QzYTZjMzFiNjIzYTgyYjg1NCIsInN1YiI6IjY2NTBiMWQxNWQ5NTBlNmQxMTE5MGQ5MyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.hgGrC-y_BURWyRDmWmvVLRt5t2yn2qNuqt3U1zSRmzc'
  }
  private requestOptions = {                                                                                                                                                                                 
    headers: new Headers(this.header), 
  };
  constructor( private httpClient : HttpClient) { }
  popularMovies(): Observable<any> {
    const response:any = this.httpClient.get(this.popularMoviesUrl,{ headers : new HttpHeaders(this.header)})
    return response;
  }
}
