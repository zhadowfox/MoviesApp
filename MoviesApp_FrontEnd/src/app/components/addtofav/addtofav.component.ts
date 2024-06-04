import { Component, Input } from '@angular/core';
import { MoviesService } from '../../services/movies.service';
import Swal, { SweetAlertIcon } from 'sweetalert2';
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
      let icon:SweetAlertIcon
      if(res.state==0){
        icon="error"
      }else{
        icon="success"
      }
      Swal.fire({
        text:res.message,
        icon:icon,
        showConfirmButton:false,
        showCancelButton:true,
        cancelButtonColor:"#212529",
        cancelButtonText:"Cerrar"
      })
     },
     error:(err:any)=> {
      console.log(err)
     },
    })
  }
}
