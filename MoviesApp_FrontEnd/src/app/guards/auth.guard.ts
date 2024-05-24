import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    // Verificamos si el usuario está autenticado utilizando el método isLoggedIn() del servicio AuthService
    if (this.authService.isLoggedIn()) {
      return true; // Permitimos el acceso si el usuario está autenticado
    } else {
      // Si el usuario no inicio sesion, redirige a la página de inicio de sesión y evita el acceso
      this.router.navigate(['/login']);
      return false;
    }
  }
}