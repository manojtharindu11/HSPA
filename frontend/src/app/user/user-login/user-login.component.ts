import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent {

  constructor(private authService:AuthService, private toastr:ToastrService,private router:Router) {}

  onSubmit(loginForm:NgForm) {
    console.log(loginForm.value)
    const token = this.authService.authUser(loginForm.value)
    if (token) {
      localStorage.setItem('token',token.userName)
      this.toastr.success("Login successful!")
      this.router.navigate(['/']);
    } else {
      this.toastr.error("User Name or Password is wrong")
    }
  }
}
