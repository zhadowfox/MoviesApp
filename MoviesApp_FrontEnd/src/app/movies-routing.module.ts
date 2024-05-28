import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SearchResultComponent } from './components/search-result/search-result.component';
import { NotfoundErrorComponent } from './components/notfound-error/notfound-error.component';
const routes: Routes = [
  { path: 'search', component: SearchResultComponent },
  { path: 'details/:id', component: SearchResultComponent },
  { path: '', component: NotfoundErrorComponent},
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MoviesRoutingModule { }