import { Component } from '@angular/core';
import {  FormGroup, Validators, FormControl } from '@angular/forms';
import ValidateForm from '../../helpers/validateForm';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { UserStoreService } from '../../services/user-store.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent{
  constructor(
    private auth:AuthService,
    private router:Router,
    private userStore : UserStoreService
  ){}
  loginResultMessage:string =""
  loginResultVisible:boolean=false
  type:string="password"
  isText:boolean = false
  eyeIcon:string = "bi bi-eye-slash"
  passwordState:boolean = false
  loginForm:FormGroup = new FormGroup({
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
});
  hideShowPassword(){
    this.isText = !this.isText
    this.isText ? this.eyeIcon = "bi bi-eye" : this.eyeIcon =  "bi bi-eye-slash"
    this.isText ? this.type = "text" : this.type = "password"
  }
  onLogin(){
     if (this.loginForm.invalid) return console.log("Formulario de inicio de sesion vacio"),
      ValidateForm.validateAllFormFields(this.loginForm);
     this.auth.login(this.loginForm.value)
     .subscribe({
      next:(res)=>{
        this.loginForm.reset();
        this.auth.storeToken(res.token)
        const tokenPayload = this.auth.decodeToken();
        const idRolFromToken = tokenPayload.IdRol;
        this.userStore.setNamesFromStore(tokenPayload.names);
        this.userStore.setRolFromStore(tokenPayload.IdRol);
          if (idRolFromToken == 1){
          return this.router.navigate(['/dashboardadmin'])
          }
          return this.router.navigate(['/'])
      },
      error:(err)=> {
        Swal.fire({
          title: "Ups",
          text: "Tenemos errores en nuestros servidores, intenta mas tarde",
          icon: "warning",
          showConfirmButton:false,
          showCancelButton:true,
          cancelButtonColor:"#ff0000",
          cancelButtonText:"Cerrar"
        });
        this.loginResultVisible=true
        this.loginResultMessage=err.error.message
      },
     })
  }
}
