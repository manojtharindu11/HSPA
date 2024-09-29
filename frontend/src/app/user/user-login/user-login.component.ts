import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserForLogin } from 'src/app/model/user';
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
    this.authService.authUser(loginForm.value).subscribe({
      next: (response :UserForLogin) => {
        console.log(response);
        if (response) {
          localStorage.setItem('token',response.token)
          localStorage.setItem('userName',response.userName)
          this.toastr.success("Login successful!")
          this.router.navigate(['/']);
        } else {
          this.toastr.error("User Name or Password is wrong")
        }
      },
      error: (err:any) => {
        console.log(err)
        this.toastr.error(err.error);
      }
    })

  }
}
