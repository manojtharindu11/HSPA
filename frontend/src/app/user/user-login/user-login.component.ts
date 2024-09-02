import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AlertifyService } from 'src/app/services/alertify.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent {

  constructor(private authService:AuthService, private alertify:AlertifyService) {}

  onSubmit(loginForm:NgForm) {
    console.log(loginForm.value)
    const token = this.authService.authUser(loginForm.value)
    if (token) {
      localStorage.setItem('token',token.userName)
      this.alertify.success("Login successful!")
    } else {
      this.alertify.error("User Name or Password is wrong")
    }
  }
}
