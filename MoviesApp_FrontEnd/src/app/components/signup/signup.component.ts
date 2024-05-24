import { Component } from '@angular/core';
import {  FormControl, FormGroup, Validators } from '@angular/forms';
import ValidateForm from '../../helpers/validateForm';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.scss'
})
export class SignupComponent {
  constructor (
    private auth: AuthService,
    private router:Router
  ){}
  type:string="password"
  isText:boolean = false
  eyeIcon:string = "bi bi-eye-slash"
  passwordState:boolean = false
  signUpForm:FormGroup = new FormGroup({
    names: new FormControl('', Validators.required),
    lastnames: new FormControl('',Validators.max(10)),
    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required)
});
  hideShowPassword(){
    this.isText = !this.isText
    console.log(this.isText)
    this.isText ? this.eyeIcon = "bi bi-eye" : this.eyeIcon =  "bi bi-eye-slash"
    this.isText ? this.type = "text" : this.type = "password"
  }
  onSignUp(){
    if (this.signUpForm.invalid) return console.log("Formulario de registro vacio"), ValidateForm.validateAllFormFields(this.signUpForm);
     console.log(this.signUpForm.value)
    this.auth.singUp(this.signUpForm.value)
    .subscribe({
      next:(res)=>{
        this.signUpForm.reset()
        this.router.navigate(['/login'])
      },
      error:(err)=>{
        alert(err?.error.message)
      }
    })
 }
}
