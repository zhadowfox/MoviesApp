import { Component, OnInit } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent implements OnInit{
  constructor(private moviesServices :MoviesService){}
  ngOnInit() {
    this.moviesServices.popularMovies().subscribe({next:(res:any)=>{
      console.log(res)
    },error:(err:any)=>{
      console.log(err)
    }})
  }
}
