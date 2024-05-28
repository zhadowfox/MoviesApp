import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { NotfoundErrorComponent } from './components/notfound-error/notfound-error.component';
import { IndexComponent } from './components/index/index.component';
import { UserprofileComponent } from './components/userprofile/userprofile.component';
import { AuthGuard } from './guards/auth.guard';
import { AdmindashboardComponent } from './components/admindashboard/admindashboard.component';
import { adminZoneGuard } from './guards/admin-zone.guard';
const routes: Routes = [
  {path:"", redirectTo: '/home', pathMatch: 'full' },
  {path:"home", component: IndexComponent},
  {path:"login", component: LoginComponent},
  {path:"signup",component:SignupComponent},
  {path:"profile",component:UserprofileComponent,canActivate: [AuthGuard]},
  {path:"dashboardadmin",component:AdmindashboardComponent,canActivate: [AuthGuard,adminZoneGuard]},
  {path:"movies",loadChildren: () => import ("./movies-routing.module").then(m=>m.MoviesRoutingModule)},
  {path:"**",component:NotfoundErrorComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
