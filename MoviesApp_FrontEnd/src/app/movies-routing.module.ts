import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchResultComponent } from './components/search-result/search-result.component';
import { NotfoundErrorComponent } from './components/notfound-error/notfound-error.component';
import { MoviedetailsComponent } from './components/moviedetails/moviedetails.component';
const routes: Routes = [
  { path: 'search', component: SearchResultComponent },
  { path: 'details/:id', component: MoviedetailsComponent },
  { path: '', component: NotfoundErrorComponent},
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MoviesRoutingModule { }