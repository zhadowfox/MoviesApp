import { Component, Input } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
@Component({
  selector: 'app-addtofav',
  templateUrl: './addtofav.component.html',
  styleUrl: './addtofav.component.scss'
})
export class AddtofavComponent {
  @Input() movieId!: number;
  constructor(private movieServices:MoviesService){}
  addToFav():any{
    this.movieServices.addToFavMovies(this.movieId)
    .subscribe({
     next:(res:any)=>{
      console.log(res)
     },
     error:(err:any)=> {
      console.log(err)
     },
    })
  }
}
